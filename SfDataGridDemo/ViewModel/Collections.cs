using System;
using System.Collections.Generic;
using System.Data;

namespace SfDataGridDemo
{
    public class Collections
    {
        public DataTable DataTable { get; set; }
        public DataTable ComboBoxDataTable { get; set; }

        public Collections()
        {
            DataTable = new DataTable();
            ComboBoxDataTable = new DataTable();
            ComboBoxDataTable.Columns.Add("ID", typeof(int));
            ComboBoxDataTable.Columns.Add("Name", typeof(string));


            var comboBoxItems = new List<string>
            {
                "Belgim","Oliver","Bernald", "James", "Beverton","Berlin","Fransis","Fred","Dintin","Diano", "Joysie"
            };

            for (int i = 0; i < comboBoxItems.Count; i++)
            {
                ComboBoxDataTable.Rows.Add(i + 1, comboBoxItems[i]);
            }
            DataTable = GetDatatable();
        }
        private DataTable GetDatatable()
        {
            DataTable employeeCollection = new DataTable();
            Random r = new Random();
            employeeCollection.Columns.Add("EmployeeID", typeof(int));
            employeeCollection.Columns[0].ColumnName = "Employee ID";
            employeeCollection.Columns.Add("EmployeeName", typeof(string));
            employeeCollection.Columns["EmployeeName"].ColumnName = "Employee Name";
            employeeCollection.Columns.Add("CustomerID", typeof(string));
            employeeCollection.Columns["CustomerID"].ColumnName = "Customer ID";
            employeeCollection.Columns.Add("Country", typeof(string));
            employeeCollection.Columns.Add("Date", typeof(DateTime));

            employeeCollection.Rows.Add(1001, "Belgim", "Yhgtr", "US", new DateTime(r.Next(2011, 2019), r.Next(1, 12), r.Next(1, 28)));
            employeeCollection.Rows.Add(1002, "Oliver", "Johanesberg", "UK", new DateTime(r.Next(2011, 2019), r.Next(1, 12), r.Next(1, 28)));
            employeeCollection.Rows.Add(1003, "Bernald", "Alfki", "US", new DateTime(r.Next(2011, 2019), r.Next(1, 12), r.Next(1, 28)));
            employeeCollection.Rows.Add(1004, "James", "Yhgtr", "Chicago", new DateTime(r.Next(2011, 2019), r.Next(1, 12), r.Next(1, 28)));
            employeeCollection.Rows.Add(1005, "Beverton", "Bergs", "Spain", new DateTime(r.Next(2011, 2019), r.Next(1, 12), r.Next(1, 28)));
            employeeCollection.Rows.Add(1005, "Berlin", "Johanesberg", "Spain", new DateTime(r.Next(2011, 2019), r.Next(1, 12), r.Next(1, 28)));
            employeeCollection.Rows.Add(1006, "Fransis", "Alfki", "US", new DateTime(r.Next(2011, 2019), r.Next(1, 12), r.Next(1, 28)));
            employeeCollection.Rows.Add(1006, "Fred", "Oregon", "US", new DateTime(r.Next(2011, 2019), r.Next(1, 12), r.Next(1, 28)));
            employeeCollection.Rows.Add(1009, "Dintin", "Britain", "Britain", new DateTime(r.Next(2011, 2019), r.Next(1, 12), r.Next(1, 28)));
            employeeCollection.Rows.Add(1009, "Diano", "Alfki", "Britain", new DateTime(r.Next(2011, 2019), r.Next(1, 12), r.Next(1, 28)));
            employeeCollection.Rows.Add(1010, "Joysie", "Oregon", "China", new DateTime(r.Next(2011, 2019), r.Next(1, 12), r.Next(1, 28)));

            return employeeCollection;
        }
    }
}
