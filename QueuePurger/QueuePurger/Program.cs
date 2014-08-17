using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace QueuePurger
{
    class Program
    {
        static void Main(string[] args)
        {
            PurgeMSMQ();
        }

        private static void PurgeMSMQ()
        {
            var hostname = System.Environment.MachineName.ToString();
            try
            {
                foreach (var mq in MessageQueue.GetPrivateQueuesByMachine(hostname))
                {
                    Console.WriteLine("Purging Queue " + mq.Label);
                    try
                    {
                        mq.Purge();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Failed to purge queue " + mq.Label + " " + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("MSMQ is not installed on the machine");
            }
        }
    }
}
