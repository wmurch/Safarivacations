using System;
using System.Linq;

namespace SafariVacations
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = "";
            var db = new SafariVacationsContext();
            while (input != "quit")
            {

                Console.WriteLine("You want to (view), (add),(update) or (remove) Animals ...");
                Console.WriteLine(":============================================================: ");
                input = Console.ReadLine();

                if (input == "add")
                {
                    Console.WriteLine("Add the animal species, how many times you have seen it and location: ");
                    input = Console.ReadLine();

                    var data = input.Split(',');
                    var newAnimal = new Animal
                    {
                        Species = data[0],
                        CountOfTimesSeen = int.Parse(data[1]),
                        LocationOfLastSeen = data[2]
                    };
                    db.Animals.Add(newAnimal);
                    db.SaveChanges();
                    Console.WriteLine($"Successfully Saved {newAnimal.Species}");

                }
                //Update how many times you have seen animals and where
                else if (input == "update")
                {


                }
                // Display All Animals
                else if (input == "view")
                {
                    var allAnimals = db.Animals.OrderBy(o => o.Species);
                    foreach (var animal in allAnimals)
                    {
                        Console.WriteLine($"{animal.Species}, {animal.LocationOfLastSeen}");
                    }
                }
                // Remove all Animals that I have seen in the Desert
                else if (input == "remove")
                {
                    //Console.WriteLine("Type the name of the Animal you want to remove ");
                    //input = Console.ReadLine();
                    //var data = input;
                    var delAnimal = db.Animals.Where(varmint => varmint.LocationOfLastSeen == "Desert");
                    db.Animals.RemoveRange(delAnimal);
                    db.SaveChanges();
                    //Console.WriteLine("Not ready yet but working on it");
                }



                // Display all animals seen in the Jungle


                // Add all the CountOfTimeSeen and get a total number of animals seen

                // Get the CountOfTimesSeen of Lions Tigers and Bears   
            }

        }
    }
}

