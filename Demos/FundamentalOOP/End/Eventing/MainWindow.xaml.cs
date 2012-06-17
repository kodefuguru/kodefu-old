using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Eventing
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

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            Twitter twitter = new UserTwitter(SearchText.Text);
            //var messages = twitter.GetMessages();
            //listBox1.ItemsSource = messages;
            twitter.MessagesReceived += messages =>
                {
                    listBox1.ItemsSource = messages;
                };
            twitter.GetMessages();
        }
    }
}
