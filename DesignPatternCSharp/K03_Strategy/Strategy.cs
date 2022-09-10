using System;
using System.Collections.Generic;
using System.Text;

namespace K03_Strategy
{


    public interface IStrategy
    {
        void algorithmInterface();
    }

    public class ConcreteStrategyA : IStrategy
    {
        //  @Override
        public void algorithmInterface()
        {
            //具体的算法...
            Console.WriteLine("A");
        }
    }

    public class ConcreteStrategyB : IStrategy
    {
        //@Override
        public void algorithmInterface()
        {
            //具体的算法...
            Console.WriteLine("B");
        }
    }



    public class StrategyFactory
    {
        private static Dictionary<string, IStrategy> strategies = new Dictionary<string, IStrategy>();

        static StrategyFactory()
        {
            strategies.Add("A", new ConcreteStrategyA());
            strategies.Add("B", new ConcreteStrategyB());
        }


        public static IStrategy getStrategy(String type)
        {
            return strategies[type];
        }
    }

}
