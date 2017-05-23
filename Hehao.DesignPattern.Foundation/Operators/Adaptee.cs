using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hehao.DesignPattern.Foundation.Operators
{
    public class Adaptee
    {
        public int Code
        {
            get
            {
                return new Random().Next();
            }
        }
    }

    public class Target
    {
        private int data;

        public Target(int data)
        {
            this.data = data;
        }

        public int Data
        {
            get
            {
                return data;
            }
        }

        public static implicit operator Target(Adaptee adaptee)
        {
            return new Target(adaptee.Code);
        }
    }
}
