using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bistaden
{
    public class Beehive
    {
        public QueenBee Queen { get; }

        private List<Bee> ProducerBees { get; set; }

        private List<Bee> DeliveryBees { get; set; }

        public int MaxDeliveryBees { get; }
        public int MaxProducerBees { get; }

        public int HonningBottles;

        public int Flowers;

        public int Beewax = 0;

        public Queue<DeliveryBee> WaitingDeliveryBees { get; set; }

        public Beehive(int maxBees)
        {
            ProducerBees = new List<Bee>();
            DeliveryBees = new List<Bee>();
            WaitingDeliveryBees = new Queue<DeliveryBee>();
            MaxProducerBees = maxBees / 3;
            MaxDeliveryBees = MaxProducerBees * 2;
            Queen = new QueenBee(this);
        }

        public void AddProducerBee(ProducerBee bee)
        {
            ProducerBees.Add(bee);
        }

        public void AddDeliveryBee(DeliveryBee bee)
        {
            DeliveryBees.Add(bee);
        }

        public void AddBeewax()
        {
            Interlocked.Increment(ref Beewax);

            if (Beewax >= 20000)
            {
                Beewax = 0;
                Interlocked.Increment(ref HonningBottles);
            }
        }

    }
}
