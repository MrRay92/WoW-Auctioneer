using MrRaysAuctioneer.Models.WoW.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace MrRaysAuctioneer
{
    /// <summary>
    /// Interaktionslogik für Settings.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            InitializeComponent();
            ClientIdTextBox.Text = Properties.Settings.Default.ClientId;
            ClientSecretTextBox.Text = Properties.Settings.Default.ClientSecret;
            RegionComboBox.ItemsSource = Enum.GetValues(typeof(Region));
            if(Enum.TryParse<Region>(Properties.Settings.Default.Region.ToUpper(), out var region))
                RegionComboBox.SelectedItem = region;
            else
                RegionComboBox.SelectedItem = Region.EU;

            ConnectedRealmIdTextBox.Text = Properties.Settings.Default.ConnectedRealmId;
        }

        private void SettingsWindow_Closing(object sender, CancelEventArgs e)
        {
           
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.ClientId = ClientIdTextBox.Text;
            Properties.Settings.Default.ClientSecret = ClientSecretTextBox.Text;
            Properties.Settings.Default.ConnectedRealmId = ConnectedRealmIdTextBox.Text;
            Properties.Settings.Default.Region = RegionComboBox.SelectedItem.ToString().ToLower();
            Properties.Settings.Default.Save();
            Close();
        }
    }
}
