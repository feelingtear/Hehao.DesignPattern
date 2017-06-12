using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hehao.DesignPattern.Foundation
{
    public interface IObjectBuilder
    {
        T BuildUp<T>(object[] args);

        T BuildUp<T>() where T:new();

        T BuildUp<T>(string typename);

        T BuildUp<T>(string typename, object[] args);
    }
}
