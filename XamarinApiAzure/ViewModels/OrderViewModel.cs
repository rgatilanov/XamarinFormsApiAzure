using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinApiAzure.ViewModels
{
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using XamarinApiAzure.Helpers;
    using XamarinApiAzure.Models;

    public class OrderViewModel: INotifyPropertyChanged
    {
        Services webAPIService;
        public event PropertyChangedEventHandler PropertyChanged;
        ObservableCollection<Order> items;

        public ObservableCollection<Order> Items
        {
            get { return items; }
            set
            {
                items = value;
                RaisepropertyChanged("Items");
            }
        }

        public OrderViewModel()
        {
            webAPIService = new Services();
            Items = new ObservableCollection<Order>();
            GetDataFromAPI();
        }

        async void GetDataFromAPI()
        {
            Items = await webAPIService.RefreshDataAsync();
        }

        void RaisepropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
