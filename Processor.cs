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
            Task toppingsTask = PrepareToppings(myTaco);
            Task proteinTask = CookProtein(myTaco);
            Task shellsTask2 = MakeSureShellsAreDone(myTaco);
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

            
            Console.WriteLine("\n");
            Console.WriteLine("-----------------------------------------------------------");
            Console.WriteLine($"Your {myTaco.Amount} {myTaco.Protein.TypeOfProtein} {(myTaco.Amount == 1 ? "taco is" : "tacos are")} ready!");
            Console.WriteLine("-------------------------------" +
                "----------------------------");
            Console.WriteLine("\n");
            Console.WriteLine("HAVE A NICE DAY!");

            await Task.Delay(7000);
            Console.Clear();



        
            

        }


        public static async Task<Shells> MakeSureShellsAreDone(TacoBase taco)
        {
            _ = await HeatShellsAsync(taco);
            Console.WriteLine($"Put {(taco.Amount == 1 ? "shell" : "shells")}" +
                          $" for {taco.Amount} {taco.Protein.TypeOfProtein} {(taco.Amount == 1 ? "taco" : "tacos")} on plate");
            Console.WriteLine($"{taco.Toppings.ToppingTwoOfTwo} has been delicately drizzled all over taco");
            Console.WriteLine($"Sprinkling the {taco.Toppings.ToppingOneofTwo} all over the taco ");
            Console.WriteLine($"{taco.Protein.TypeOfProtein} Done");

    
            return new Shells();

        }

   
    }




}
