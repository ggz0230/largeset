using System;
using System.Collections.Generic;
using System.Text;

namespace Test.ClassAdapter
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

    public class Adaptor : Adaptee, ITarget
    {
        public void f1()
        {
            base.fa();
        }

        public void f2()
        {
            base.fb();
        }

        public void f3()
        {
            base.fc();
        }
    }

}
