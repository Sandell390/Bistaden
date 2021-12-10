using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bistaden
{
    public class QueenBee : Bee
    {
        public QueenBee(Beehive home) : base(home)
        {
            MakeBees();
        }

        void MakeBees()
        {
            for (int i = 0; i < Home.MaxProducerBees; i++)
            {
                Home.AddProducerBee(new ProducerBee(Home));
            }

            for (int i = 0; i < Home.MaxDeliveryBees; i++)
            {
                Home.AddDeliveryBee(new DeliveryBee(Home));
            }
        }
    }
}
