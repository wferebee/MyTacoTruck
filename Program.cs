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

                string theAnswer = Console.ReadLine();

                if (theAnswer == "A")
                {
                    truth = true;
                } else
                {
                    truth = false;
                }
            }
       
        }



        public static async Task RunTacoTruck()
        {
            await UserInterface.RunInitialInterface();
            
        }

    }
}



