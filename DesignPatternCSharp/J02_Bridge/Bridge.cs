using System;
using System.Collections.Generic;
using System.Text;

namespace J02_Bridge
{
    public abstract class Abstraction
    {
        public Implementor _implementor;
        public Abstraction(Implementor implementor)
        {
            _implementor = implementor;
        }
        public abstract void Show();
    }

    public class RefinedAbstraction : Abstraction
    {
        public RefinedAbstraction(Implementor implementor) : base(implementor)
        {

        }
        public override void Show()
        {
            _implementor.Show();
        }
    }

    public interface Implementor
    {
        void Show();
    }

    public class ConcreteImplementorA : Implementor
    {
        public void Show()
        {
            Console.WriteLine("AAA");
        }
    }

    public class ConcreteImplementorB : Implementor
    {
        public void Show()
        {
            Console.WriteLine("BBB");
        }
    }

}
