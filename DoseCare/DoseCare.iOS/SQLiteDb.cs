using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DoseCare.Model;
using Foundation;
using SQLite;
using UIKit;
[assembly: Xamarin.Forms.Dependency(typeof(DoseCare.iOS.SQLiteDb))]
namespace DoseCare.iOS
{
    class SQLiteDb : ISQLiteDB
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var Doc = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(Doc, "DosCare.db3");    
            return new SQLiteAsyncConnection(path);
        }
    }
}
