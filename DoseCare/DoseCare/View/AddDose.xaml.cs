using DoseCare.Model;
using DoseCare.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DoseCare.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddDose : ContentPage
	{
        ObservableCollection<string> time;
        DoseServices ser;
        public AddDose ()
		{
			InitializeComponent ();
            time = new ObservableCollection<string>();
            ser = new DoseServices();
		}

        private void Regbtn_Clicked(object sender, EventArgs e)
        {
            DataTimer();
            Dose dose = new Dose
            {
                Name = EntryDosName.Text,
                Message = EntryMessage.Text,
                Time = time
            };
            ser.OnAdd(dose);
        }
        private void DataTimer ()
        {
            var timer =  24 / stepper.Value;
            var StartTime = EntryStartTime.Time;
            for (int i = 0; i < stepper.Value; i++)
            {
                time.Add(StartTime.ToString());
                StartTime += TimeSpan.FromHours(timer);
            }
        }

    }
}