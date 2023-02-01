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
        public List<string> PCConfig { get; set; }

        public string Malfunction { get; set; }
        public DateTime CloseDate { get; set; }
        public string RepairActions { get; set; }
        public string RepairCost { get; set; }
        public string SparePartsCost { get; set; }
        public bool Completed { get; set; }

    }
}
