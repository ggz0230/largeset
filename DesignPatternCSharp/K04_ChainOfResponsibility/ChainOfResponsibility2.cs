using System;
using System.Collections.Generic;
using System.Text;

namespace K04_ChainOfResponsibility.ChainOfResponsibility2
{
    //第二种方式的 责任链模式 代码  更简单

    public interface IHandler
    {
        bool Handle();
    }

    public class HandlerA : IHandler
    {

        public bool Handle()
        {
            bool handled = false;
            //...
            return handled;
        }
    }

    public class HandlerB : IHandler
    {

        public bool Handle()
        {
            bool handled = false;
            //...
            return handled;
        }
    }

    public class HandlerChain
    {
        private readonly List<IHandler> handlers = new List<IHandler>();

        public void AddHandler(IHandler handler)
        {
            this.handlers.Add(handler);
        }

        public void Handle()
        {
            foreach (IHandler handler in handlers)
            {
                bool handled = handler.Handle();
                if (handled)
                {
                    break;
                }
            }
        }
    }

    // 使用举例
    public class Application
    {
        public static void Show()
        {
            HandlerChain chain = new HandlerChain();
            chain.AddHandler(new HandlerA());
            chain.AddHandler(new HandlerB());
            chain.Handle();
        }
    }

}
