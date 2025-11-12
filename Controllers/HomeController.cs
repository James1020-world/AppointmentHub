using AppointmentHubMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;

namespace AppointmentHubMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly AppDbContext _appDbContext;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _appDbContext = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Appointment()
        {
            var allAppointments = _appDbContext.Appointments.ToList();

            return View(allAppointments);
        }

        public IActionResult CreateEditAppointment(int? Id)
        {
            if (Id != null)
            {
                var selectedID = _appDbContext.Appointments.SingleOrDefault(appointment => appointment.Id == Id);
                return View(selectedID);
            }
            return View();
        }

        public IActionResult Delete(int Id)
        {
            var selectedID = _appDbContext.Appointments.SingleOrDefault(appointment => appointment.Id == Id);
            _appDbContext.Appointments.Remove(selectedID);
            _appDbContext.SaveChanges();

            return RedirectToAction("Appointment");
        }

        public IActionResult DoCreateorEdit(Appointments appointment)
        {
            appointment.Status = 0;

            if( appointment.Id == 0 )
            {
                _appDbContext.Appointments.Add(appointment);
            }
            else
            {
                _appDbContext.Appointments.Update(appointment);
            }
            _appDbContext.SaveChanges();

            return RedirectToAction("Appointment");
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
    }
}
