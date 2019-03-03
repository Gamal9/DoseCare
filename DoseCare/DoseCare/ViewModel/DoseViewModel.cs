using DoseCare.Model;
using DoseCare.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace DoseCare.ViewModel
{
    public class DoseViewModel : INotifyPropertyChanged
    {
        DoseServices ser;
        public DoseViewModel()
        {
            ser = new DoseServices();
        }
        private async void DataGetter()
        {
           Doses = await ser.GetAllDoses();
        }

        private ObservableCollection<Dose> _doses;
        public ObservableCollection<Dose> Doses
        {
            get { return _doses; }
            set { _doses = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
