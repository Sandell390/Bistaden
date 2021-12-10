using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bistaden
{
    public abstract class Bee
    {
        public Stomach HoneyStomach { get; }

        public Beehive Home { get; }

        protected Bee(Beehive home)
        {
            this.Home = home;
            HoneyStomach = new Stomach(250);
        }

    }
}
