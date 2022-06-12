using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Data;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class RequestModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RequestModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RequestModels
        public async Task<IActionResult> Index()
        {
              return _context.RequestModel != null ? 
                          View(await _context.RequestModel.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.RequestModel'  is null.");
        }

        // GET: RequestModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.RequestModel == null)
            {
                return NotFound();
            }

            var requestModel = await _context.RequestModel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (requestModel == null)
            {
                return NotFound();
            }

            return View(requestModel);
        }

        // GET: RequestModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RequestModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Status,due_date")] RequestModel requestModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(requestModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(requestModel);
        }

        // GET: RequestModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.RequestModel == null)
            {
                return NotFound();
            }

            var requestModel = await _context.RequestModel.FindAsync(id);
            if (requestModel == null)
            {
                return NotFound();
            }
            return View(requestModel);
        }

        // POST: RequestModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Status,due_date")] RequestModel requestModel)
        {
            if (id != requestModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(requestModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RequestModelExists(requestModel.ID))
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
            return View(requestModel);
        }

        // GET: RequestModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.RequestModel == null)
            {
                return NotFound();
            }

            var requestModel = await _context.RequestModel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (requestModel == null)
            {
                return NotFound();
            }

            return View(requestModel);
        }

        // POST: RequestModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.RequestModel == null)
            {
                return Problem("Entity set 'ApplicationDbContext.RequestModel'  is null.");
            }
            var requestModel = await _context.RequestModel.FindAsync(id);
            if (requestModel != null)
            {
                _context.RequestModel.Remove(requestModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RequestModelExists(int id)
        {
          return (_context.RequestModel?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
