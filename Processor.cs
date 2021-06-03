using MyTacoTruck.Ingredients;
using MyTacoTruck.Tacos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MyTacoTruck.CookMethods;

namespace MyTacoTruck
{
    public static class Processor
    {


        public static async Task CookTheOrder(TacoBase myTaco)
        {

            //Task shellsTask = HeatShellsAsync(myTaco);
            Task toppingsTask = PrepareToppingsAsync(myTaco);
            Task proteinTask = CookProteinAsync(myTaco);
            Task shellsTask2 = WaitForShellsFinishAsync(myTaco);
            var tacoTasks = new List<Task> { shellsTask2/*shellsTask*/, toppingsTask, proteinTask };

            while (tacoTasks.Count > 0)
            {
                Task finishedTask = await Task.WhenAny(tacoTasks);

                if (finishedTask == shellsTask2)
                {
                    //Console.WriteLine($"Put {(myTaco.Amount == 1 ? "shell" : "shells")}" +
                    //    $" for {myTaco.Amount} {myTaco.Protein.TypeOfProtein} {(myTaco.Amount == 1 ? "taco" : "tacos")} on plate");
                } else if (finishedTask == toppingsTask)
                {
                    //Console.WriteLine($"{myTaco.Toppings.ToppingTwoOfTwo} has been delicately drizzled all over taco");
                    //Console.WriteLine($"Sprinkling the {myTaco.Toppings.ToppingOneofTwo} all over the taco ");
                } else if (finishedTask == proteinTask)
                {
                    //Console.WriteLine($"{myTaco.Protein.TypeOfProtein} Done");
                    ////Console.WriteLine("\n");
                }

                tacoTasks.Remove(finishedTask);

              
                 
                


            }




           await  GoodbyeMessagePrompt(myTaco);

           // Console.WriteLine("How was you Day?");
           // string myDayAnswer = Console.ReadLine();

           //await  Task.Delay(5000);
           // Console.WriteLine($"This is your answer: {myDayAnswer}");

            await Task.Delay(2000);
            //Console.ReadLine();

        }


        public static async Task<Shells> WaitForShellsFinishAsync(TacoBase taco)
        {
            _ = await HeatShellsAsync(taco);
            Console.WriteLine($"Put {(taco.Amount == 1 ? "shell" : "shells")}" +
                          $" for {taco.Amount} {taco.Protein.TypeOfProtein} {(taco.Amount == 1 ? "taco" : "tacos")} on plate");
            Console.WriteLine($"{taco.Toppings.ToppingTwoOfTwo} has been delicately drizzled all over taco");
            Console.WriteLine($"Sprinkling the {taco.Toppings.ToppingOneofTwo} all over the taco ");
            Console.WriteLine($"{taco.Protein.TypeOfProtein} Done");

    
            return new Shells();

        }

        public static async Task GoodbyeMessagePrompt(TacoBase myTaco)
        {
            Console.WriteLine("\n");
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine($"Your {myTaco.Amount} {myTaco.Protein.TypeOfProtein} {(myTaco.Amount == 1 ? "taco is" : "tacos are")} ready!");
            Console.WriteLine("-------------------------------" +
                "----------------------------");
            Console.WriteLine("\n");
            Console.WriteLine("HAVE A NICE DAY!");

            await Task.Delay(3000);
            Console.Clear();
            Console.WriteLine("Would You Like to go again");
            Console.WriteLine("Hit \"A\" if yes and any other key to exit");

        }


    }




}
