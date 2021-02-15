using System;

namespace AIE_30_AnimalInheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            Dog dog = new Dog();
            Cat cat = new Cat();
            Bird bird = new Bird();

            Person bob = new Person();
            bob.FeedAnimal(dog);    // What should be written to console?
            bob.FeedAnimal(cat);    // What should be written to console?
            bob.FeedAnimal(bird);   // What should be written to console?
            bob.FeedAnimal(bob);
        }
    }
    class Person : Animal
    {
        public Person() : base("Person")
        {
        }
        public void FeedAnimal(Animal animal)
        {
            animal.EatFood();
        }
    }

    class Animal
    {
        public string name = "";

        // Constructor
        public Animal(string name)
        {
            this.name = name;
        }

        public virtual void MakeNoise()
        {
            Console.WriteLine(name + ": makes noise");
        }

        // Added the EatFood method
        public virtual void EatFood()
        {
            MakeNoise();
        }
    }

    class Dog : Animal
    {
        public Dog() : base("Dog")
        {
        }
        public override void MakeNoise()
        {
            Console.WriteLine("WOOF WOOF WOOF");
            // base.MakeNoise(); // calls the Animal.MakeNoise method
        }
    }

    class Cat : Animal
    {
        // Cat constructor
        public Cat() : base("Cat")
        {
        }
    }

    class Bird : Animal
    {
        // Bird constructor
        public Bird() : base("Bird")
        {
        }
    }
}
