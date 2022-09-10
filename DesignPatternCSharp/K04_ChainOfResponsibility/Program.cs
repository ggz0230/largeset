using K04_ChainOfResponsibility.ChainOfResponsibility1;
using System;

namespace K04_ChainOfResponsibility
{
    class Program
    {
        static void Main(string[] args)
        {

            HandlerChain chain = new HandlerChain();
            chain.AddHandler(new HandlerA());
            chain.AddHandler(new HandlerB());
            chain.Handle();



        }
    }
}
