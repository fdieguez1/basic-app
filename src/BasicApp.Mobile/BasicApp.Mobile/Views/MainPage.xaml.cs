using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BasicApp.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
    }
}