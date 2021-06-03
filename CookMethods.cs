using MyTacoTruck.Ingredients;
using MyTacoTruck.Tacos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTacoTruck
{
    class CookMethods
    {

       
        public static async Task<Shells> HeatShellsAsync(TacoBase taco)
        {

            
            Console.WriteLine($"Warming the pan for {taco.Amount} {taco.ShellType.Hardness} {taco.ShellType.Style} {(taco.Amount == 1 ? "shell" : "shells")}");
            await Task.Delay(3000);
            Console.WriteLine($"{taco.ShellType.Hardness} {taco.ShellType.Style} Shells in the pan");
            await Task.Delay(4000);


            return new Shells();

            // need to make an if else for if the hells are hard, they should not go in a paan, they should go in the oven
        }



        public static async Task<Toppings> PrepareToppingsAsync(TacoBase taco) // need to label this async
        {
            if (taco is AmericanTaco)
            {
                Console.WriteLine($"Grating and Measuring the {taco.Toppings.ToppingOneofTwo} for {taco.Amount} {taco.Protein.TypeOfProtein} {(taco.Amount == 1 ? "taco" : "tacos")}");
                Console.WriteLine($"Making sure the {taco.Toppings.ToppingTwoOfTwo} is nice and spicy");
                await Task.Delay(5000);
               
                await Task.Delay(2000);


                return new Toppings();
            }
            else
            {
                Console.WriteLine($"Heating up the wok for the {taco.Toppings.ToppingOneofTwo} for {taco.Amount} {(taco.Amount ==1? "taco": "tacos")}");
                Console.WriteLine($"Preparing the perfect amount of {taco.Toppings.ToppingTwoOfTwo}");
                await Task.Delay(2000);
                Console.WriteLine($"{taco.Toppings.ToppingOneofTwo} in the wok");
                await Task.Delay(5000);


                return new Toppings();
            }

        }





        public static async Task<Protein> CookProteinAsync(TacoBase taco)  // need to labal this async
        {
            Console.WriteLine($"Heating up the skillet for the {taco.Amount} {taco.Protein.TypeOfProtein} {(taco.Amount == 1 ? "taco" : "tacos")} ");
            await Task.Delay(2000);
            Console.WriteLine($"{taco.Protein.TypeOfProtein} in the skillet");
            await Task.Delay(5000);


            return new Protein();
        }




    }
}
