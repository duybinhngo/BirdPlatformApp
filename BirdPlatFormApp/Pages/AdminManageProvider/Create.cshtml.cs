using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Domain.Entities;
using Infrastructure;
using Infrastructure.InterfaceRepositories;

namespace BirdPlatFormApp.Pages.AdminPages
{
    public class CreateModel : PageModel
    {
        private readonly IProviderRepository _providerRepository;

        public CreateModel(IProviderRepository providerRepository)
        {
            providerRepository = _providerRepository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Provider Provider { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _providerRepository.GetAll() == null || Provider == null)
            {
                return Page();
            }
            var provider = Provider;
            provider.IsActive = 1;
            _providerRepository.CreateAsync(provider);

            return RedirectToPage("./Index");
        }
    }
}
