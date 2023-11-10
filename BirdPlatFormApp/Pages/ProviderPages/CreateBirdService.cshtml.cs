using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Domain.Entities;
using Infrastructure;
using Application.Services.Interfaces;
using Infrastructure.Common;

namespace BirdPlatFormApp.Pages.ProviderPages
{
    public class CreateBirdServiceModel : PageModel
    {
        private readonly IBirdService birdService;
        private readonly ICategoriesService categoriesService;
        private readonly IProviderService providerService;
        private readonly IHttpContextAccessor httpContextAccessor;

        public CreateBirdServiceModel(IBirdService birdService, ICategoriesService categoriesService, IProviderService providerService, IHttpContextAccessor httpContextAccessor)
        {
            this.birdService = birdService;
            this.categoriesService = categoriesService;
            this.providerService = providerService;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<IActionResult> OnGet()
        {
            if (!Authentication.CheckProvider(HttpContext))
            {
                return RedirectToPage("/Login");
            }

            ViewData["CategoryId"] = new SelectList(await categoriesService.GetCategoriesAsync(string.Empty), "Id", "Name");
            ViewData["ProviderId"] = new SelectList(await providerService.GetAsync(string.Empty), "Id", "ProviderName");
            return Page();
        }

        [BindProperty]
        public BirdService BirdService { get; set; } = default!;
        
        public async Task<IActionResult> OnPostCreateService()
        {
            if (!Authentication.CheckProvider(HttpContext))
            {
                return RedirectToPage("/Login");
            }
            var user = Authentication.GetAuthenticatedUser(HttpContext);

            BirdService.ProviderId = user.Id;
            BirdService.IsRentingService = BirdService.CategoryId == 8 ? 1 : 0;
            BirdService.IsActive = 1;
            BirdService.CreatedAt = DateTime.Now;
            BirdService.CreatedBy = user.Id;

            await birdService.CreateAsync(BirdService);

            return RedirectToPage("/BirdServicePages/Index");
        }
    }
}
