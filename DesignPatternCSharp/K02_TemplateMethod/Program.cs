using System;

namespace K02_TemplateMethod
{
    class Program
    {
        static void Main(string[] args)
        {

            AbstractClass demo = new ConcreteClass2();
            demo.templateMethod();


        }
    }
}
