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

namespace BirdPlatFormApp.Pages.AdminManageProvider
{
    public class BirdServicesListModel : PageModel
    {
        private readonly IBirdServiceRepository _birdServiceRepository;

        public BirdServicesListModel(IBirdServiceRepository birdServiceRepository)
        {
            _birdServiceRepository = birdServiceRepository;
        }

        public IList<BirdService> BirdService { get;set; } = default!;

        public async Task OnGetAsync(int id)
        {
                BirdService = await _birdServiceRepository.GetAllByProviderId(id);  
        }
    }
}
