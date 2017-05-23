using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hehao.DesignPattern.Foundation.IOC
{
    public class Assembler
    {
        private static Dictionary<Type, Type> dictionary = new Dictionary<Type, Type>();

        static Assembler()
        {
            dictionary.Add(typeof(ITimeProvider), typeof(TimeProvider));
        }

        public object Create(Type type)
        {
            if ((type == null) || !dictionary.ContainsKey(type)) throw new NullReferenceException();

            Type targetType = dictionary[type];
            return Activator.CreateInstance(targetType); 
        }


        public T Create<T>()
        {
            return (T)Create(typeof(T));
        }
    }
}
