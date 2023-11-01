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
    public class IndexModel : PageModel
    {
        private readonly IProviderRepository _providerRepository;
        public IndexModel(IProviderRepository providerRepository)
        {
            _providerRepository = providerRepository;
        }

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public IList<Provider> Provider { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (!string.IsNullOrEmpty(SearchString))
            {
                Provider = await _providerRepository.GetProviderByName(SearchString);
            }
            else
            {
                if (_providerRepository.GetAll() != null)
                {
                    Provider = await _providerRepository.GetAllProviders();
                }

            }
        }
    }
}
