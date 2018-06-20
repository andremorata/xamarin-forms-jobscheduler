using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace bgSync
{
	public partial class MainPage : ContentPage
	{
        Label output;
        public MainPage()
        {
			InitializeComponent();
            
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<MainPage>(this, "Hi", (sender) => {
                Device.BeginInvokeOnMainThread(() => {
                    lbTeste.Text = "Received 'hello' at " + DateTime.Now;

                    var sync = new DoSyncJob();
                    sync.Start();
                });
            });
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<MainPage>(this, "Hi");
        }
	}
}
