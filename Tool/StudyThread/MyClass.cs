
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyThread
{
    /// <summary>
    /// 单例模式 双检锁
    /// </summary>
    public class MyClass
    {
        private MyClass() { }

        private static object _obj = new object();

        private static MyClass _myClass;

        public static MyClass GetMyClass()
        {
            if (_myClass == null)
            {
                
                lock (_obj)
                {
                    if (_myClass == null)
                    {
                        _myClass = new MyClass();
                    }
                }
            }
            return _myClass;
        }

    }

}
