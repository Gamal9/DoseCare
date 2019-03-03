using DoseCare.Model;
using DoseCare.Service;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DoseCare.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DoseListPage : ContentPage
	{
        private DoseServices ser;
		public DoseListPage ()
		{
			InitializeComponent ();
            
            
		}
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            ser = new DoseServices();
            ser.DataConnection();
            list.ItemsSource= await ser.GetAllDoses();
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new AddDose());
        }

        private void Ext_Clicked(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
        }
    }
}