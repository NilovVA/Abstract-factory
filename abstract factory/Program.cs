using System;

namespace Абстрактная_фабрика
{
    class Program
    {
        static void Main(string[] args)
        {
            Human mother = new Human(new MotherFactory());
            mother.Eat();
            mother.Drink();

            Human father = new Human(new FatherFactory());
            father.Eat();
            father.Drink();

            Console.ReadLine();
        }
    }
    abstract class Breakfast
    {
        public abstract void Eat();
    }
    abstract class Dinner
    {
        public abstract void Drink();
    }
    class egg : Breakfast
    {
        public override void Eat()
        {
            Console.WriteLine("Кушает яйца");
        }
    }
    class sandwich : Breakfast
    {
        public override void Eat()
        {
            Console.WriteLine("Кушает бутерброд");
        }
    }
    class tea : Dinner
    {
        public override void Drink()
        {
            Console.WriteLine("Пьёт чай");
        }
    }
    class coffie : Dinner
    {
        public override void Drink()
        {
            Console.WriteLine("Пьёт кофе");
        }
    }
    abstract class HumanFactory
    {
        public abstract Dinner CreateDrinking();
        public abstract Breakfast CreateEating();
    }
    class MotherFactory : HumanFactory
    {
        public override Dinner CreateDrinking()
        {
            return new tea();
        }

        public override Breakfast CreateEating()
        {
            return new egg();
        }
    }
    class FatherFactory : HumanFactory
    {
        public override Dinner CreateDrinking()
        {
            return new coffie();
        }

        public override Breakfast CreateEating()
        {
            return new sandwich();
        }
    }
    class Human
    {
        private Breakfast eating;
        private Dinner movement;
        public Human(HumanFactory factory)
        {
            eating = factory.CreateEating();
            movement = factory.CreateDrinking();
        }
        public void Drink()
        {
            movement.Drink();
        }
        public void Eat()
        {
            eating.Eat();
        }
    }
}


