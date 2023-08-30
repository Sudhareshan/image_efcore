using Image.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Image.Controllers
{
    public class EmpController : Controller
    {
        private readonly EmployeDbContext _context;
        public EmpController(EmployeDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var employees =_context.Employes.Include(e=>e.Hobbies).ToList();
            return View(employees);
        }

        public IActionResult Create()
        {
            ViewBag.CityList = new List<SelectListItem>
        {
            new SelectListItem { Text = "Hyderabad", Value = "Hyderabad" },
            new SelectListItem { Text = "Bangalore", Value = "Bangalore" },
            new SelectListItem { Text = "Chennai", Value = "Chennai" },
            new SelectListItem { Text = "Pune", Value = "Pune" },
            // Add more cities as needed
        };

            ViewBag.Hobbies = _context.Hobbies.ToList();

            return View();
        }
        [HttpPost]
        public IActionResult Create(EmployModel model, int[] selectedHobbies)
        {
            IFormFile imageFile = Request.Form.Files.FirstOrDefault();

            if (imageFile != null && imageFile.Length > 0)
            {
                var imagePath = Path.Combine("wwwroot/images/profiles", imageFile.FileName);
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imageFile.CopyTo(stream);
                }
                model.ProfileImage = "/images/profiles/" + imageFile.FileName;
            }

            model.Gender = Request.Form["Gender"];
            model.Hobbies = _context.Hobbies.Where(h => selectedHobbies.Contains(h.ID)).ToList();

            _context.Employes.Add(model);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }


    }
}
