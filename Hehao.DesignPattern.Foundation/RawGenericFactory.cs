﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hehao.DesignPattern.Foundation
{
    public static class RawGenericFactory
    {
        public static T Create<T>(string typeName)
        {
            return (T)Activator.CreateInstance(Type.GetType(typeName));
        }
    }
}
