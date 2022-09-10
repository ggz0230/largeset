using System;

namespace K03_Strategy
{
    class Program
    {
        static void Main(string[] args)
        {

            var sta = StrategyFactory.getStrategy("A");
            sta.algorithmInterface();


        }
    }
}
