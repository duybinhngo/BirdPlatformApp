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
    public class DetailsModel : PageModel
    {
        private readonly IProviderRepository _providerRepository;
        public DetailsModel(IProviderRepository providerRepository)
        {
            _providerRepository = providerRepository;
        }

      public Provider Provider { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _providerRepository.GetAllProviders() == null)
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
    }
}
