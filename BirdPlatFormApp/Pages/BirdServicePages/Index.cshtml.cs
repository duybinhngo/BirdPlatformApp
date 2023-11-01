using Microsoft.AspNetCore.Mvc.RazorPages;
using Domain.Entities;
using Application.Services.Interfaces;

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
        public async Task OnGetAsync()
        {
            if (birdService != null)
            {
                BirdService = await birdService.GetAsync(string.Empty);
            }
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
