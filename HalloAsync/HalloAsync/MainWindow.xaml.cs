using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace HalloAsync
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartOhneThread(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                pb.Value = i;
                Thread.Sleep(600);
            }
        }

        private void StartTask(object sender, RoutedEventArgs e)
        {
            ((Button)sender).IsEnabled = false;

            Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    pb.Dispatcher.Invoke(() => pb.Value = i);
                    Thread.Sleep(60);
                }
                this.Dispatcher.Invoke(() => ((Button)sender).IsEnabled = !false);
            });

        }

        private void StartTaskTS(object sender, RoutedEventArgs e)
        {
            ((Button)sender).IsEnabled = false;

            TaskScheduler ts = TaskScheduler.FromCurrentSynchronizationContext();

            Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Thread.Sleep(60);
                    Task.Factory.StartNew(() => pb.Value = i, CancellationToken.None, TaskCreationOptions.None, ts);
                }
                Task.Factory.StartNew(() => ((Button)sender).IsEnabled = !false, CancellationToken.None, TaskCreationOptions.None, ts);

            });
        }

        private async void StartTaskAAW(object sender, RoutedEventArgs e)
        {
            ((Button)sender).IsEnabled = false;

            for (int i = 0; i < 100; i++)
            {
                pb.Value = i;
                await Task.Delay(60);
            }

            ((Button)sender).IsEnabled = !false;
        }

        private async void StartDB(object sender, RoutedEventArgs e)
        {
            var con = new SqlConnection();
            con.ConnectionString = "Server=rdtfzguhjik;Database=Northwind;Trusted_Connection=true;";
            await con.OpenAsync();
            MessageBox.Show("OK");
        }
    }
}
