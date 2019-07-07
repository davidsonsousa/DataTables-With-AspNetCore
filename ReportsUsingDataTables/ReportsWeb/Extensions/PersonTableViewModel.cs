using ReportsWeb.Attributes;
using ReportsWeb.Helpers;
using ReportsWeb.Models.DataTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace ReportsWeb.Extensions
{
    public static class PersonTableViewModelExtension
    {
        public static IEnumerable<PersonTableViewModel> Filter(this IEnumerable<PersonTableViewModel> items, string searchTerm)
        {
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                var searchableProperties = typeof(PersonTableViewModel).GetProperties().Where(p => Attribute.IsDefined(p, typeof(Searchable)));

                var lambda = PrepareFilter(searchTerm, searchableProperties);
                items = items.Where(lambda.Compile());
            }

            return items;

        }

        public static IEnumerable<PersonTableViewModel> Order(this IEnumerable<PersonTableViewModel> items, int orderColumn, string orderDirection)
        {
            try
            {
                switch (orderColumn)
                {
                    case 0:
                        items = orderDirection == "asc" ? items.OrderBy(o => o.FullName) : items.OrderByDescending(o => o.FullName);
                        break;
                    case 1:
                        items = orderDirection == "asc" ? items.OrderBy(o => o.PreferredName) : items.OrderByDescending(o => o.PreferredName);
                        break;
                    case 2:
                        items = orderDirection == "asc" ? items.OrderBy(o => o.Phone) : items.OrderByDescending(o => o.Phone);
                        break;
                    case 3:
                        items = orderDirection == "asc" ? items.OrderBy(o => o.Email) : items.OrderByDescending(o => o.Email);
                        break;
                    case 4:
                        items = orderDirection == "asc" ? items.OrderBy(o => o.Age) : items.OrderByDescending(o => o.Age);
                        break;
                    case 5:
                        items = orderDirection == "asc" ? items.OrderBy(o => o.Status) : items.OrderByDescending(o => o.Status);
                        break;
                    default:
                        items = items.OrderBy(o => o.FullName);
                        break;
                }
            }
            catch
            {
                throw;
            }

            return items;
        }

        private static Expression<Func<PersonTableViewModel, bool>> PrepareFilter(string searchTerm, IEnumerable<PropertyInfo> searchableProperties)
        {
            var expressionFilter = new List<ExpressionFilter>();

            foreach (var property in searchableProperties)
            {
                expressionFilter.Add(new ExpressionFilter
                {
                    PropertyName = property.Name,
                    Operation = Operations.Contains,
                    Value = searchTerm
                });
            }

            return ExpressionBuilder.GetExpression<PersonTableViewModel>(expressionFilter, LogicalOperators.Or);
        }
    }
}
