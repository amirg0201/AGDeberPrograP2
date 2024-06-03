using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AGDeberPrograP2.Data;
using AGDeberPrograP2.Models;

namespace AGDeberPrograP2.Controllers
{
    public class AgAutoesController : Controller
    {
        private readonly AGDeberPrograP2Context _context;

        public AgAutoesController(AGDeberPrograP2Context context)
        {
            _context = context;
        }

        // GET: AgAutoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.AgAuto.ToListAsync());
        }

        // GET: AgAutoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agAuto = await _context.AgAuto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (agAuto == null)
            {
                return NotFound();
            }

            return View(agAuto);
        }

        // GET: AgAutoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AgAutoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Marca,Modelo,AñoFabricacion,Precio")] AgAuto agAuto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(agAuto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(agAuto);
        }

        // GET: AgAutoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agAuto = await _context.AgAuto.FindAsync(id);
            if (agAuto == null)
            {
                return NotFound();
            }
            return View(agAuto);
        }

        // POST: AgAutoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Marca,Modelo,AñoFabricacion,Precio")] AgAuto agAuto)
        {
            if (id != agAuto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(agAuto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AgAutoExists(agAuto.Id))
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
            return View(agAuto);
        }

        // GET: AgAutoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agAuto = await _context.AgAuto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (agAuto == null)
            {
                return NotFound();
            }

            return View(agAuto);
        }

        // POST: AgAutoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var agAuto = await _context.AgAuto.FindAsync(id);
            if (agAuto != null)
            {
                _context.AgAuto.Remove(agAuto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AgAutoExists(int id)
        {
            return _context.AgAuto.Any(e => e.Id == id);
        }
    }
}
