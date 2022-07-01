using MrRaysAuctioneer.Models.WoW;
using MrRaysAuctioneer.Models.WoW.Api;
using MrRaysAuctioneer.Models.WoW.Item;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Web;

namespace MrRaysAuctioneer.Helper
{
    public class BattelNetConnectionHelper
    {        
        static readonly HttpClient client = new ();
        private readonly OAuthToken oAuthToken;
        public BattelNetConnectionHelper()
        {          
            oAuthToken = RequestAuthorizationToken();
        }

        /// <summary>
        /// Process the Request to BattelNet Api
        /// </summary>
        /// <param name="action">action URL</param>
        /// <param name="query">query String</param>
        /// <param name="ns">Namespace</param>
        /// <returns>Respone as JSON</returns>
        private string ProcessRequest(string action, string query = null, string ns= null)
        {
            if (string.IsNullOrEmpty(ns))
                ns = $"dynamic-{GetRegion()}";

            string Url = $"https://{GetRegion()}.api.blizzard.com/";
            Url += action;
            Url += "?access_token=" + oAuthToken.AccessToken;
            Url += "&namespace=" + ns;
            Url += "&locale=" + LocalizationHelper.GetWoWCultureInfo();
            if (!string.IsNullOrEmpty(query))
                Url += "&" + query;

            var request = new HttpRequestMessage(HttpMethod.Get, Url);
            var respone = client.Send(request);

            return respone.Content.ReadAsStringAsync().Result;
        }

        /// <summary>
        /// Item search
        /// </summary>
        /// <param name="name">part of the name</param>
        public List<Item> ItemSearch(string name)
        {
            var query = $"name.{LocalizationHelper.GetWoWCultureInfo()}={name}";
            var response = ProcessRequest("data/wow/search/item", query, $"static-{GetRegion()}");
            var ItemSearchResult = JsonSerializer.Deserialize<ItemSearch>(response);
            var result = ItemSearchResult.Results.Select(d => d.Item).ToList();
            return result;
        }

        /// <summary>
        /// get alle Actions from the selected Servers 
        /// </summary>
        public AuctionsHouse GetAuctions()
        {
            var response = ProcessRequest($"data/wow/connected-realm/{Properties.Settings.Default.ConnectedRealmId}/auctions", "", $"dynamic-{GetRegion()}");
            var serializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                AllowTrailingCommas = true,
                ReadCommentHandling = JsonCommentHandling.Skip,
            };
            var auctionsHouse = JsonSerializer.Deserialize<AuctionsHouse>(response, serializerOptions);
            auctionsHouse.LastUpdate = DateTime.Now;
            return auctionsHouse;
        }

        /// <summary>
        /// Get the Image for a Item 
        /// </summary>
        /// <param name="itemId">Id of Item</param>
        /// <returns></returns>
        public string GetItemImage(long itemId)
        {
            var response = ProcessRequest($"data/wow/media/item/{itemId}", ns: $"static-{GetRegion()}");
            var ItemMedia = JsonSerializer.Deserialize<ItemMedia>(response);
            if (ItemMedia.Assets == null)
                return null;
           
            return ItemMedia.Assets.First(a=>a.Key == "icon").Value;
        }

        /// <summary>
        /// Request Authorization Token
        /// </summary>
        /// <returns>OAuthToken - Authorization Token</returns>
        private static OAuthToken RequestAuthorizationToken()
        {
            var request = new HttpRequestMessage(HttpMethod.Post, $"https://{GetRegion()}.battle.net/oauth/token");
            request.Headers.Add("cache-control", "no-cache");
            var parm = new NameValueCollection
            {
                { "grant_type", "client_credentials" },
                { "client_id", Properties.Settings.Default.ClientId },
                { "client_secret", Properties.Settings.Default.ClientSecret }
            };
            request.Content = new StringContent(ToQueryString(parm)[1..], System.Text.Encoding.UTF8, "application/x-www-form-urlencoded");
            var response = client.Send(request);

            return JsonSerializer.Deserialize<OAuthToken>(response.Content.ReadAsStringAsync().Result);
        }

        private static string ToQueryString(NameValueCollection nvc)
        {
            var array = (
                from key in nvc.AllKeys
                from value in nvc.GetValues(key)
                select string.Format(
            "{0}={1}",
            HttpUtility.UrlEncode(key),
            HttpUtility.UrlEncode(value))
                ).ToArray();
            return "?" + string.Join("&", array);
        }

        private static string GetRegion()
        {
           return Properties.Settings.Default.Region;
        }
    }

}
