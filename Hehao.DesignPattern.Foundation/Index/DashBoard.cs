using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hehao.DesignPattern.Foundation.Index
{
    public class DashBoard
    {
        float[] temps = new float[10]
        {
            56.2F,56.7f,56.5f,56.9f,58.8f,61.3f,65.9f,62.1f,59.2f,57.5f
        };

        public float this[Predicate<float> predicate]
        {
            get
            {
                float[] matches = Array.FindAll<float>(temps, predicate);
                return matches[0];
            }
        }
    }
}
