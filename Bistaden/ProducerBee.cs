using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bistaden
{
    public class ProducerBee : Bee
    {
        private Random random = new Random();

        public ProducerBee(Beehive home) : base(home)
        {
            Thread pThread = new Thread(Work);
            pThread.Name = "ProducerBee";
            pThread.Start();
        }

        private void Work()
        {
            while (true)
            {
                ProcessDeliveryBee();
                ProcessBeewax();
            }
        }

        void ProcessBeewax()
        {
            HoneyStomach.CurrentStorage += (HoneyStomach.MaxStorage - HoneyStomach.CurrentStorage);

            Thread.Sleep(random.Next(100,700));

            Home.AddBeewax();
            HoneyStomach.CurrentStorage = 0;
        }

        void ProcessDeliveryBee()
        {



            Monitor.Enter(Home.WaitingDeliveryBees);
            try
            {
                while (Home.WaitingDeliveryBees.Count <= 0)
                {
                    Monitor.Wait(Home.WaitingDeliveryBees);
                }

                DeliveryBee deliveryBee = Home.WaitingDeliveryBees.Peek();

                HoneyStomach.CurrentStorage = deliveryBee.HoneyStomach.CurrentStorage;

                Home.WaitingDeliveryBees.Dequeue();

                Monitor.PulseAll(Home.WaitingDeliveryBees);
            }
            catch (Exception e)
            {
              
            }
            Monitor.Exit(Home.WaitingDeliveryBees);
        }
    }
}
