using Syncfusion.WinForms.DataGrid.Enums;
using Syncfusion.WinForms.DataGrid.Events;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SfDataGridDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Collections collections = new Collections();

            // Set the DataSource of the SfDataGrid to the DataTable from the Collections class.
            sfDataGrid1.DataSource = collections.DataTable;

           
            //Solution 1: To validate the entire row, you can use the RowValidating event of the SfDataGrid.
            //This event is triggered when the user tries to move to another row after editing a cell in the current row.
            sfDataGrid1.RowValidating += OnRowValidating;

            //Solution 2: To validate the current cell value, you can use the CurrentCellValidating event of the SfDataGrid.
            //This event is triggered when the user tries to move to another cell or row after editing a cell.
            //You can handle this event to perform validation on the current cell value and prevent the user from moving if the value is invalid.
            //sfDataGrid1.CurrentCellValidating += OnCurrentCellValidating;


            sfDataGrid1.AddNewRowPosition = RowPosition.Top;
            sfDataGrid1.ShowRowHeader = true;
        }

        private void OnRowValidating(object sender, RowValidatingEventArgs e)
        {
            if (e.DataRow?.RowData is System.Data.DataRowView drv)
            {
                var valueStr = drv.Row["Employee Name"].ToString();
                if (string.IsNullOrWhiteSpace(valueStr))
                {
                    e.IsValid = false;
                    e.ErrorMessage = "Employee Name cannot be empty.";
                    return;
                }
            }
            else
            {

                try
                {
                    if (e.DataRow?.RowData is System.Data.DataRow dataRow)
                    {
                        string valueStr = dataRow["Employee Name"].ToString();

                        if (string.IsNullOrWhiteSpace(valueStr))
                        {
                            e.IsValid = false;
                            e.ErrorMessage = "Employee Name cannot be empty.";
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    e.IsValid = false;
                }
            }
        }

        private void OnCurrentCellValidating(object sender, CurrentCellValidatingEventArgs e)
        {
            if (e.NewValue is string strValue)
            {
                if (string.IsNullOrWhiteSpace(strValue))
                {
                    e.IsValid = false;
                    e.ErrorMessage = "Value cannot be empty.";
                    return;
                }
            }
        }
    }
}
