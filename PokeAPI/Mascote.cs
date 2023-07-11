using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeAPI
{
    internal class Mascote
    {
        public string? name { get; set; }

        public int? height { get; set; }

        public int? weight { get; set; }

        public List<Abilities>? abilities { get; set; }
        public List<Results>? results { get; set; }
    }
}
