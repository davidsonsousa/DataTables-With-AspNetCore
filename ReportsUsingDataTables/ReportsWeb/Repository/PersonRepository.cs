using ReportsWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ReportsWeb.Repository
{
    public sealed class PersonRepository
    {
        public IEnumerable<Person> GetPeopleReadOnly()
        {
            return new List<Person>
            {
                new Person {
                    FullName = "John Doe",
                    PreferredName = "John",
                    Email = "john.doe@mail.com",
                    Phone = "555-0000",
                    DateOfBirth = new DateTime(2000, 6, 30),
                    Status = true
                },
                new Person {
                    FullName = "Mary Sue",
                    PreferredName = "Mary",
                    Email = "mary.sue@mail.com",
                    Phone = "555-0001",
                    DateOfBirth = new DateTime(1987, 4, 22),
                    Status = true
                },
                new Person {
                    FullName = "Lily Code",
                    PreferredName = "Lily",
                    Email = "lily.code@mail.com",
                    Phone = "555-0002",
                    DateOfBirth = new DateTime(1976, 1, 7),
                    Status = true
                },
                new Person {
                    FullName = "Amy Trefl",
                    PreferredName = "Amy",
                    Email = "amy.trefl@mail.com",
                    Phone = "555-0003",
                    DateOfBirth = new DateTime(1950, 10, 14),
                    Status = true
                }
            };
        }

        public int Count()
        {
            return GetPeopleReadOnly().Count();
        }
    }
}
