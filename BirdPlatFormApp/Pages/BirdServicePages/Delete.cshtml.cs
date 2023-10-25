using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Infrastructure;

namespace BirdPlatFormApp.Pages.BirdServicePages
{
    public class DeleteModel : PageModel
    {
        private readonly Infrastructure.BirdPlatformContext _context;

        public DeleteModel(Infrastructure.BirdPlatformContext context)
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

            var birdservice = await _context.BirdServices.FirstOrDefaultAsync(m => m.Id == id);

            if (birdservice == null)
            {
                return NotFound();
            }
            else 
            {
                BirdService = birdservice;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.BirdServices == null)
            {
                return NotFound();
            }
            var birdservice = await _context.BirdServices.FindAsync(id);

            if (birdservice != null)
            {
                BirdService = birdservice;
                _context.BirdServices.Remove(BirdService);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
