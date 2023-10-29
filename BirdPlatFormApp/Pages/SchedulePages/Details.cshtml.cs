using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Infrastructure;

namespace BirdPlatFormApp.Pages.SchedulePages
{
    public class DetailsModel : PageModel
    {
        private readonly Infrastructure.BirdPlatformContext _context;

        public DetailsModel(Infrastructure.BirdPlatformContext context)
        {
            _context = context;
        }

      public Schedule Schedule { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Schedules == null)
            {
                return NotFound();
            }

            var schedule = await _context.Schedules.FirstOrDefaultAsync(m => m.Id == id);
            if (schedule == null)
            {
                return NotFound();
            }
            else 
            {
                Schedule = schedule;
            }
            return Page();
        }
    }
}
