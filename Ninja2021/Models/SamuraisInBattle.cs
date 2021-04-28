using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ninja2021.Models
{
    public class SamuraisInBattle
    {
        public int samuraiId { get; set; }
        public Samurai samurai { get; set; }
        public int battleId { get; set; }
        public Battle battle { get; set; }
    }
}
