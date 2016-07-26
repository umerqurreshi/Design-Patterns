using System;

namespace FactoryDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i <= 3; i++)
            {
                var position = Factory.Get(i);
                Console.WriteLine("Where id = {0}, position = {1} ", i, position.Title);
            }
        }
    }

    // 1. Create abstract base class
    abstract class Position
    {
        public abstract string Title { get; }
    }

    // 2. Get classes to inherit from abstract base class
    class Manager : Position
    {
        public override string Title
        {
            get
            {
                return "Manager";
            }
        }
    }

    class Clerk : Position
    {
        public override string Title
        {
            get
            {
                return "Clerk";
            }
        }
    }

    class Programmer : Position
    {
        public override string Title
        {
            get
            {
                return "Programmer";
            }
        }
    }

    static class Factory
    {
        /// <summary>
        /// Decides which class to instantiate.
        /// </summary>
        public static Position Get(int id)
        {
            switch (id)
            {
                case 0:
                    return new Manager(); // example of Polymorphism Position p = new Manager();s
                case 1:
                case 2:
                    return new Clerk(); // example of Polymorphism
                case 3:
                default:
                    return new Programmer(); // example of Polymorphism
            }
        }
    }
}
