using Microsoft.AspNetCore.Mvc;
using ReportsWeb.Helpers;
using ReportsWeb.Models;
using ReportsWeb.Models.DataTable;
using ReportsWeb.Services;
using System.Diagnostics;

namespace ReportsWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly PersonService personService;

        public HomeController()
        {
            personService = new PersonService();
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "Home Page";
            var header = DataTableHelper.BuildDataTableHeader(new PersonTableViewModel());
            return View(header);
        }

        public IActionResult PeopleReport()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult GetPeopleData(DataParameters parameters)
        {
            var items = personService.GetPeopleForDataTable(parameters);

            var dataTable = DataTableHelper.BuildDataTable(items.Data, items.Count);
            dataTable.Draw = parameters.Draw;

            return Ok(dataTable);
        }
    }
}
