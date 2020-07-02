using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class eRank
    {
        public int Value { get; set; }
        public string Rank { get; set; }
        public override string ToString()
        {
            return Rank;
        }
    }
}
