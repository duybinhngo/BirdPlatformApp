using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Domain.Entities;
using Infrastructure;

namespace BirdPlatFormApp.Pages.BirdServicePages
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
        ViewData["ProviderId"] = new SelectList(_context.Providers, "Id", "Password");
            return Page();
        }

        [BindProperty]
        public BirdService BirdService { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.BirdServices == null || BirdService == null)
            {
                return Page();
            }

            _context.BirdServices.Add(BirdService);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
