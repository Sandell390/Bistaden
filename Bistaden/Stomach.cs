using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bistaden
{
    public class Stomach
    {
        public int CurrentStorage { get; set; }

        public int MaxStorage { get; }

        public Stomach(int maxStorage)
        {
            MaxStorage = maxStorage;
        }
    }
}
