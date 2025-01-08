﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projekt_zaliczeniowy_aspnet.Data;
using Projekt_zaliczeniowy_aspnet.Models;

namespace Projekt_zaliczeniowy_aspnet.Controllers
{
    public class LecturesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LecturesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Lectures
        public async Task<IActionResult> Index()
        {
            return View(await _context.Lecture.ToListAsync());
        }

        // GET: Lectures/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lecture = await _context.Lecture
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lecture == null)
            {
                return NotFound();
            }

            return View(lecture);
        }

        // GET: Lectures/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lectures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Lecturer,IsEndingWithExam")] Lecture lecture)
        {
            if (ModelState.IsValid)
            {
                lecture.Id = Guid.NewGuid();
                _context.Add(lecture);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lecture);
        }

        // GET: Lectures/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lecture = await _context.Lecture.FindAsync(id);
            if (lecture == null)
            {
                return NotFound();
            }
            return View(lecture);
        }

        // POST: Lectures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Description,Lecturer,IsEndingWithExam")] Lecture lecture)
        {
            if (id != lecture.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lecture);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LectureExists(lecture.Id))
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
            return View(lecture);
        }

        // GET: Lectures/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lecture = await _context.Lecture
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lecture == null)
            {
                return NotFound();
            }

            return View(lecture);
        }

        // POST: Lectures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var lecture = await _context.Lecture.FindAsync(id);
            if (lecture != null)
            {
                _context.Lecture.Remove(lecture);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LectureExists(Guid id)
        {
            return _context.Lecture.Any(e => e.Id == id);
        }
    }
}
