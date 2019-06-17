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

                Console.WriteLine("You want to (view), (add),(update),(count), or (remove) Animals ...");
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
                    Console.WriteLine("Which record would you like to update your sightings? : ");
                    input = Console.ReadLine();

                    var data = input;
                    var updateAnimal = db.Animals.FirstOrDefault(fd => fd.Species == data);
                    if (updateAnimal != null)
                    {
                        Console.WriteLine("Please enter the updated numbers of sightings: ");
                        input = Console.ReadLine();

                        var seenData = int.Parse(input);
                        updateAnimal.CountOfTimesSeen = seenData;
                        Console.WriteLine($"{updateAnimal.Species},{updateAnimal.CountOfTimesSeen}, {updateAnimal.LocationOfLastSeen}");

                    }

                }
                // Display All Animals
                else if (input == "view")
                // Display all animals seen in the Jungle
                {
                    Console.WriteLine("If you want to view all animals type (all) if you want to see an animal by location type (desert),(forest) or (jungle) ty : ");
                    input = Console.ReadLine();
                    if (input == "all")
                    {
                        var allAnimals = db.Animals.OrderBy(o => o.Species);
                        foreach (var animal in allAnimals)
                            Console.WriteLine($"{animal.Species},{animal.CountOfTimesSeen}, {animal.LocationOfLastSeen}");
                    }
                    else if (input == "desert")
                    {
                        var allAnimals = db.Animals.OrderBy(o => o.Species);
                        foreach (var animal in allAnimals)
                        {
                            if (animal.LocationOfLastSeen == "desert")
                            {
                                Console.WriteLine($"{animal.Species},{animal.CountOfTimesSeen}, {animal.LocationOfLastSeen}");
                            }
                        }

                    }
                    else if (input == "forest")
                    {
                        var allAnimals = db.Animals.OrderBy(o => o.Species);
                        foreach (var animal in allAnimals)
                        {
                            if (animal.LocationOfLastSeen == "forest")
                            {
                                Console.WriteLine($"{animal.Species},{animal.CountOfTimesSeen}, {animal.LocationOfLastSeen}");
                            }
                        }

                    }
                    else if (input == "jungle")
                    {
                        var allAnimals = db.Animals.OrderBy(o => o.Species);
                        foreach (var animal in allAnimals)
                        {
                            if (animal.LocationOfLastSeen == "desert")
                            {
                                Console.WriteLine($"{animal.Species},{animal.CountOfTimesSeen}, {animal.LocationOfLastSeen}");
                            }
                        }

                    }
                }
                // Remove all Animals that I have seen in the Desert
                else if (input == "remove")
                {
                    Console.WriteLine("Remove all animals from a location type (desert),(forest) or (jungle):  ");
                    input = Console.ReadLine();
                    var data = input;
                    if (input == "desert")
                    {
                        var delAnimal = db.Animals.Where(varmint => varmint.LocationOfLastSeen == "desert");
                        db.Animals.RemoveRange(delAnimal);
                        db.SaveChanges();
                    }
                    else if (input == "forest")
                    {
                        var delAnimal = db.Animals.Where(varmint => varmint.LocationOfLastSeen == "forest");
                        db.Animals.RemoveRange(delAnimal);
                        db.SaveChanges();
                    }
                    else if (input == "jungle")
                    {
                        var delAnimal = db.Animals.Where(varmint => varmint.LocationOfLastSeen == "jungle");
                        db.Animals.RemoveRange(delAnimal);
                        db.SaveChanges();
                    }

                    //Console.WriteLine("Not ready yet but working on it");
                }
                else if (input == "count")
                {
                    // Get the CountOfTimesSeen of Lions Tigers and Bears   
                    Console.WriteLine("To get sum of all animals seen type (total) but if you only want the total of Lions, Tiger and Bears type (ohmy)  :  ");
                    input = Console.ReadLine();
                    var data = input;

                    // Add all the CountOfTimeSeen and get a total number of animals seen
                    if (input == "total")
                    {
                        var countAnimals = db.Animals.Sum(num => num.CountOfTimesSeen);
                        Console.WriteLine($"The sum for all sightings are {countAnimals}");

                    }
                    else if (input == "ohmy")
                    {
                        //var allAnimals = db.Animals.OrderBy(o => o.Species);
                        var countAnimals = db.Animals.Where(w => w.Species == "Tiger" || w.Species == "lion" || w.Species == "bear").Sum(num => num.CountOfTimesSeen);
                        Console.WriteLine($"Hey Dorothy you only have to deal with {countAnimals} dangerous animals on the yellow brick road");
                    }

                }


            }

        }

    }
}


