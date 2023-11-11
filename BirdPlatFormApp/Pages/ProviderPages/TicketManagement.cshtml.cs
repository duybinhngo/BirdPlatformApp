using Application.Services;
using Application.Services.Interfaces;
using Domain.Entities;
using Infrastructure.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BirdPlatFormApp.Pages.ProviderPages
{
    public class TicketManagementModel : PageModel
    {
        private readonly IScheduleTicketService scheduleTicketService;
        private readonly IOrderService orderService;
        private readonly IHttpContextAccessor httpContextAccessor;
        public TicketManagementModel(
            IScheduleTicketService scheduleTicketService,
            IOrderService orderService,
            IHttpContextAccessor httpContextAccessor
            )
        {
            this.scheduleTicketService = scheduleTicketService;
            this.orderService = orderService;
            this.httpContextAccessor = httpContextAccessor;
        }
        public IList<ScheduleTicket> ScheduleTickets {  get; set; } = default!;
        public IList<Order> Orders {  get; set; } = default!;

        [BindProperty]
        public string OrderId { get; set; } = default!;
        public async Task<IActionResult> OnGet()
        {
            var user = Authentication.GetAuthenticatedUser(httpContextAccessor.HttpContext);
            if (user is null || user.RoleId != 1)
            {
                return RedirectToPage("/Login");
            }

            Orders = await orderService.GetOrderAsync(user.Email);
            return Page();
        }

        public async Task<IActionResult> OnPostAcceptOrder()
        {
            await orderService.AcceptOrderAsync(Int32.Parse(OrderId), 2);
            return RedirectToPage("/ProviderPages/TicketManagement");
        }

        public async Task<IActionResult> OnPostRejectOrder()
        {
            await orderService.AcceptOrderAsync(Int32.Parse(OrderId), 0);
            return RedirectToPage("/ProviderPages/TicketManagement");
        }
        public async Task<IActionResult> OnPostUndo()
        {
            await orderService.AcceptOrderAsync(Int32.Parse(OrderId), 1);
            return RedirectToPage("/ProviderPages/TicketManagement");
        }
    }
}
