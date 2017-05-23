using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace Hehao.DesignPattern.Foundation.Iterators
{
    public class CompositeIterator
    {
        private IDictionary<object, IEnumerator> items = new Dictionary<object, IEnumerator>();

        public void Add(object data)
        {
            items.Add(data, GetEnumerator(data));
        }

        public IEnumerator GetEnumerator()
        {
            if(items!=null && (items.Count >0))
            {
                foreach(IEnumerator item in items.Values)
                {
                    while(item.MoveNext())
                    {
                        yield return item.Current;
                    }
                }
            }
        }

        public static IEnumerator GetEnumerator(object data)
        {
            if (data == null) throw new NullReferenceException();

            Type type = data.GetType();
            //是否是stack
            if (type.IsAssignableFrom(typeof(Stack))
                || type.IsAssignableFrom(typeof(Stack<ObjectWithName>)))
            {
                return DynamicInvokeEnumerator(data);
            }
            //是否是queue
            if(type.IsAssignableFrom(typeof(Queue))
                || type.IsAssignableFrom(typeof(Queue<ObjectWithName>)))
            {
                return DynamicInvokeEnumerator(data);
            }

            //Array
            if((type.IsArray) && (type.GetElementType().IsAssignableFrom(typeof(ObjectWithName))))
            {
                return ((ObjectWithName[])data).GetEnumerator();
            }
            //binary tree
            if(type.IsAssignableFrom(typeof(BinaryTreeNode)))
            {
                return ((BinaryTreeNode)data).GetEnumerator();
            }
                

            throw new NotSupportedException();
        }

        private static IEnumerator DynamicInvokeEnumerator(object data)
        {
            if (data == null) throw new NullReferenceException();
            Type type = data.GetType();
            return (IEnumerator)type.InvokeMember("GetEnumerator"
                , BindingFlags.InvokeMethod, null, data, null);
        }
    }
}
