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

namespace BirdPlatFormApp.Pages.AdminPages
{
    public class BanModel : PageModel
    {
        private readonly IProviderRepository _providerRepository;
        public BanModel(IProviderRepository providerRepository)
        {
            providerRepository = _providerRepository;
        }

        [BindProperty]
      public Provider Provider { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var provider = await _providerRepository.GetProviderById(id);

            if (provider == null)
            {
                return NotFound();
            }
            else 
            {
                Provider = provider;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostBanAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var provider = await _providerRepository.GetProviderById(id);

            if (provider != null)
            {
                Provider = provider;
                provider.IsActive = 0;
                await _providerRepository.UpdateAsync(provider);
            }

            return RedirectToPage("./Index");
        }

        public async Task<IActionResult> OnPostUnbanAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var provider = await _providerRepository.GetProviderById(id);

            if (provider != null)
            {
                Provider = provider;
                provider.IsActive = 1;
                await _providerRepository.UpdateAsync(provider);
            }

            return RedirectToPage("./Index");
        }
    }
}
