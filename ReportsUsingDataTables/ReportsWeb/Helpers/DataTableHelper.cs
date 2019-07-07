using ReportsWeb.Attributes;
using ReportsWeb.Models.DataTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;

namespace ReportsWeb.Helpers
{
    public static class DataTableHelper
    {
        public static TableViewModel BuildDataTable(IEnumerable<PersonTableViewModel> listItems, int recordsCount)
        {
            var listString = new List<List<string>>();

            // Get the properties which should appear in the DataTable
            var properties = GetProperties(listItems.FirstOrDefault());

            foreach (PersonTableViewModel item in listItems)
            {
                var listProperties = PrepareDataTable(properties, item).ToList();

                listString.Add(listProperties);
            }

            return new TableViewModel
            {
                Data = listString,
                RecordsTotal = 0, //TODO: Add total here
                RecordsFiltered = recordsCount,
                Draw = 0
            };
        }

        public static IEnumerable<string> BuildDataTableHeader(PersonTableViewModel tableViewModel)
        {
            var headerString = new List<string>();

            // Get the properties which should appear in the DataTable
            var properties = GetProperties(tableViewModel);

            foreach (var property in properties)
            {
                var listProperties = WebUtility.HtmlEncode(tableViewModel.GetType()
                                                                         .GetProperty(property.Name)
                                                                         .GetCustomAttributes(false)
                                                                         .OfType<ShowOnDataTable>().First().ColumnName
                                                           ?? property.Name);

                // VanityId must *always* be the last property
                //listProperties.Add(item.VanityId.ToString());

                headerString.Add(listProperties);
            }

            return headerString;
        }


        private static IOrderedEnumerable<PropertyInfo> GetProperties(PersonTableViewModel item)
        {
            return item.GetType().GetProperties()
                                 .Where(p => Attribute.IsDefined(p, typeof(ShowOnDataTable)))
                                 .OrderBy(o => o.GetCustomAttributes(false).OfType<ShowOnDataTable>().First().Order);
        }

        private static IEnumerable<string> PrepareDataTable(IOrderedEnumerable<PropertyInfo> properties, PersonTableViewModel item)
        {
            var listProperties = new List<string>();

            foreach (var property in properties)
            {
                listProperties.Add(GetValue(property, item));
            }

            return listProperties;
        }

        private static string GetValue(PropertyInfo property, PersonTableViewModel item)
        {
            return WebUtility.HtmlEncode(item.GetType()
                                             .GetProperty(property.Name)
                                             .GetValue(item)?.ToString())
                                         ?? string.Empty;
        }
    }
}
