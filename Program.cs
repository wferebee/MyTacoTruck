using MyTacoTruck.Ingredients;
using MyTacoTruck.Tacos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static MyTacoTruck.CookMethods;
using static MyTacoTruck.Processor;
namespace MyTacoTruck
{
    public class Program
    {
        public static async Task Main()
        {






            bool truth = true;

            while (truth)
            {
               await RunTacoTruck();
                await Task.Delay(2000);
//;                Console.WriteLine("Would You Like to go again");
//                Console.WriteLine("Hit \"A\" if yes and any ither key to exit");
                string theAnswer = Console.ReadLine();

                if (theAnswer == "A")
                {
                    truth = true;
                } else
                {
                    truth = false;
                }
            }
       
            
            
            



            //Console.ReadLine();

           





        }



        public static async Task RunTacoTruck()
        {
            await UserInterface.RunInitialInterface();
            
        }


    }
}



