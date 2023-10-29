using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Domain.Entities;
using Infrastructure;

namespace BirdPlatFormApp.Pages.SchedulePages
{
    public class CreateModel : PageModel
    {
        private readonly Infrastructure.BirdPlatformContext _context;

        public CreateModel(Infrastructure.BirdPlatformContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["BirdServiceId"] = new SelectList(_context.BirdServices, "Id", "ProductName");
            return Page();
        }

        [BindProperty]
        public Schedule Schedule { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Schedules == null || Schedule == null)
            {
                return Page();
            }

            _context.Schedules.Add(Schedule);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
