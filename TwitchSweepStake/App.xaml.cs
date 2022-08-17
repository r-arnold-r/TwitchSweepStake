using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using static TwitchSweepStake.Container;

namespace TwitchSweepStake
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private Task openFileTask = null!;
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            InitializeMediaPlayer();
            InitializeBot();
            HandleMediaPlayer();
            openFileTask = OpenFile();
        }


        private async Task OpenFile()
        {
            await Task.Run(() =>
            {
            string filename = @"members.txt";

            Container.fileMembers = new List<Member>();

            if (File.Exists(filename))
            {
                using (StreamReader readtext = new StreamReader(filename))
                {
                    var line = readtext.ReadLine();
                    while (line != null)
                    {
                        string[] tokens = line.Split('/');
                        Member member = new Member();
                        member.Name = tokens[0];
                        member.Value = Int32.Parse(tokens[1]);

                        Container.fileMembers.Add(member);
                        line = readtext.ReadLine();
                    }
                     
                }
            }
            else
            {
                File.Create(filename).Dispose();
            }
            });
        }
        private void InitializeBot()
        {
            Container.bot = new Bot();
        }

        private void InitializeMediaPlayer()
        {
            Container.mediaPlayer = new MediaPlayer();
        }

        private void OpenMediaPlayer()
        {
            Container.mediaPlayer.Open(new Uri("pack://siteoforigin:,,,/Music/music.mp3"));
            Container.mediaPlayer.MediaOpened += mediaPlayer_MediaOpened;
            Container.mediaPlayer.MediaEnded += mediaPlayer_MediaEnded;
        }

        private void mediaPlayer_MediaEnded(object? sender, EventArgs e)
        {
            Container.mediaPlayer.Position = TimeSpan.Zero;
            Container.mediaPlayer.Play();
        }

        private void mediaPlayer_MediaOpened(object? sender, EventArgs e)
        {
            Container.mediaPlayer.Play();
        }

        private void HandleMediaPlayer()
        {
            SubscribeMediaPlayerForErrors();
            OpenMediaPlayer();
        }

        private void SubscribeMediaPlayerForErrors()
        {
            Container.mediaPlayer.MediaFailed += (o, args) =>
            {
                MessageBox.Show("Media Failed: " + args.ErrorException);
            };
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            Container.mediaPlayer.Stop();
        }
    }
}
