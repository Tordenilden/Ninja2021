using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ninja2021.Models
{
    public class Battle
    {
        public int battleId { get; set; }
        public string name { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }

        // this is a navigation for Entity Framework, so it can create a relation to SamuraisInBattle
        public List<SamuraisInBattle> samuraiBattles { get; set; }

    }
}
