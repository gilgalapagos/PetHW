using System;
using System.Collections.Generic;

public enum Food
{ 
    Beef,
    Veggies,
    Fish,
    Fruit
}
namespace Pet_HW
{
    abstract class Pet
    {
        public string Name { get; private set; }

        public int Happiness { get; private set; }

        public int Hunger { get; private set; }

        public Pet(string name, int happiness)
        {
            Name = name;
            Happiness = happiness;
        }

        public abstract int Play();
        public abstract void Feed(Food food);
        public abstract void Run();

        public void Sleep()
        {
            Console.WriteLine($"Goodnight {Name}.");
            Console.ReadKey();
            IncreaseHappiness(10);
        }

        public int IncreaseHappiness(int value)
        {
            if (Happiness + value > 100) return Happiness = 100;
            else if (Happiness + value < 0) return Happiness = 0;
            else return Happiness += value;
        }

        public void DecreaseHunger(int food)
        {
            if (Hunger - food < 0) Hunger = 0;
            else Hunger -= food;
        }
    }

    class Dog : Pet
    {
        public Dog(string name) : base (name, 100)
        { }

        public override int Play()
        {
            Console.WriteLine($"You play fetch with {Name}. He really enjoys it!");
            Console.ReadKey();
            return IncreaseHappiness(50);
            
        }

        public override void Feed(Food food)
        {
            Console.WriteLine($"You feed {Name} {food}.");
            if (food == Food.Beef)
            {
                Console.WriteLine("He really enjoys it!");
                IncreaseHappiness(20);
                DecreaseHunger(50);
            }

            else if (food == Food.Fish)
            {
                Console.WriteLine("He doesn't seem to like it much.");
                IncreaseHappiness(5);
                DecreaseHunger(30);
            }

            else if (food == Food.Fruit)
            {
                Console.WriteLine("He hates it.");
                IncreaseHappiness(-20);
                DecreaseHunger(0);
            }

            else if (food == Food.Veggies)
            {
                Console.WriteLine("He dislikes it.");
                IncreaseHappiness(0);
                DecreaseHunger(10);
            }
            Console.ReadKey();
        }

        public override void Run()
        {
            Console.WriteLine($"You go for a run with {Name}. He had a great time!");
            Console.ReadKey();
            IncreaseHappiness(60);
        }
    }

    class Cat : Pet
    {
        public Cat(string name) : base(name, 10)
        { }

        public override int Play()
        {
            if (Happiness > 50)
            {
                Console.WriteLine($"You pull out a stringy toy for {Name}. He really enjoys it!");
                Console.ReadKey();
                return IncreaseHappiness(20);
            }
            else
            {
                Console.WriteLine($"{Name} is not comfortable around you and runs away");
                Console.ReadKey();
                return IncreaseHappiness(-15);
            }
            
        }

        public override void Feed(Food food)
        {
            Console.WriteLine($"You feed {Name} {food}.");
            if (food == Food.Beef)
            {
                Console.WriteLine("He really enjoys it!");
                IncreaseHappiness(15);
                DecreaseHunger(40);
            }

            else if (food == Food.Fish)
            {
                Console.WriteLine("He loves it!.");
                IncreaseHappiness(30);
                DecreaseHunger(75);
            }

            else if (food == Food.Fruit)
            {
                Console.WriteLine("He hates it.");
                IncreaseHappiness(-30);
                DecreaseHunger(0);
            }

            else if (food == Food.Veggies)
            {
                Console.WriteLine("He dislikes it.");
                IncreaseHappiness(-5);
                DecreaseHunger(10);
            }
            Console.ReadKey();
        }

        public override void Run()
        {
            if (Happiness >= 80)
            {
                Console.WriteLine($"You go for a run with {Name}. Suprisingly he had a good time.");
                IncreaseHappiness(5);
            }
            else Console.WriteLine($"{Name} doesnt seem to interested in running with you.");
            
            Console.ReadKey();            
        }
    }

    class Fish : Pet
    {
        public Fish(string name) : base(name, 100)
        { }

        public override int Play()
        {
            Console.WriteLine($"You try to play with {Name}, but nothing really happens.");
            Console.ReadKey();
            return IncreaseHappiness(0);            
        }

        public override void Feed(Food food)
        {
            Console.WriteLine($"You feed {Name} {food}.");
            if (food == Food.Beef)
            {
                Console.WriteLine("He is not satisfied.");
                IncreaseHappiness(-20);
                DecreaseHunger(10);
            }

            else if (food == Food.Fish)
            {
                Console.WriteLine("This is fine.");
                IncreaseHappiness(10);
                DecreaseHunger(25);
            }

            else if (food == Food.Fruit)
            {
                Console.WriteLine("He likes this.");
                IncreaseHappiness(10);
                DecreaseHunger(30);
            }

            else if (food == Food.Veggies)
            {
                Console.WriteLine("He thoroughly enjoys this.");
                IncreaseHappiness(25);
                DecreaseHunger(40);
            }
            Console.ReadKey();
        }

