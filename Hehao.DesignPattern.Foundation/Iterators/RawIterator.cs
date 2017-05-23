using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hehao.DesignPattern.Foundation.Iterators
{
    public class RawIterator
    {
        private int[] data = new int[] { 0,1,2,3,4};

        public IEnumerator GetEnumerator()
        {
            foreach(int item in data)
            {
                yield return item;
            }
        }

        public IEnumerable GetRange(int start,int end)
        {
            for(int i=start;i<=end;++i)
            {
                yield return data[i];
            }
        }

        public IEnumerable<String> Greeting
        {
            get
            {
                yield return "hello";
                yield return "world";
                yield return "!";
            }
        }
    }
}
