using System;

namespace J02_Bridge
{
    class Program
    {
        static void Main(string[] args)
        {

            RefinedAbstraction abstraction = new RefinedAbstraction(new ConcreteImplementorA());
            abstraction.Show();

            RefinedAbstraction abstractionB = new RefinedAbstraction(new ConcreteImplementorB());
            abstractionB.Show();


            Console.ReadKey();

        }
    }
}
