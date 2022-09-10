using System;
using System.Collections.Generic;
using System.Text;

namespace Test.ObjectAdapter
{
    //  ITarget  Adaptee   Adaptor
    public interface ITarget
    {
        void f1();
        void f2();
        void f3();
    }

    public class Adaptee
    {
        public void fa() { }
        public void fb() { }
        public void fc() { }
    }

    public class Adaptor:ITarget
    {
        private Adaptee _adaptee;
        public Adaptor(Adaptee adaptee)
        {
            _adaptee = adaptee;
        }

        public void f1()
        {
            _adaptee.fa();
        }

        public void f2()
        {
            _adaptee.fb();
        }

        public void f3()
        {
            _adaptee.fc();
        }
    }


}
