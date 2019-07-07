using System;

namespace ReportsWeb.Models
{
    public sealed class Person
    {
        public string FullName { get; set; }
        public string PreferredName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool Status { get; set; }
    }
}
