using Microsoft.AspNetCore.Mvc;
using ProjectTime.Data;
using ProjectTime.Models;

namespace ProjectTime.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly ApplicationDbContext _db;

        public DepartmentController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Department> objDepartmentList = _db.departments;
            return View(objDepartmentList);
        }
    }
}
