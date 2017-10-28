using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using WebApp.Common;
namespace WebApp.Controllers
{
    public class BoardsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BoardsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Boards
        public async Task<IActionResult> Index()
        {
            return View(await _context.Boards.Include(b=>b.Writer)
                                             .OrderByDescending(o=>o.RegDate)
                                             .OrderByDescending(o=>o.IsNotice)
                                             .ToListAsync());
        }

        // GET: Boards/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var board = await _context.Boards
                .SingleOrDefaultAsync(m => m.Id == id);
            if (board == null)
            {
                return NotFound();
            }

            board.ReadCount++;
            await _context.SaveChangesAsync();
            return View(board);
        }

        [Authorize]
        // GET: Boards/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Boards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Contents,WriterCode")] Board board)
        {
            board.WriterCode = User.GetUserId();
            board.RegDate = DateTime.Now;
                
            _context.Add(board);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            

            //return View(board);
        }

        // GET: Boards/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var board = await _context.Boards.FindAsync(id);
            if (board == null)
            {
                return NotFound();
            }
            return View(board);
        }

        // POST: Boards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Title,Contents,RegDate,WriterCode")] Board board)
        {
            if (id != board.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(board);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BoardExists(board.Id))
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
            return View(board);
        }

        // GET: Boards/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var board = await _context.Boards
                .SingleOrDefaultAsync(m => m.Id == id);
            if (board == null)
            {
                return NotFound();
            }

            return View(board);
        }

        // POST: Boards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var board = await _context.Boards.SingleOrDefaultAsync(m => m.Id == id);
            _context.Boards.Remove(board);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BoardExists(string id)
        {
            return _context.Boards.Any(e => e.Id == id);
        }
    }
}
