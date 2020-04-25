using System;
using System.Collections.Generic;

namespace POCSignalR.Models
{
    public class ChartModel
    {
        public List<int> Data { get; set; }
        public String Label { get; set; }
        
        public ChartModel()
        {
            Data = new List<int>();
        }

    }
}