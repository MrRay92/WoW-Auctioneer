using MrRaysAuctioneer.Extension;
using MrRaysAuctioneer.Helper;
using MrRaysAuctioneer.Models.App;
using MrRaysAuctioneer.Models.WoW;
using MrRaysAuctioneer.Models.WoW.Item;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MrRaysAuctioneer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly BattelNetConnectionHelper battelNetConnectionHelper;
        private WatchList watchList;
        private AuctionsHouse AuctionsHouse;
        private bool UnSavedData = false;
        private readonly List<CultureInfo> AvailableCultureInfo = LanguageHelper.GetAvailableLanguages();

        public MainWindow()
        {
            InitializeComponent();
            battelNetConnectionHelper = new BattelNetConnectionHelper();
            watchList = new WatchList();
            watchList = watchList.Load();
            WishListDataGrid.DataContext = null;
            WishListDataGrid.DataContext = watchList.Items;

            AuctionsHouse = new AuctionsHouse();
            AuctionsHouse = AuctionsHouse.Load();
            UpateLastUpdateInfo();

            LanguageComboBox.ItemsSource = AvailableCultureInfo;
            LanguageComboBox.SelectedValue = CultureInfo.CurrentCulture;
            
        }

        private void UpateLastUpdateInfo()
        {            
            if (AuctionsHouse == null)
                LastUpdateInfo.Content = Properties.Resources.AuctionDataNotAvailable;
            else 
                LastUpdateInfo.Content = string.Format(Properties.Resources.AuctionDataFrom, AuctionsHouse.LastUpdate);
        }

        void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            if (!UnSavedData)
                return;

            var MsgBoxResult = MessageBox.Show(Properties.Resources.UnsavedData_Msg, Properties.Resources.UnsavedData_Title, MessageBoxButton.YesNoCancel, MessageBoxImage.Question);

            switch (MsgBoxResult)
            {
                case MessageBoxResult.Yes:
                    watchList.Save();
                    break;
                case MessageBoxResult.Cancel:
                    e.Cancel = true;
                    break;
            }
        }

        void OnClick_Save(object sender, RoutedEventArgs e)
        {
            watchList.Save();
            UnSavedData = false;
        }

        void OnClick_SaveAt(object sender, RoutedEventArgs e)
        {
            SaveFileDialog openFileDialog = new()
            {
                Filter = Properties.Resources.FileFilter_JSON
            };
            if (openFileDialog.ShowDialog() != true)
                return;

            watchList.Save(openFileDialog.FileName);
            UnSavedData = false;
        }

        void OnClick_Load(object sender, RoutedEventArgs e)
        {
            watchList = watchList.Load();
            UnSavedData = false;
        }

        void OnClick_LoadFrom(object sender, RoutedEventArgs e)
        {

            OpenFileDialog openFileDialog = new()
            {
                Filter = Properties.Resources.FileFilter_JSON
            };
            if (openFileDialog.ShowDialog() != true)
                return;

            watchList = watchList.Load(openFileDialog.FileName);
        }

        private void Expander_Expanded(object sender, RoutedEventArgs e)
        {
            DataGridRow row = FindVisualParent<DataGridRow>(sender as Expander);
            row.DetailsVisibility = Visibility.Visible;
        }

        private void Expander_Collapsed(object sender, RoutedEventArgs e)
        {
            DataGridRow row = FindVisualParent<DataGridRow>(sender as Expander);
            row.DetailsVisibility = Visibility.Collapsed;
        }

        public T FindVisualParent<T>(DependencyObject child) where T : DependencyObject
        {
            DependencyObject parentObject = VisualTreeHelper.GetParent(child);
            if (parentObject == null)
                return null;
            
            if (parentObject is T parent)
                return parent;
            else
                return FindVisualParent<T>(parentObject);
        }

        void OnClick_RefeshActions(object sender, RoutedEventArgs e)
        {
            AuctionsHouse = battelNetConnectionHelper.GetAuctions();
            AuctionsHouse.Save();
            WatchListHelper.UpdateWatchListByActions(watchList, AuctionsHouse);
            UpateLastUpdateInfo();
            UpdateItemData();
            WishListDataGrid.Items.Refresh();
        }

        void OnClick_RefeshItems(object sender, RoutedEventArgs e)
        {
            WatchListHelper.UpdateWatchListImages(battelNetConnectionHelper, watchList, false);
            WishListDataGrid.Items.Refresh();
        }

        private void Button_Click_AddIetm(object sender, RoutedEventArgs e)
        {
            var newItem = AddNewItem();
            if (newItem == null)
                return;

            watchList.AddItem(newItem);
            UpdateItemData();
        }
        private void Button_Click_NoExtra(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(Properties.Resources.NoExtraMsg);
        }
        
        private void MenuItem_Click_AddSubItem(object sender, RoutedEventArgs e)
        {
            var selectedItem = (WatchListItem)WishListDataGrid.SelectedItem;

            var newItem = AddNewItem();
            if (newItem == null)
                return;

            watchList.AddSubItem(selectedItem, newItem);
            UpdateItemData();
        }

        private void UpdateItemData()
        {
            WatchListHelper.UpdateWatchListImages(battelNetConnectionHelper, watchList, true);
            WatchListHelper.UpdateWatchListByActions(watchList, AuctionsHouse);
            WishListDataGrid.Items.Refresh();
            UnSavedData = true;
        }

        private Item AddNewItem()
        {
            var itemSearchWindow = new ItemSearchWindow(battelNetConnectionHelper);
            if (!itemSearchWindow.ShowDialog().GetValueOrDefault(false))
                return null;

            return itemSearchWindow.SelectedItem;
        }

        private void MenuItem_Click_WoWHead(object sender, RoutedEventArgs e)
        {
            var selectedItem = (WatchListItem)WishListDataGrid.SelectedItem;
            if (selectedItem == null)
                return;

            var url = $"https://{CultureInfo.CurrentCulture.TwoLetterISOLanguageName}.wowhead.com/item={selectedItem.ItemId}";
            var psi = new System.Diagnostics.ProcessStartInfo
            {
                UseShellExecute = true,
                FileName = url
            };
            System.Diagnostics.Process.Start(psi);
        }

        private void MenuItem_Click_Settings(object sender, RoutedEventArgs e)
        {
            var settingsWindow = new SettingsWindow();
            settingsWindow.ShowDialog();
        }

        private void LanguageComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LanguageHelper.ChangCurrentLanguage((CultureInfo)LanguageComboBox.SelectedValue);
        }
    }
}
