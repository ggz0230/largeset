using System;
using System.Collections.Generic;
using System.Text;

namespace J01_Proxy
{
    // 代理模式的代码结构(下面的接口也可以替换成抽象类)
    public interface IA
    {
        void f();
    }
    public class A : IA
    {
        public void f() 
        { 
        }
    }

    public class AProxy : IA
    {
        private IA a;
        public AProxy(IA a)
        {
            this.a = a;
        }

        public void f()
        {
            // 新添加的代理逻辑
            a.f();
            // 新添加的代理逻辑
        }
    }

}
