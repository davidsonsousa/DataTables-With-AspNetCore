using System;

namespace ReportsWeb.Attributes
{
    /// <summary>
    /// Enables the property to be visible in the DataTable
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class ShowOnDataTable : Attribute
    {
        public int Order { get; }
        public string ColumnName { get; }

        public ShowOnDataTable(int order, string columnName = null)
        {
            Order = order;
            ColumnName = columnName;
        }
    }
}
