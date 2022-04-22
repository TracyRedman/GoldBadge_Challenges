using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

    public class Badge
    {
        public Badge(){}
        public Badge (string name, List<string> doors)
        {
            Doors = doors;
            Name = name;
        }
        public int ID { get; set; }
        public List<string> Doors { get; set; } = new List<string>();
        public string Name { get; set; }
    }