# How to prevent users from entering empty values in columns in WinForms DataGrid (SfDataGrid)?

In [Winforms DataGrid](https://www.syncfusion.com/winforms-ui-controls/datagrid) (SfDatagrid), you can prevent users from entering empty values in a specific [GridColumn](https://help.syncfusion.com/cr/windowsforms/Syncfusion.WinForms.DataGrid.GridColumn.html) by using the [SfDataGrid.RowValidating](https://help.syncfusion.com/cr/windowsforms/Syncfusion.WinForms.DataGrid.SfDataGrid.html#Syncfusion_WinForms_DataGrid_SfDataGrid_RowValidating) event. Within this event, set the `e.IsValid` property to false and provide an appropriate message using the `e.ErrorMessage` property.

**C#**
```
sfDataGrid1.RowValidating += OnRowValidating;

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
```

Alternatively, you can validate individual cell values by handling the [SfDataGrid.CurrentCellValidating](https://help.syncfusion.com/cr/windowsforms/Syncfusion.WinForms.DataGrid.SfDataGrid.html#Syncfusion_WinForms_DataGrid_SfDataGrid_CurrentCellValidating) event. This approach provides direct access to the new value and the column being edited. When validation is handled in this manner, the current cell will not move to the next cell until a valid value is entered.

**C#**
```
sfDataGrid1.CurrentCellValidating += OnCurrentCellValidating;

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
```

![Prevent Empty Values](Prevent%20Empty%20Values.gif)

Take a moment to peruse the [WinForms DataGrid - Data Validation](https://help.syncfusion.com/windowsforms/datagrid/datavalidation) documentation, to learn more about data validation with examples.