using DoseCare.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DoseCare.Service
{
    public class DoseServices 
    {
        SQLiteAsyncConnection connection;
        ObservableCollection<Dose> AllDoses;
        public DoseServices()
        {
            DataConnection();
        }

        public async Task<ObservableCollection<Dose>> GetAllDoses()
        {
            var list = await connection.Table<Dose>().ToListAsync();
            return new ObservableCollection<Dose>(list);
        }

        public async void OnAdd(Dose dose)
        {
            await connection.InsertAsync(dose);
        }

        public async void OnDelete(Dose dose)
        {
            await connection.DeleteAsync(dose);
        }

        public async void OnUpdate(Dose dose)
        {
            await connection.UpdateAsync(dose);
        }



        public async void DataConnection()
        {
            connection = DependencyService.Get<ISQLiteDB>().GetConnection();
            await connection.CreateTableAsync<Dose>();
        }

        

    }
}
