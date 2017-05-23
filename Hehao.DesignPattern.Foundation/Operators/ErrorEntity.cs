using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hehao.DesignPattern.Foundation.Operators
{
    public class ErrorEntity
    {
        private IList<string> messages = new List<string>();
        private IList<int> codes = new List<int>();

        public static ErrorEntity operator +(ErrorEntity entity,string message)
        {
            entity.messages.Add(message);
            return entity;
        }

        public static ErrorEntity operator +(ErrorEntity entity,int code)
        {
            entity.codes.Add(code);
            return entity;
        }

        public IList<string> Messages
        {
            get
            {
                return messages;
            }
        }

        public IList<int> Codes
        {
            get
            {
                return codes;
            }
        }
    }
}
