using System;

namespace K01_Observer
{
    class Program
    {
        static void Main(string[] args)
        {

            ConcreteSubject subject = new ConcreteSubject();
            subject.RegisterObserver(new ConcreteObserverOne());
            subject.RegisterObserver(new ConcreteObserverTwo());
            subject.NotifyObservers("这是一条文本消息");

        }
    }
}
