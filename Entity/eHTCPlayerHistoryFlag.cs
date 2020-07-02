using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class eHTCPlayerHistoryFlag
    {
        public int IDPlayer { get; set; }
        public bool AllowUndo { get; set; }
        public bool AllowRedo { get; set; }
    }
}
