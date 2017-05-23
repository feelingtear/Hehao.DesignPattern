using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hehao.DesignPattern.Foundation.Iterators
{
     public class ObjectWithName
    {
        private string name;
        public ObjectWithName(string name)
        {
            this.name = name;
        }
        public override string ToString()
        {
            return name;
        }
    }
}
