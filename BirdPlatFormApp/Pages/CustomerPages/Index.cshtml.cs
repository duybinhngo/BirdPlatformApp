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
    public class IndexModel : PageModel
    {
        private readonly ICustomerRepository _context;

        public IndexModel(ICustomerRepository context)
        {
            _context = context;
        }

        public IList<Customer> Customer { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context != null)
            {
                Customer = await _context.GetAll().ToListAsync();
            }
        }
    }
}
