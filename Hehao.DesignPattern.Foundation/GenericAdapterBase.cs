using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hehao.DesignPattern.Foundation
{
    public interface ITarget
    {
        void Request();
    }

    public interface IAdaptee
    {
        void SpecifiedRequest();
    }

    public abstract class GenericAdapterBase<T>:ITarget where T:IAdaptee,new ()
    {
        public virtual void Request()
        {
            new T().SpecifiedRequest();
        }
    }
}
