using System;
using System.Collections.Generic;
using System.Text;

namespace K01_Observer
{

    public interface ISubject
    {
        void RegisterObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
        void NotifyObservers(string message);
    }

    public interface IObserver
    {
        void Update(string message);
    }

    public class ConcreteSubject : ISubject
    {
        private readonly List<IObserver> observers = new List<IObserver>();


        public void RegisterObserver(IObserver observer)
        {
            observers.Add(observer);
        }


        public void RemoveObserver(IObserver observer)
        {
            observers.Remove(observer);
        }


        public void NotifyObservers(string message)
        {
            foreach (IObserver observer in observers)
            {
                observer.Update(message);
            }
        }

    }

    public class ConcreteObserverOne : IObserver
    {
        public void Update(string message)
        {
            //TODO: 获取消息通知，执行自己的逻辑...
            Console.WriteLine("ConcreteObserverOne is notified.");
        }
    }

    public class ConcreteObserverTwo : IObserver
    {
        public void Update(string message)
        {
            //TODO: 获取消息通知，执行自己的逻辑...
            Console.WriteLine("ConcreteObserverTwo is notified.");
        }
    }




}
