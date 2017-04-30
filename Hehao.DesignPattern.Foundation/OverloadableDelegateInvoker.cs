using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hehao.DesignPattern.Foundation
{
    public delegate void MemoHandler(int x, int y, IDictionary<string, int> data);

    public class OverloadableDelegateInvoker
    {
        private MemoHandler handler;

        public OverloadableDelegateInvoker()
        {
            Type type = typeof(MemoHandler);
            Delegate d = Delegate.CreateDelegate(type, new C1(), "A");

            d = Delegate.Combine(d,Delegate.CreateDelegate(type, new C2(), "S"));
            d = Delegate.Combine(d, Delegate.CreateDelegate(type, new C3(), "M"));
            handler = (MemoHandler)d;
        }

        public void Memo(int x,int y,IDictionary<string,int> data)
        {
            handler(x, y, data);
        }
    }

    public class C1
    {
        public void A(int x,int y, IDictionary<string, int> data)
        {
            data["A"]= x + y;
        }
    }

    public class C2
    {
        public void S(int x, int y, IDictionary<string, int> data)
        {
            data["S"] = x - y;
        }
    }
    public class C3
    {
        public void M(int x, int y, IDictionary<string, int> data)
        {
            data["M"] = x * y;
        }
    }
}
