using ReportsWeb.Extensions;
using ReportsWeb.Models.DataTable;
using ReportsWeb.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ReportsWeb.Services
{
    public class PersonService
    {
        private readonly PersonRepository personRepository;
        public PersonService()
        {
            personRepository = new PersonRepository();
        }

        public (IEnumerable<PersonTableViewModel> Data, int Count) GetPeopleForDataTable(DataParameters parameters)
        {
            var items = personRepository.GetPeopleReadOnly()
                                   .Select(x => new PersonTableViewModel
                                   {
                                       FullName = x.FullName,
                                       PreferredName = x.PreferredName,
                                       Phone = x.Phone,
                                       Email = x.Email,
                                       Age = (DateTime.Now.Subtract(x.DateOfBirth).Days / 365).ToString(),
                                       Status = x.Status == true ? "Active" : "Inactive"
                                   });

            if (!string.IsNullOrWhiteSpace(parameters.Search.Value))
            {
                items = items.Filter(parameters.Search.Value);
            }

            items = items.Order(parameters.Order[0].Column, parameters.Order[0].Dir);

            return (items, personRepository.Count());
        }
    }
}
