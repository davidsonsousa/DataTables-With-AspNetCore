using ReportsWeb.Attributes;

namespace ReportsWeb.Models.DataTable
{
    public class PersonTableViewModel
    {
        [ShowOnDataTable(0, "Full name"), Searchable, Orderable]
        public string FullName { get; set; }

        [ShowOnDataTable(1, "Preferred name"), Searchable, Orderable]
        public string PreferredName { get; set; }

        [ShowOnDataTable(2), Searchable, Orderable]
        public string Phone { get; set; }

        [ShowOnDataTable(3, "E-mail"), Searchable, Orderable]
        public string Email { get; set; }

        [ShowOnDataTable(4), Searchable, Orderable]
        public string Age { get; set; }

        [ShowOnDataTable(5), Searchable, Orderable]
        public string Status { get; set; }
    }
}
