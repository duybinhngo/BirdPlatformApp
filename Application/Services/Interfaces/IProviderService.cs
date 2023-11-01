using Domain.Entities;

namespace Application.Services.Interfaces
{
    public interface IProviderService
    {
        Task<List<Provider>> GetAsync();
    }
}
