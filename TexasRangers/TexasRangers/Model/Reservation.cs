using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Threading.Tasks;

namespace TexasRangers.Model
{
    public class Reservation
    {
        [PrimaryKey, AutoIncrement]
        public int Reservation_ID { get; set; }
        public string Name { get; set; }
        public int R_Number { get; set; }
        public DateTime R_Date { get; set; }
        public DateTime R_Time { get; set; }
        public DateTime Date { get; set; }
    }
}
