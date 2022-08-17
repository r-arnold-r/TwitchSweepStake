using System;
using System.Collections.Generic;
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

namespace TwitchSweepStake
{
    /// <summary>
    /// Interaction logic for ListWindow.xaml
    /// </summary>
    public partial class ListWindow : Window
    {
        public static ListWindow Instance { get; private set; } = null!;
        private System.Windows.Threading.DispatcherTimer dispatcherTimer = null!;
        public ListWindow()
        {
            Instance = this;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SynchronizeSoundImg();
            Populateitems();
        }

        private void Populateitems()
        {
            List<UsernameListItem> listItems = new List<UsernameListItem>();

            for (int i = 0; i < Container.members.Count; i++)
            {
                var usernameListItem = new UsernameListItem();
                usernameListItem.username.Content = Container.members[i];
                listItems.Add(usernameListItem);
            }

            usernames_panel.ItemsSource = listItems;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
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

        private void close_img_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.Close();
                Container.mediaPlayer.Close();
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

        private void StartCloseTimer()
        {
            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 20);
            dispatcherTimer.Start();
        }

        private void dispatcherTimer_Tick(object? sender, EventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WinnerWindow winnerWindow = new WinnerWindow();
            winnerWindow.Show();
            this.Topmost = true;
            winnerWindow.Top = this.Top;
            winnerWindow.Left = this.Left;
            StartCloseTimer();
        }


    }
}
