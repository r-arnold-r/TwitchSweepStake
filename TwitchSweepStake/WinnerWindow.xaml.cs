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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace TwitchSweepStake
{
    /// <summary>
    /// Interaction logic for WinnerWindow.xaml
    /// </summary>
    public partial class WinnerWindow : Window
    {
        public static WinnerWindow Instance { get; private set; } = null!;

        private Storyboard storyboard = null!;
        private TimeSpan duration;
        private TimeSpan duration2;
        private TimeSpan duration3;

        private Task calculateWinnerTask = null!;

        public WinnerWindow()
        {
            Instance = this;
            InitializeComponent();
            InitializeOpacities();
            InitializeAnimationTools();
            calculateWinnerTask = CalculateWinner();
        }


        private async Task CalculateWinner()
        {
            try
            {
                await Task.Run(() =>
                {
                    Container.bot.Connect();
                    this.Dispatcher.Invoke(() =>
                    {
                        winner_name.Content = Container.bot.CalculateWinner();
                    });
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void InitializeAnimationTools()
        {
            storyboard = new Storyboard();
            duration = TimeSpan.FromMilliseconds(500);
            duration2 = TimeSpan.FromMilliseconds(1000);
            duration3 = TimeSpan.FromMilliseconds(4000);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SynchronizeSoundImg();
            Crop1Animation();
            Crop2Animation();
            Crop3Animation();
            BackgroundAnimation();
            MainCanvasAnimation();
            WinnerNameAnimation();
        }

        private void InitializeOpacities()
        {
            winner_name.Opacity = 0;
            this.Background.Opacity = 0;
            OptionsCanvas.Opacity = 0;
            MainCanvas.Opacity = 0;
            crop1.Opacity = 0;
            crop2.Opacity = 0;
            crop3.Opacity = 0;
        }

        private void WinnerNameAnimation()
        {
            DoubleAnimation fadeInAnimation = new DoubleAnimation()
            { From = 0.0, To = 1.0, Duration = new Duration(duration3) };
            fadeInAnimation.BeginTime = TimeSpan.FromSeconds(24);

            Storyboard.SetTargetName(fadeInAnimation, winner_name.Name);
            Storyboard.SetTargetProperty(fadeInAnimation, new PropertyPath("Opacity", 1));
            storyboard.Children.Add(fadeInAnimation);
            storyboard.Begin(winner_name);
        }

        private void MainCanvasAnimation()
        {
            DoubleAnimation fadeInAnimation = new DoubleAnimation()
            { From = 0.0, To = 1.0, Duration = new Duration(duration3) };
            fadeInAnimation.BeginTime = TimeSpan.FromSeconds(19);

            Storyboard.SetTargetName(fadeInAnimation, MainCanvas.Name);
            Storyboard.SetTargetProperty(fadeInAnimation, new PropertyPath("Opacity", 1));
            storyboard.Children.Add(fadeInAnimation);
            storyboard.Begin(MainCanvas);
        }

        private void BackgroundAnimation()
        {
            DoubleAnimation fadeInAnimation = new DoubleAnimation()
            { From = 0.0, To = 1.0, Duration = new Duration(duration3) };
            fadeInAnimation.BeginTime = TimeSpan.FromSeconds(14);

            Storyboard.SetTargetProperty(fadeInAnimation, new PropertyPath("Background.Opacity", 1));
            storyboard.Children.Add(fadeInAnimation);
            storyboard.Begin(this);

            Storyboard.SetTargetName(fadeInAnimation, OptionsCanvas.Name);
            Storyboard.SetTargetProperty(fadeInAnimation, new PropertyPath("Opacity", 1));
            storyboard.Children.Add(fadeInAnimation);
            storyboard.Begin(OptionsCanvas);
        }

        private void Crop3Animation()
        {
            DoubleAnimation fadeInAnimation = new DoubleAnimation()
            { From = 0.0, To = 1.0, Duration = new Duration(duration2) };
            fadeInAnimation.BeginTime = TimeSpan.FromSeconds(10);

            DoubleAnimation fadeOutAnimation = new DoubleAnimation()
            { From = 1.0, To = 0.0, Duration = new Duration(duration) };
            fadeOutAnimation.BeginTime = TimeSpan.FromSeconds(12);

            Storyboard.SetTargetName(fadeInAnimation, crop3.Name);
            Storyboard.SetTargetProperty(fadeInAnimation, new PropertyPath("Opacity", 1));
            storyboard.Children.Add(fadeInAnimation);
            storyboard.Begin(crop3);

            Storyboard.SetTargetName(fadeOutAnimation, crop3.Name);
            Storyboard.SetTargetProperty(fadeOutAnimation, new PropertyPath("Opacity", 0));
            storyboard.Children.Add(fadeOutAnimation);
            storyboard.Begin(crop3);
        }

        private void Crop2Animation()
        {
            DoubleAnimation fadeInAnimation = new DoubleAnimation()
            { From = 0.0, To = 1.0, Duration = new Duration(duration2) };
            fadeInAnimation.BeginTime = TimeSpan.FromSeconds(6);

            DoubleAnimation fadeOutAnimation = new DoubleAnimation()
            { From = 1.0, To = 0.0, Duration = new Duration(duration) };
            fadeOutAnimation.BeginTime = TimeSpan.FromSeconds(8);

            Storyboard.SetTargetName(fadeInAnimation, crop2.Name);
            Storyboard.SetTargetProperty(fadeInAnimation, new PropertyPath("Opacity", 1));
            storyboard.Children.Add(fadeInAnimation);
            storyboard.Begin(crop2);

            Storyboard.SetTargetName(fadeOutAnimation, crop2.Name);
            Storyboard.SetTargetProperty(fadeOutAnimation, new PropertyPath("Opacity", 0));
            storyboard.Children.Add(fadeOutAnimation);
            storyboard.Begin(crop2);
        }
        private void Crop1Animation()
        {
            DoubleAnimation fadeInAnimation = new DoubleAnimation()
            { From = 0.0, To = 1.0, Duration = new Duration(duration2) };
            fadeInAnimation.BeginTime = TimeSpan.FromSeconds(2);

            DoubleAnimation fadeOutAnimation = new DoubleAnimation()
            { From = 1.0, To = 0.0, Duration = new Duration(duration) };
            fadeOutAnimation.BeginTime = TimeSpan.FromSeconds(4);

            Storyboard.SetTargetName(fadeInAnimation, crop1.Name);
            Storyboard.SetTargetProperty(fadeInAnimation, new PropertyPath("Opacity", 1));
            storyboard.Children.Add(fadeInAnimation);
            storyboard.Begin(crop1);

            Storyboard.SetTargetName(fadeOutAnimation, crop1.Name);
            Storyboard.SetTargetProperty(fadeOutAnimation, new PropertyPath("Opacity", 0));
            storyboard.Children.Add(fadeOutAnimation);
            storyboard.Begin(crop1);
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
                Container.mediaPlayer.Close();
                this.Close();
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


    }
}
