﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hehao.DesignPattern.Foundation.IOC
{
    interface ITimeProvider
    {
        DateTime CurrentDate
        {
            get;
        }
    }

    public class TimeProvider : ITimeProvider
    {
        public DateTime CurrentDate
        {
            get
            {
                return DateTime.Now;
            }
        }
    }
}
