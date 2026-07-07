using System;
using System.Collections.Generic;

namespace AnimalManagementProgram
{
    class Animal
    {
        public string animalname;
        public int speed;

        public Animal(string name, int speed)
        {
            this.animalname = name;
            this.speed = speed;
        }

        public virtual void Move()
        {
            Console.WriteLine("No movement");
        }
        public virtual void PerformSpecialAction()
        {
            Console.WriteLine("");
        }
    }

    class Cat : Animal
    {
        private int height;

        public Cat(string name, int speed, int height) : base(name, speed)
        {
            this.height = height;
        }

        public override void Move()
        {
            Console.WriteLine($"Cat named {animalname} runs at speed {speed}");
        }

        public override void PerformSpecialAction()
        {
            Console.WriteLine($"Cat jumps at speed {height}");
        }
    }

    class Fish : Animal
    {
        private int number;
        public Fish(string name, int speed, int number) : base(name, speed)
        {
            this.number = number;
        }
        public override void Move()
        {
            Console.WriteLine($"Fish named {animalname} swims at  speed {speed}");
        }
        public override void PerformSpecialAction()
        {
            Console.WriteLine($"Fish dive {number} times.");
        }
    }

    class Bird : Animal
    {
        int high;
        public Bird(string name, int speed, int high) : base(name, speed)
        {
            this.high = high;
        }
        public override void Move()
        {
            Console.WriteLine($"Bird named {animalname} flies at speed {speed}");
        }
        public override void PerformSpecialAction()
        {
            Console.WriteLine($"Bird flies {high} higher");
        }
    }

    class Dog : Animal
    {
        int bark;
        public Dog(string name, int speed, int bark) : base(name, speed)
        {
            this.bark = bark;
        }
        public override void Move()
        {
            Console.WriteLine($"Dog named {animalname} runs at speed {speed}");
        }
        public override void PerformSpecialAction()
        {
            Console.WriteLine($"Dog barks {bark} times");
        }
    }

    internal class Program
    {
        static List<Animal> animals = new List<Animal>();
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Welcome to the Animal Movement Program!");
                Console.WriteLine("1. Create an animal");
                Console.WriteLine("2. Show Animals");
                Console.WriteLine("3. Move animal");
                Console.WriteLine("4. Move all animals");
                Console.WriteLine("5. Remove animal");
                Console.WriteLine("6. Exit program");

                int input;
                do
                {
                    Console.WriteLine("Please select an option (1, 2, 3,..): ");
                }
                while (!int.TryParse(Console.ReadLine(), out input) || input < 1 || input > 6);
                if (input == 1)
                {
                    CreateAnimal();
                }
                else if (input == 2)
                {
                    ShowAnimals();
                }
                else if (input == 3)
                {
                    MoveAnimal();
                }
                else if (input == 4)
                {
                    MoveAnimals();
                }
                else if (input == 5)
                {
                    RemoveAnimal();
                }
                else
                {
                    Console.WriteLine("Existing the program.");
                    return;
                }
            }

            static void CreateAnimal()
            {
                string type;
                do
                {
                    Console.WriteLine("Pick an animal type (cat, fish, bird, dog) or q to quit: ");
                    type = Console.ReadLine().ToLower();
                    if (string.IsNullOrWhiteSpace(type))
                    {
                        Console.WriteLine("Invalid input.");
                        continue;
                    }

                    if (type == "cat" || type == "fish" || type == "bird" || type == "dog")
                    {
                        string name;
                        do
                        {
                            Console.WriteLine("Enter the name of the animal: ");
                            name = Console.ReadLine();
                        }
                        while (string.IsNullOrWhiteSpace(name));
                        Console.WriteLine("Enter the speed of the animal: ");
                        int speed;
                        while (!int.TryParse(Console.ReadLine(), out speed))
                        {
                            Console.WriteLine("Invalid input. Please enter a valid integer for speed.");
                        }
                        switch (type)
                        {
                            case "cat":
                                Console.WriteLine("Enter the height of the jump: ");
                                int height;
                                while (!int.TryParse(Console.ReadLine(), out height))
                                {
                                    Console.WriteLine("Invalid input. Please enter a valid integer for height.");
                                }
                                Cat cat = new Cat(name, speed, height);
                                animals.Add(cat);
                                continue;

                            case "fish":
                                Console.WriteLine("Enter the number of dives: ");
                                int number;
                                while (!int.TryParse(Console.ReadLine(), out number))
                                {
                                    Console.WriteLine("Invalid input. Please enter a valid integer for number.");
                                }
                                Fish fish = new Fish(name, speed, number);
                                animals.Add(fish);
                                continue;

                            case "bird":
                                Console.WriteLine("Enter how high the fly: ");
                                int high;
                                while (!int.TryParse(Console.ReadLine(), out high))
                                {
                                    Console.WriteLine("Invalid input. Please enter a valid integer for high.");
                                }
                                Bird bird = new Bird(name, speed, high);
                                animals.Add(bird);
                                continue;

                            case "dog":
                                Console.WriteLine("Enter how many bark: ");
                                int bark;
                                while (!int.TryParse(Console.ReadLine(), out bark))
                                {
                                    Console.WriteLine("Invalid input. Please enter a valid integer for bark.");
                                }
                                Dog dog = new Dog(name, speed, bark);
                                animals.Add(dog);
                                continue;
                            case "p":
                                break;
                        }

                    }
                }
                while (type != "q");
            }

            static void MoveAnimal()
            {
                ShowAnimals();
                Console.WriteLine("Please select an animal from the list (1,2,3,..): ");
                int input;
                while (!int.TryParse(Console.ReadLine(), out input) || input < 1)
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer for animal move.");
                }
                for (int i = 0; i < animals.Count; i++)
                {
                    if (i + 1 == input)
                    {
                        animals[i].Move();
                        animals[i].PerformSpecialAction();
                    }
                }
            }
            static void MoveAnimals()
            {
                if (animals.Count == 0)
                {
                    Console.WriteLine("No animals to move. Please create an animal first.");
                    return;
                }

                string command;
                do
                {
                    Console.WriteLine("Type 'move' to move all animals or 'q' to quit: ");
                    command = Console.ReadLine().ToLower();
                }
                while (command != "move" && command != "q" && string.IsNullOrWhiteSpace(command));

                if (command == "move")
                {
                    foreach (Animal a in animals)
                    {
                        a.Move();
                        a.PerformSpecialAction();
                    }
                }
                else
                {
                    return;
                }

            }

            static void ShowAnimals()
            {
                if (animals.Count == 0)
                {
                    Console.WriteLine("No animals to show. Please create an animal first.");
                    return;
                }
                Console.WriteLine("List of animals:");
                for (int i = 0; i < animals.Count; i++)
                {
                    Console.WriteLine($"Animal: {i + 1}. {animals[i].GetType().Name}, Name: {animals[i].animalname}, Speed: {animals[i].speed}");
                }
                Console.WriteLine("Count of animals: " + animals.Count);

            }

            static void RemoveAnimal()
            {
                ShowAnimals();
                if (animals.Count > 0)
                {
                    Console.WriteLine("Please select an animal to remove from the list (1,2,3,..): ");
                    int forremove;
                    while (!int.TryParse(Console.ReadLine(), out forremove) || forremove < 1)
                    {
                        Console.WriteLine("Invalid input. Please enter a valid integer for animal remove.");
                    }
                    for (int i = 0; i < animals.Count; i++)
                    {
                        if (i + 1 == forremove)
                        {
                            animals.RemoveAt(i);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("There is no animal in the list anymore. Please create an animal first.");
                }

            }
        }
    }
}