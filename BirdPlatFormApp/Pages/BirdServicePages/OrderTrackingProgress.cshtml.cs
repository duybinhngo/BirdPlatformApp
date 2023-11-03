using Application.Services;
using Application.Services.Interfaces;
using Domain.Entities;
using Infrastructure.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BirdPlatFormApp.Pages.BirdServicePages
{
    public class OrderTrackingProgressModel : PageModel
    {
        private readonly IOrderService orderService;
        private readonly IFeedbackService feedbackService;
        private readonly IHttpContextAccessor httpContextAccessor;
        public OrderTrackingProgressModel(IOrderService orderService, IFeedbackService feedbackService, IHttpContextAccessor httpContextAccessor)
        {
            this.orderService = orderService;
            this.feedbackService = feedbackService;
            this.httpContextAccessor = httpContextAccessor;
        }
        public IList<Order> Order { get; set; }

        [BindProperty]
        public Domain.Entities.BirdService BirdService { get; set; }


        [BindProperty]
        public string feedback { get; set; }

        [BindProperty]
        public int birdServiceId { get; set; }

        public async Task<IActionResult> OnGet()
        {
            var user = Authentication.GetAuthenticatedUser(httpContextAccessor.HttpContext);
            if (user is null)
            {
                return RedirectToPage("/Login");
            }
            Order = await orderService.GetOrderAsync(user.Email);
            return Page();
        }

        public async Task<IActionResult> OnPostFeedback()
        {
            var user = Authentication.GetAuthenticatedUser(httpContextAccessor.HttpContext);
            if (user is null)
            {
                return RedirectToPage("/Login");
            }
            var model = new Feedback()
            {
                CustomerName = user.UserName,
                Description = feedback ?? "",
                IsActive = 1,
                BirdServiceId = birdServiceId
            };
            await feedbackService.CreateFeedbackAsync(model);
            return Page();
        }
    }
}
