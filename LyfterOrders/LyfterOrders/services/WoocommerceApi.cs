using System;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using LyfterOrders.models;
using LyfterOrders.helpers;

namespace LyfterOrders.services
{
    public class WoocommerceApi
    {
        private static string websiteUrl = "http://ordersshop.lyfter.nl";
        private static string consumerKey = "ck_61b7f44c19fa502f97a37afa0c6370bc6e802503";
        private static string consumerSecret = "cs_a2eac810594f918967aad57e9e7183550e06d094";

        private static String getRequestUrl(String requestType)
        {
            return string.Format("{0}/wc-api/v3/{1}?" + OAuthHelper.getAuthString(consumerKey), websiteUrl, requestType);
        }
        
        public async Task<Orders> GetAllOrders()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(getRequestUrl("orders"));
            HttpContent content = response.Content;
            var json = await content.ReadAsStringAsync();
            var orders = JsonConvert.DeserializeObject<Orders>(json);
            System.Diagnostics.Debug.WriteLine(orders);
            return orders;
        }
    }
}