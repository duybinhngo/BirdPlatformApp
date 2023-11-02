using Application.Services.Interfaces;
using Domain.Entities;
using Google.Apis.Oauth2.v2.Data;
using Infrastructure.Common;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace BirdPlatFormApp.Pages.BirdServicePages
{
    public class ServiceRegisterModel : PageModel
    {
        private readonly IBirdService birdService;
        private readonly IOrderService orderService;
        private readonly IScheduleTicketService scheduleTicketService;
        private readonly IHttpContextAccessor httpContextAccessor;

        [BindProperty]
        public String fromDate {  get; set; }

        [BindProperty]
        public String toDate { get; set; }

        [BindProperty]
        public String totalPrice { get; set; }

        public ServiceRegisterModel(IBirdService birdService, IOrderService orderService, IScheduleTicketService scheduleTicketService, IHttpContextAccessor httpContextAccessor)
        {
            this.birdService = birdService;
            this.orderService = orderService;
            this.scheduleTicketService = scheduleTicketService;
            this.httpContextAccessor = httpContextAccessor;
        }
        public BirdService BirdService { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            BirdService = await birdService.GetByIdAsync(id ?? 0);
            return Page();
        }
        public async Task<IActionResult> OnPostRaisingService()
        {
            var user = Authentication.GetAuthenticatedUser(httpContextAccessor.HttpContext);
            if (user is null)
            {
                return RedirectToPage("/Login");
            }

            int userId = user.Id;
            DateTime current = DateTime.Now;
            var order = new Order()
            {
                CustomerId = userId,
                TotalPrice = Decimal.Parse(this.totalPrice),
                Description = user.UserName + "Order in" + current.ToString(),
                Status = 1,
                OrderDate = current,
            };
            Order orderResult = await orderService.CreateOrderAsync(order);

            var ticket = new ScheduleTicket()
            {
                UserId = userId,
                OrderDate = current,
                TotalPrice = Decimal.Parse(totalPrice, NumberStyles.AllowThousands
       | NumberStyles.AllowDecimalPoint | NumberStyles.AllowCurrencySymbol),
                Status = 1,
                Description = "Ticket of " + user.UserName + "is created at" + current.ToString() + " | " + BirdService.Category.Name,
                BirdServiceId = BirdService.Id,
                ScheduleFrom = DateTime.Parse(fromDate),
                ScheduleTo = DateTime.Parse(toDate),
                OrderId = orderResult.Id
            };
            bool ticketResult = await scheduleTicketService.CreateScheduleTicket(ticket);
            
            return Page();
        }
    }
}
