using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoseCare.Model
{
    public interface ISQLiteDB
    {
        SQLiteAsyncConnection GetConnection();
    }
}
