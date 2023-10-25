using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Infrastructure;

namespace BirdPlatFormApp.Pages.BirdServicePages
{
    public class EditModel : PageModel
    {
        private readonly Infrastructure.BirdPlatformContext _context;

        public EditModel(Infrastructure.BirdPlatformContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BirdService BirdService { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.BirdServices == null)
            {
                return NotFound();
            }

            var birdservice =  await _context.BirdServices.FirstOrDefaultAsync(m => m.Id == id);
            if (birdservice == null)
            {
                return NotFound();
            }
            BirdService = birdservice;
           ViewData["ProviderId"] = new SelectList(_context.Providers, "Id", "Password");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(BirdService).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BirdServiceExists(BirdService.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BirdServiceExists(int id)
        {
          return (_context.BirdServices?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
