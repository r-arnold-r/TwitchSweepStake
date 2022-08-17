using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace TwitchSweepStake
{
    /// <summary>
    /// Interaction logic for WaitingWindow.xaml
    /// </summary>
    public partial class WaitingWindow : Window
    {
        public static WaitingWindow Instance { get; private set; } = null!;
        private System.Windows.Threading.DispatcherTimer dispatcherTimerBack = null!;
        private System.Windows.Threading.DispatcherTimer dispatcherTimerForward = null!;
        private Task startBotTask =null!;
        private Task disconnectBotTask =null!;

        public WaitingWindow()
        {
            Instance = this;
            InitializeComponent();

            if (Container.bot.IsConnected() == false)
            {
                startBotTask = StartBot();
            }

            for (int i = 0; i < Container.fileMembers.Count; i++)
            {
                for (int j = 0; j < Container.fileMembers[i].Value; j++)
                {
                    Container.bot.AddToRandomizer(Container.fileMembers[i].Name);
                }
            }
        }


        private async Task StartBot()
        {
            try
            {
                await Task.Run(() =>
                {
                    Container.bot.Connect();
                    this.Dispatcher.Invoke(() =>
                    {
                        ShowUI();
                    });
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ShowUI()
        {

            back_img.Visibility = Visibility.Visible;
            jelentkezesek_btn.Visibility = Visibility.Visible;
        }

        private async Task DisconnectBot()
        {
            try
            {
                await Task.Run(() =>
                {
                    Container.bot.Disconnect();
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SynchronizeSoundImg();
        }

        private void SynchronizeSoundImg()
        {
            if (Container.mediaPlayer.IsMuted == true)
            {
                sound_img.Source = new BitmapImage(new Uri("pack://application:,,,/Images/volume_mute.png"));
            }
            else
            {
                sound_img.Source = new BitmapImage(new Uri("pack://application:,,,/Images/volume_up.png"));
            }
        }

        private void sound_img_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                if (Container.mediaPlayer.IsMuted == false)
                {
                    Container.mediaPlayer.IsMuted = true;
                    sound_img.Source = new BitmapImage(new Uri("pack://application:,,,/Images/volume_mute.png"));
                }
                else
                {
                    Container.mediaPlayer.IsMuted = false;
                    sound_img.Source = new BitmapImage(new Uri("pack://application:,,,/Images/volume_up.png"));
                }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void close_img_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                SaveMembers();
                Container.mediaPlayer.Close();
                disconnectBotTask = DisconnectBot();
                this.Close();
                MainWindow.Instance.Close();
            }
        }

        private void StartBackTimer()
        {
            dispatcherTimerBack = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimerBack.Tick += dispatcherTimerBack_Tick;
            dispatcherTimerBack.Interval = new TimeSpan(0, 0, 0, 1, 0);
            dispatcherTimerBack.Start();
        }

        private void StartForwardTimer()
        {
            dispatcherTimerForward = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimerForward.Tick += dispatcherTimerForward_Tick;
            dispatcherTimerForward.Interval = new TimeSpan(0, 0, 0, 1, 0);
            dispatcherTimerForward.Start();
        }

        private void dispatcherTimerBack_Tick(object? sender, EventArgs e)
        {
            dispatcherTimerBack.Stop();
            this.Close();
        }

        private void dispatcherTimerForward_Tick(object? sender, EventArgs e)
        {
            dispatcherTimerForward.Stop();
            this.Close();
            MainWindow.Instance.Close();
        }

        private void back_img_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (startBotTask.IsCompleted == true)
            {
                SaveMembers();
                MainWindow.Instance.Visibility = Visibility.Visible;
                this.Topmost = true;
                MainWindow.Instance.Top = this.Top;
                MainWindow.Instance.Left = this.Left;

                disconnectBotTask = DisconnectBot();

                StartBackTimer();
            }

        }
        /*
        private async Task SaveMembers()
        {
            try
            {
                await Task.Run(() =>
                {
                    Container.bot.Disconnect();
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        */

        private void SaveMembers()
        {
            string filename = @"members.txt";
            File.WriteAllText(filename, string.Empty);

            Container.members = Container.bot.GetMembers();
            using (StreamWriter writetext = new StreamWriter(filename))
            {
                for (int i = 0; i < Container.members.Count; i++)
                {
                    writetext.WriteLine(Container.members[i] + "/" + Container.bot.randomizer[Container.members[i]]);
                }
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (startBotTask.IsCompleted == true)
            {
                back_img.Visibility = Visibility.Hidden;
                jelentkezesek_btn.Visibility = Visibility.Hidden;

                

                SaveMembers();

                disconnectBotTask = DisconnectBot();
                ListWindow listWindow = new ListWindow();
                listWindow.Show();
                this.Topmost = true;
                listWindow.Top = this.Top;
                listWindow.Left = this.Left;
                StartForwardTimer();
            }
        }
    }
}
