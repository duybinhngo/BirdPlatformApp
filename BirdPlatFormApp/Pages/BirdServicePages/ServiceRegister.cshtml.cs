using Application.Services.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BirdPlatFormApp.Pages.BirdServicePages
{
    public class ServiceRegisterModel : PageModel
    {
        private readonly IBirdService birdService;

        public ServiceRegisterModel(IBirdService birdService)
        {
            this.birdService = birdService;
        }
        public BirdService BirdService { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            BirdService = await birdService.GetByIdAsync(id ?? 0);
            return Page();
        }
    }
}
