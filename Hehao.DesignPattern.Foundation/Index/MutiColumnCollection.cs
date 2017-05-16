using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hehao.DesignPattern.Foundation.Index
{
    public class MutiColumnCollection
    {
        private static DataSet data = new DataSet();
         static MutiColumnCollection()
        {
            data.Tables.Add("Data");
            data.Tables[0].Columns.Add("name");
            data.Tables[0].Columns.Add("gender");
            data.Tables[0].Rows.Add(new string[] { "joe","male"});
            data.Tables[0].Rows.Add(new string[] { "alice", "female" });
        }

        public static DataSet Data
        {
            get
            {
                return data;
            }
        }
    }

}
