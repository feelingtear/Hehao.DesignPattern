using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hehao.DesignPattern.Foundation.Attributes
{
    [AttributeUsage(AttributeTargets.Class,AllowMultiple =true)]
    public sealed class DirectorAttribute:Attribute,IComparable<DirectorAttribute>
    {
        private int priority;
        private string method;

        public DirectorAttribute(int priority,string method)
        {
            this.priority = priority;
            this.method = method;
        }

        public int Priority
        {
            get
            {
                return this.priority;
            }
        }

        public string Method
        {
            get
            {
                return this.method;
            }
        }

        public int CompareTo(DirectorAttribute attribute)
        {
            return attribute.priority - this.priority;
        }
    }

    public class Director
    {
        public void BuildUp(IAttributedBuilder builder)
        {
            object[] attributes = builder.GetType().GetCustomAttributes(typeof(DirectorAttribute), false);
            if (attributes.Length <= 0) return;
            DirectorAttribute[] directors = new DirectorAttribute[attributes.Length];
            for (int i= 0;i< attributes.Length;++i)
            {
                directors[i] = (DirectorAttribute)attributes[i];
            }
            Array.Sort<DirectorAttribute>(directors);
            foreach(DirectorAttribute attribute in directors)
            {
                InvokeBuldPartMethod(builder, attribute);
            }
        }

        private void InvokeBuldPartMethod(IAttributedBuilder builder,DirectorAttribute attribute)
        {
            switch(attribute.Method)
            {
                case "BuildPartA":
                    builder.BuildPartA();
                    break;
                case "BuildPartB":
                    builder.BuildPartB();
                    break;
                case "BuildPartC":
                    builder.BuildPartC();
                    break;
                default:
                    break;
            }
        }
    }
}
