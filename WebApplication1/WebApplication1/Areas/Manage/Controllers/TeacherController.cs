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

            string filname = teachers.File.FileName;
            string path = "C:\\Users\\ca r221.14\\Desktop\\MVC ler\\Kider\\WebApplication1\\WebApplication1\\wwwroot\\Upload\\Slider\\";
            using (FileStream stream = new FileStream(path + filname, FileMode.Create)) 
            {
            teachers.File.CopyTo(stream);   
            }

            teachers.ImgUrl = filname; 












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
