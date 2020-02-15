using System;
using System.Collections.Generic;

using System.Text;

namespace XamarinApiAzure.Helpers
{
    using Newtonsoft.Json;
    using System.Collections.ObjectModel;
    using System.Net.Http;
    using System.Threading.Tasks;
    using XamarinApiAzure.Models;

    public class Services
    {
        HttpClient client;

        public string WebAPIUrl { get; private set; }
        public ObservableCollection<Order> Items { get; private set; }
        public Services()
        {
            client = new HttpClient();
        }

        public async Task<ObservableCollection<Order>> RefreshDataAsync()
        {
            WebAPIUrl = "https://ena.azurewebsites.net/api/order";
            var uri = new Uri(WebAPIUrl);
            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Items = JsonConvert.DeserializeObject<ObservableCollection<Order>>(content);
                    return Items;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return null;
        }
    }
}
