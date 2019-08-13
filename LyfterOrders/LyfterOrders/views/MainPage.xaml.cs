using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LyfterOrders.models;
using LyfterOrders.services;
using Xamarin.Forms;

namespace LyfterOrders
{
    public partial class MainPage : ContentPage
    {
        public List<Order> FinalOrders { get; set; }
        public MainPage()
        {
            InitializeComponent();
            InitAsync();
        }
        
        private async Task InitAsync()
        {
            var api = new WoocommerceApi();
            var AllOrders = await api.GetAllOrders();
            FinalOrders = AllOrders.orders.ToList();
            ordersListView.ItemsSource = FinalOrders;
        }
    }
}