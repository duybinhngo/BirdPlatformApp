using Microsoft.AspNetCore.Mvc.RazorPages;
using Domain.Entities;
using Application.Services.Interfaces;
using Infrastructure.Common;
using Microsoft.AspNetCore.Mvc;

namespace BirdPlatFormApp.Pages.BirdServicePages
{
    public class IndexModel : PageModel
    {
        private readonly IBirdService birdService;

        public IndexModel(IBirdService birdService)
        {
            this.birdService = birdService;
        }

        public IList<BirdService> BirdService { get;set; } = default!;
        public async Task<IActionResult> OnGetAsync()
        {
            if (Authentication.CheckCustomer(HttpContext))
            {
               
                BirdService = await birdService.GetAsync(string.Empty);
                
                return Page();

            }

            return RedirectToPage("/Login");
            
        }

        public async Task OnPostSearchAsync()
        {
            var search = Request.Form["search"];
            if (birdService != null)
            {
                BirdService = await birdService.GetAsync(search);
            }
        }
    }
}