        public override void Run()
        {
            Console.WriteLine("I wouldn't do that if I were you.");
            Console.ReadKey();            
        }
    }

    class Turtle : Pet
    {
        public Turtle(string name) : base(name, 0)
        { }

        public override int Play()
        {
            Console.WriteLine($"You pick {Name} up, but he doesn't seem to enjoy it.");
            Console.ReadKey();
            return IncreaseHappiness(-20);            
        }

        public override void Feed(Food food)
        {
            Console.WriteLine($"You feed {Name} {food}.");
            if (food == Food.Beef)
            {
                Console.WriteLine("He can't eat this.");
                IncreaseHappiness(-30);
                DecreaseHunger(0);
            }

            else if (food == Food.Fish)
            {
                Console.WriteLine("He finds it okay at best.");
                IncreaseHappiness(0);
                DecreaseHunger(20);
            }

            else if (food == Food.Fruit)
            {
                Console.WriteLine("He loves this!");
                IncreaseHappiness(20);
                DecreaseHunger(50);
            }

            else if (food == Food.Veggies)
            {
                Console.WriteLine("This is his favorite!");
                IncreaseHappiness(30);
                DecreaseHunger(100);
            }
            Console.ReadKey();
        }
        public override void Run()
        {
            Console.WriteLine($"You go for a run with {Name}. This will take a while.");
            Console.ReadKey();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            List<Pet> pets = new List<Pet>();
            Console.WriteLine("How many Pets do you want?");
            int input = GetInput();
            int i = 0;
            Console.Clear();

            while (i < input)
            {
                Console.WriteLine("Select a Pet you would like.");
                Console.WriteLine("[1] Dog\n[2] Cat\n[3] Fish\n[4] Turtle");
                int selection = GetInput();
                Console.WriteLine("Enter a name");
                string name = Console.ReadLine();
                if (selection == 1) pets.Add(new Dog(name));
                else if (selection == 2) pets.Add(new Cat(name));
                else if (selection == 3) pets.Add(new Fish(name));
                else if (selection == 4) pets.Add(new Turtle(name));
                Console.Clear();
                i++;
            }

            while (true)
            {
                MainMenu(pets);
            }
        }

        static void MainMenu(List<Pet> pets)
        {
            Console.Clear();
            Console.WriteLine("Select an option.");
            Console.WriteLine("[1] Play\n[2] Feed\n[3] Run\n[4] Sleep\n[5] Quit");
            int input = GetInput();

            if (input == 1)
            {
                Console.WriteLine("You selected Play");
                PlayMenu(pets);
            }
            else if (input == 2)
            {
                Console.WriteLine("You selected Feed");
                FeedMenu(pets);
            }
            else if (input == 3)
            {
                Console.WriteLine("You selected Run");
                RunMenu(pets);
            }
            else if (input == 4)
            {
                Console.WriteLine("You selected Sleep");
                SleepMenu(pets);
            }
            else
                Environment.Exit(0);
               
        }

        static void PlayMenu (List<Pet> pets)
        {
            Console.Clear();
            Console.WriteLine("Who would you like to play with?");
            Pet pet =  PickPet(pets);
            pet.Play();
        }

        static void FeedMenu (List<Pet> pets)
        {
            Console.Clear();
            Console.WriteLine("Who would you like to feed?");
            Pet pet =  PickPet(pets);
            Console.WriteLine($"What would you like to feed {pet.Name}?");
            Food food = FoodPicker();
            pet.Feed(food);
        }

        static void RunMenu (List<Pet> pets)
        {
            Console.Clear();
            Console.WriteLine("Who would you like to send for a run?");
            Pet pet =  PickPet(pets);
            pet.Run();
        }

        static void SleepMenu (List<Pet> pets)
        {
            Console.Clear();
            Console.WriteLine("Who would you like to send to bed?");
            Pet pet = PickPet(pets);
            pet.Sleep();

        }

        static Pet PickPet(List<Pet> pets)
        {
            Console.Clear();
            Console.WriteLine("Select a Pet");
            int i = 1;
            foreach (Pet pet in pets)
            {
                Console.WriteLine($"[{i}] {pet.Name}");
                i++;
            }
            int selection = GetInput();
            return pets[selection - 1];
        }

        static Food FoodPicker()
        {
            int i = 1;
            foreach (Food food in Enum.GetValues(typeof(Food)))
            {
                Console.WriteLine($"[{i}] {food}");
                i++;
            }
            var input = GetInput();
            if (input == 1) return Food.Beef;
            else if (input == 2) return Food.Veggies;
            else if (input == 3) return Food.Fish;
            else if (input == 4) return Food.Fruit;
            else return Food.Beef;
        }
        
        static int GetInput()
        {
            Console.Write("> ");
            return int.Parse(Console.ReadLine());
        }
    }
}
