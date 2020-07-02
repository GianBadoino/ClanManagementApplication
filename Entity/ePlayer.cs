using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ePlayer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public eRank Rank { get; set; }
        public int ParticipationPoints { get; set; }
        public int HTCPoints { get; set; }
        public string FlagPayment { get; set; }
        public DateTime JoinDate { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
