using MrRaysAuctioneer.Helper;
using MrRaysAuctioneer.Models.WoW;
using MrRaysAuctioneer.Models.WoW.Item;
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

namespace MrRaysAuctioneer
{
    /// <summary>
    /// Interaktionslogik für ItemSearchWindow.xaml
    /// </summary>
    public partial class ItemSearchWindow : Window
    {
        private BattelNetConnectionHelper battelNetConnectionHelper;

        public Item SelectedItem;


        public ItemSearchWindow(BattelNetConnectionHelper battelNetConnectionHelper)
        {
            InitializeComponent();
            this.battelNetConnectionHelper = battelNetConnectionHelper;
        }

        public void TxtFilter_TextChanged(object sender, RoutedEventArgs e)
        {

        }

        public void TxtFilter_OnKeyDown(object sender, RoutedEventArgs e)
        {

        }

        private void txtFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
                RefreshList();

        }

        private void SearchResultList_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            SelectedItem = (Item)SearchResultList.SelectedItem;
            this.DialogResult = true;
            this.Close();

        }

        private void RefreshList()
        {                
            var ItemSearch = battelNetConnectionHelper.ItemSearch(txtFilter.Text);
            SearchResultList.DataContext = ItemSearch;

        }
    }
}
