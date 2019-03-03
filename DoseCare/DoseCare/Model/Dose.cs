using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DoseCare.Model
{
    [Table("Doses")]
    public class Dose
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        [MaxLength(255)]
        public string Name { get; set; }
        [MaxLength(255)]
        public string Message { get; set; }
        [TextBlob("TimeBlobbed")]
        public ObservableCollection<string> Time { get; set; }
    }
}
