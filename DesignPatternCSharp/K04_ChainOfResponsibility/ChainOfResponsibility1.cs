using System;
using System.Collections.Generic;
using System.Text;

namespace K04_ChainOfResponsibility.ChainOfResponsibility1
{
    //第一种方式的 责任链模式 代码
    public abstract class Handler
    {
        protected Handler successor = null;

        public void SetSuccessor(Handler successor)
        {
            this.successor = successor;
        }

        public void Handle()
        {
            bool handled = DoHandle();
            if (successor != null && !handled)
            {
                successor.Handle();
            }
        }

        protected abstract bool DoHandle();
    }

    public class HandlerA : Handler
    {
        protected override bool DoHandle()
        {
            bool handled = false;
            //...
            return handled;
        }
    }

    public class HandlerB : Handler
    {
        protected override bool DoHandle()
        {
            bool handled = false;
            //...
            return handled;
        }
    }

    // HandlerChain和Application代码不变




    public class HandlerChain
    {
        private Handler head = null;
        private Handler tail = null;

        public void AddHandler(Handler handler)
        {
            handler.SetSuccessor(null);

            if (head == null)
            {
                head = handler;
                tail = handler;
                return;
            }

            tail.SetSuccessor(handler);
            tail = handler;
        }

        public void Handle()
        {
            if (head != null)
            {
                head.Handle();
            }
        }
    }



}
