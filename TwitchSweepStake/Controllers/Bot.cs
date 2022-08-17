using System;
using System.Collections.Generic;
using TwitchLib.Client.Models;
using TwitchLib.Client;
using TwitchLib.Client.Events;
using Weighted_Randomizer;

namespace TwitchSweepStake
{ 
    internal class Bot
    {
        private readonly ConnectionCredentials connectionCredentials;
        private TwitchClient client;
        public IWeightedRandomizer<string> randomizer;
        private List<String> members;

        public Bot()
        {
            this.connectionCredentials = new ConnectionCredentials(TwitchResource.ChannelName, TwitchResource.BotToken);
            this.client = new TwitchClient();
            randomizer = new DynamicWeightedRandomizer<string>();
            members = new List<String>();
        }

        internal void Connect()
        {
            client.Initialize(connectionCredentials, TwitchResource.ChannelName);

#pragma warning disable CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).
            client.OnMessageReceived += Client_OnMessageReceived;
#pragma warning restore CS8622 // Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).

            try
            {
                client.Connect();
            }
            catch (Exception ex)
            {
                while(client.IsConnected == false)
                {
                    client.Connect();
                }
            }

        }

        internal Boolean IsConnected()
        {
            return client.IsConnected;
        }

        private void Client_OnMessageReceived(object sender, OnMessageReceivedArgs e)
        {
            //Console.WriteLine(e.ChatMessage.Username + ": " + e.ChatMessage.Message + "  " + e.ChatMessage.UserId);
            VerifyMessageForPrizeCompetition(e);
        }

        private void VerifyMessageForPrizeCompetition(OnMessageReceivedArgs e)
        {
            if (e.ChatMessage.UserId == "100135110" && e.ChatMessage.Message.Contains("regisztrált a nyereményjátékra"))
            {
                var username = GetTextAfter(GetTextBefore(e.ChatMessage.Message, ","), "@");

                if (randomizer.Contains(username))
                {
                    if(randomizer[username] == 2)
                    {
                        Console.WriteLine("Candidate : " + username + " reached max probability!");
                    }
                    else
                    {
                        randomizer[username] += 1;
                    }

                }
                else
                {
                   randomizer.Add(username, 1);
                   members.Add(username);
                }

                Console.WriteLine("Candidate added: " + username);
            }
        }

        public void AddToRandomizer(string name)
        {
            if (randomizer.Contains(name))
            {
                if (randomizer[name] == 2)
                {
                    Console.WriteLine("Candidate : " + name + " reached max probability!");
                }
                else
                {
                    randomizer[name] += 1;
                }
            }
            else
            {
                randomizer.Add(name, 1);
                members.Add(name);
            }
        }

        private string GetTextAfter(string data, string keyWord)
        {
            int ix = data.IndexOf(keyWord);

            if (ix != -1)
            {
                return data[(ix + keyWord.Length)..];
            }

            return "";
        }

        internal string CalculateWinner()
        {
            if(randomizer.Count > 0)
            {
                return randomizer.NextWithReplacement(); 
            }
            else
            {
                return "";
            }
           
        }

        internal IWeightedRandomizer<string> GetRandomizer()
        {
            return randomizer;
        }

        private string GetTextBefore(string data, string keyWord)
        {
            int ix = data.IndexOf(keyWord);

            if (ix != -1)
            {
                return data[..ix];
            }

            return "";
        }

        internal List<String> GetMembers()
        {
            return this.members;
        }

        internal void ClearCandidates()
        {
            randomizer.Clear();
        }

        internal void Disconnect()
        {
            client.Disconnect();
        }
    }
}