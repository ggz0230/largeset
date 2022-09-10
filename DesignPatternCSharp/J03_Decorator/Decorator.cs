using System;
using System.Collections.Generic;
using System.Text;

namespace J03_Decorator
{
    // 装饰器模式的代码结构(下面的接口也可以替换成抽象类)
    public interface IA
    {
        void f();
    }
    public class A : IA
    {
        public void f()
        { //... 
        }
    }
    public class ADecorator : IA
    {
        private IA a;
        public ADecorator(IA a)
        {
            this.a = a;
        }

        public void f()
        {
            // 功能增强代码
            a.f();
            // 功能增强代码
        }
    }


}
