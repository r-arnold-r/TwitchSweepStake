using Microsoft.Win32;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TwitchSweepStake
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow Instance { get; private set; } = null!;
        private System.Windows.Threading.DispatcherTimer dispatcherTimer = null!;

        public MainWindow()
        {
            Instance = this;
            InitializeComponent();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
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

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void close_img_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                Container.mediaPlayer.Close();
                this.Close();
            }

        }

        private void sound_img_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                if(Container.mediaPlayer.IsMuted == false)
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
       
        private void StartHideTimer()
        {
            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0,0,0,0,500);
            dispatcherTimer.Start();
        }

        private void dispatcherTimer_Tick(object? sender, EventArgs e)
        {
            dispatcherTimer.Stop();
            this.Visibility = Visibility.Hidden;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WaitingWindow waitingWindow = new WaitingWindow();
            waitingWindow.Show();
            this.Topmost = true;
            waitingWindow.Top = this.Top;
            waitingWindow.Left = this.Left;
            StartHideTimer();
        }

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if(this.Visibility == Visibility.Visible)
            {
                SynchronizeSoundImg();
            }

        }
    }
}
