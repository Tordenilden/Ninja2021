using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ninja2021.Models
{
    /// <summary>
    /// note to self kør .net core 5.0+
    /// https://graphql.org/

    /// </summary>
    public class Samurai
    {
        public int samuraiId { get; set; }
        public int battlesFought { get; set; }
       // [Required] // cascading delete , så er vi fucked!!
        // 5.0 blank disable cascading
        //[Un]
        public string name { get; set; }
        //public DateTime MyProperty { get; set; }
        public List<SamuraisInBattle> samuraiBattles { get; set; }

    }
}
