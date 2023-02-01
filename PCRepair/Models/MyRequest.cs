using System;
using SQLite;
using System.Collections.Generic;

namespace PCRepair.Models
{
    public class MyRequest
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public DateTime CreateDate { get; set; }
        public string ClientName { get; set; }
        public string ClientSurName { get; set; }
        public string ClientSurSurName { get; set; }

        public List<string> PCConfig { get; set; }
        public string PCConfigselected { get; set; }

        public List<string> Malfunction { get; set; }
        public string Malfunctionselected { get; set; }

        public DateTime CloseDate { get; set; }
        public string RepairActions { get; set; }
        public string RepairCost { get; set; }
        public string SparePartsCost { get; set; }
        public bool Completed { get; set; }

        public MyRequest()
        {
            Malfunction = new List<string>()
            {
                "Намок",
                "Сломался ЖД",
                "Сломался Монитор",
                "Сломались колонки",
                "Компьютер просто не включается"
            };
            PCConfig = new List<string>()
            {
                "Desktop",
                "Laptop",
                "Gaming PC",
                "Workstation",
                "Server"
            };
        }
    }
}
