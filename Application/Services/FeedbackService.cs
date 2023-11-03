using Application.Services.Interfaces;
using Domain.Entities;
using Infrastructure.InterfaceRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepository feedbackRepository;
        public FeedbackService(IFeedbackRepository feedbackRepository)
        {
            this.feedbackRepository = feedbackRepository;
        }
        public async Task<bool> CreateFeedbackAsync(Feedback feedback)
        {
            return await feedbackRepository.CreateAsync(feedback);
        }
    }
}
