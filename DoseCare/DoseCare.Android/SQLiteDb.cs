using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using DoseCare.Droid;
using DoseCare.Model;
using SQLite;

[assembly: Xamarin.Forms.Dependency(typeof(DoseCare.Droid.SQLiteDb))]
namespace DoseCare.Droid
{
    public class SQLiteDb : ISQLiteDB
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var Doc = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(Doc, "DosCare.db3");
            return new SQLiteAsyncConnection(path);
        }
    }
}
