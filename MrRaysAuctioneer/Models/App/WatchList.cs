
using MrRaysAuctioneer.Helper;
using MrRaysAuctioneer.Models.WoW.Item;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MrRaysAuctioneer.Models.App
{
    public class WatchList
    {
        public WatchList()
        {
            Items = new List<WatchListItem>();            
        }

        public void AddItem(Item item)
        {
            Items.Add(new WatchListItem(item));
        }

        public void AddSubItem(WatchListItem watchListItem, Item item)
        {
            Items.Where(i => i.Id == watchListItem.Id).ToList().ForEach(i=>i.SubItems.Add(new WatchListSubItem(item)));
        }

        public void Save(string filePath = null)
        {
            string json = JsonSerializer.Serialize(this);
            File.WriteAllText(GetPath(filePath), json);
        }

        public WatchList Load(string filePath = null)
        {
            if (!File.Exists(GetPath(filePath)))
                return new WatchList();

            var json = File.ReadAllText(GetPath(filePath));
            return JsonSerializer.Deserialize<WatchList>(json);
        }

        public string GetPath(string filePath = null)
        {
            if (filePath != null)
                return filePath;

            return FileHelper.GetTempPath("WatchList.json");
        }

        public List<WatchListItem> Items
        {
            get; set;
        }

    }
}
