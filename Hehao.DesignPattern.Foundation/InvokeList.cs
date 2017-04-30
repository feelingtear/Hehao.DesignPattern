using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hehao.DesignPattern.Foundation
{
    public delegate void StringAssignmentEventHandlers();

    public class InvokeList
    {
        private IList<StringAssignmentEventHandlers> handlers;
        private string[] message = new string[3];

        public InvokeList()
        {
            handlers = new List<StringAssignmentEventHandlers>();
            handlers.Add(AppendHello);
            handlers.Add(AppendComma);
            handlers.Add(AppendWorld);
        }

        public void Invoke()
        {
            foreach(StringAssignmentEventHandlers handler in handlers)
            {
                handler();
            }
        }

        public string this[int index]
        {
            get
            {
                return message[index];
            }
        }

        public void AppendHello()
        {
            message[0] = "hello";
        }

        public void AppendComma()
        {
            message[1] = ",";
        }
        public void AppendWorld()
        {
            message[2] = "world";
        }
    }
}
