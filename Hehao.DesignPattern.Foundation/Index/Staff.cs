using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hehao.DesignPattern.Foundation.Index
{
    public struct Employee
    {
        public string FirstName;
        public string FamilyName;
        public string Title;

        public Employee(DataRow row)
        {
            this.FirstName = row["FirstName"] as string;
            this.FamilyName = row["FamilyName"] as string;
            this.Title = row["Title"] as string;
        }
    }


    public class Staff
    {
        static DataTable data = new DataTable();

        static Staff()
        {
            data.Columns.Add("FirstName");
            data.Columns.Add("FamilyName");
            data.Columns.Add("Title");

            data.PrimaryKey = new DataColumn[]
            {
                data.Columns[0],
                data.Columns[1]
            };

            data.Rows.Add("Jane","Doe","Sales Manager");
            data.Rows.Add("John","Doe","Vice President");
            data.Rows.Add("Rupert", "Muck", "President");
            data.Rows.Add("John", "Smith", "Logistics Engineer");
        }

        public Employee this[string firstName,string familyName]
        {
            get
            {
                DataRow row = data.Rows.Find(new object[]
                {
                    firstName,familyName
                });
                return new Employee(row);
            }
        }
    }
}
