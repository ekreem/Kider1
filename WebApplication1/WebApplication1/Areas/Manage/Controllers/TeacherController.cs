using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DAL;
using WebApplication1.Models;


namespace WebApplication1.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class TeacherController : Controller
    {
        AppDbContext _context;
        public TeacherController(AppDbContext context)
        {
            _context = context;
        }
        
        public IActionResult Index()
        {
            var teacher= _context.Teachers.ToList();
            return View(teacher);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Teacher teachers)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            await _context.Teachers.AddAsync(teachers);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int? Id)
        {
            var category= await _context.Teachers.FirstOrDefaultAsync(x => x.Id == Id);
            if (category == null) { return BadRequest(); }
            _context.Teachers.Remove(category);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}
