using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCCoreData.Data;
using MVCCoreData.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCoreData.Controllers
{
    public class CourseController : Controller
    {
        private readonly DataContext _context;
        private readonly DataDapper _dataDapper;

        public CourseController(DataContext context, DataDapper dataDapper)
        {
            _context = context;
            _dataDapper = dataDapper;
        }

        // GET: Course
        public async Task<IActionResult> Index()
        {
            using (var dbConnection = _dataDapper.GetDapperConnection())
            {                
                return View((await dbConnection.QueryAsync<CourseModel>("SELECT [Id] = CourseId, * FROM Course")).ToList());
            }

            //return View(await _context.Course.ToListAsync());
        }

        // GET: Course/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseModel = new CourseModel();

            using (var dbConnection = _dataDapper.GetDapperConnection())
            {
                courseModel = (await dbConnection.QueryAsync<CourseModel>("SELECT [Id] = CourseId, * FROM Course c WHERE c.CourseId = " + id)).SingleOrDefault();
            }

            //var courseModel = await _context.Course
            //    .SingleOrDefaultAsync(m => m.Id == id);

            if (courseModel == null)
            {
                return NotFound();
            }

            return View(courseModel);
        }

        // GET: Course/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Course/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,Free,Description,StartDate,EndDate,IsActive")] CourseModel courseModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(courseModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(courseModel);
        }

        // GET: Course/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseModel = new CourseModel();

            using (var dbConnection = _dataDapper.GetDapperConnection())
            {
                courseModel = (await dbConnection.QueryAsync<CourseModel>("SELECT [Id] = CourseId, * FROM Course c WHERE c.CourseId = " + id)).SingleOrDefault();
            }

            //var courseModel = await _context.Course.SingleOrDefaultAsync(m => m.Id == id);

            if (courseModel == null)
            {
                return NotFound();
            }
            return View(courseModel);
        }

        // POST: Course/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,Free,Description,StartDate,EndDate,IsActive")] CourseModel courseModel)
        {
            if (id != courseModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(courseModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseModelExists(courseModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(courseModel);
        }

        // GET: Course/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseModel = new CourseModel();

            using (var dbConnection = _dataDapper.GetDapperConnection())
            {
                courseModel = (await dbConnection.QueryAsync<CourseModel>("SELECT [Id] = CourseId, * FROM Course c WHERE c.CourseId = " + id)).SingleOrDefault();
            }

            //var courseModel = await _context.Course
            //    .SingleOrDefaultAsync(m => m.Id == id);

            if (courseModel == null)
            {
                return NotFound();
            }

            return View(courseModel);
        }

        // POST: Course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var courseModel = new CourseModel();

            using (var dbConnection = _dataDapper.GetDapperConnection())
            {
                courseModel = (await dbConnection.QueryAsync<CourseModel>("SELECT [Id] = CourseId, * FROM Course c WHERE c.CourseId = " + id)).SingleOrDefault();
            }

            //var courseModel = await _context.Course.SingleOrDefaultAsync(m => m.Id == id);

            _context.Course.Remove(courseModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseModelExists(int id)
        {
            using (var dbConnection = _dataDapper.GetDapperConnection())
            {
                return dbConnection.Query<CourseModel>("SELECT [Id] = CourseId, * FROM Course c WHERE c.CourseId = " + id).ToList().Count > 0;
            }

            //return _context.Course.Any(e => e.Id == id);
        }
    }
}
