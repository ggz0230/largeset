using System;
using System.Collections.Generic;
using System.Text;

namespace K02_TemplateMethod
{
    public abstract class AbstractClass
    {
        public void templateMethod()
        {
            //...
            method1();
            //...
            method2();
            //...
        }

        protected abstract void method1();
        protected abstract void method2();
    }

    public class ConcreteClass1 : AbstractClass
    {

        protected override void method1()
        {
            Console.WriteLine("ConcreteClass1 method1");
        }


        protected override void method2()
        {
            Console.WriteLine("ConcreteClass1 method2");
        }
    }

    public class ConcreteClass2 : AbstractClass
    {
        protected override void method1()
        {
            Console.WriteLine("ConcreteClass2 method1");
        }


        protected override void method2()
        {
            Console.WriteLine("ConcreteClass2 method2");
        }
    }




}
