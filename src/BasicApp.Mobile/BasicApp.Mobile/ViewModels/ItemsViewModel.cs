using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using BasicApp.Mobile.Models;
using BasicApp.Mobile.Views;
using BasicApp.DTO;
using RestSharp;
using BasicApp.Mobile.Services;
using System.Threading;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BasicApp.Mobile.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<NewsDto> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ItemsViewModel()
        {
            Title = "Browse";
            Items = new ObservableCollection<NewsDto>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();

                var restClient = new RestClient(ServiceClient.ApiEndpoint);

                var request = new RestRequest("news", Method.GET);

                var cancellationTokenSource = new CancellationTokenSource();

                var response = await restClient.ExecuteTaskAsync(request, cancellationTokenSource.Token);

                var items = JsonConvert.DeserializeObject<List<NewsDto>>(response.Content);

                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}