namespace J04_Adapter.ObjectAdapter
{
    // 对象适配器：基于组合

    public interface ITarget
    {
        void f1();
        void f2();
        void fc();
    }

    public class Adaptee
    {
        public void fa()
        { //...
        }
        public void fb()
        { //... 
        }
        public void fc()
        { //...
        }
    }

    public class Adaptor : ITarget
    {
        private Adaptee adaptee;

        public Adaptor(Adaptee adaptee)
        {
            this.adaptee = adaptee;
        }

        public void f1()
        {
            adaptee.fa(); //委托给Adaptee
        }

        public void f2()
        {
            adaptee.fb();
            //...重新实现f2()...
        }

        public void fc()
        {
            adaptee.fc();
        }
    }


}
