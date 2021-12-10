using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bistaden
{
    public class DeliveryBee : Bee
    {
        private Random random = new Random();

        public DeliveryBee(Beehive home) : base(home)
        {
            Thread dThread = new Thread(GetFlower);
            dThread.Name = "DeliveryBee";
            dThread.Start();
        }

        private void GetFlower()
        {
            while (true)
            {
                //Flying to flower
                Thread.Sleep(random.Next(50, 350));

                //Fills stomach with nectar
                HoneyStomach.CurrentStorage = HoneyStomach.MaxStorage / 2;

                //Fills stomach with enzymes
                HoneyStomach.CurrentStorage = HoneyStomach.CurrentStorage / 2;

                //Flying home
                Thread.Sleep(random.Next(50, 350));
                IncreaseFlower();
                Waiting();
            }
            
        }

        private void Waiting()
        {
            bool canEnter;

            do
            {
                canEnter = Monitor.TryEnter(Home.WaitingDeliveryBees);
                if (canEnter)
                {
                    try
                    {
                        Home.WaitingDeliveryBees.Enqueue(this);

                        Monitor.PulseAll(Home.WaitingDeliveryBees);
                    }
                    catch (Exception e)
                    {
                        
                    }
                    Monitor.Exit(Home.WaitingDeliveryBees);
                }
                
            } while (!canEnter);

            

            while (Home.WaitingDeliveryBees.Contains(this))
            {
                //Waiting to be process be a producer bee
                Thread.Sleep(100);
            }

            HoneyStomach.CurrentStorage = 0;
        }

        private void IncreaseFlower()
        {
            Interlocked.Increment(ref Home.Flowers);
        }
    }
}
