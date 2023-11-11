using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Infrastructure;
using Infrastructure.InterfaceRepositories;

namespace BirdPlatFormApp.Pages.CustomerPages
{
    public class DeleteModel : PageModel
    {
        private readonly ICustomerRepository _context;

        public DeleteModel(ICustomerRepository context)
        {
            _context = context;
        }

      [BindProperty]
      public Customer Customer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context == null)
            {
                return NotFound();
            }

            var customer = await _context.GetAll().FirstOrDefaultAsync(m => m.Id == id);

            if (customer == null)
            {
                return NotFound();
            }
            else 
            {
                Customer = customer;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context == null)
            {
                return NotFound();
            }
            var customer = await _context.GetAll()
                .SingleOrDefaultAsync(x => x.Id.Equals(id));

            if (customer != null)
            {
                Customer = customer;
                await _context.DeleteAsync(Customer);
            }

            return RedirectToPage("./Index");
        }
    }
}
