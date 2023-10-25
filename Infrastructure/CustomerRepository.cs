using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.InterfaceRepositories
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public async Task<Customer> Authenticated(string email
            , string username, string avatar_url)
        {

            var customer = await GetAll()
                .Where(x => email.Equals(x.Email))
                .FirstOrDefaultAsync();

            if (customer is null)
            {
                var registedCustomer = Register(email, username, avatar_url);
                return registedCustomer;
            }

            return customer;
        }
        private Customer Register(string email
            , string username, string avatar_url)
        {
            var customer = new Customer
            {
                RoleId = 1,
                Email = email,
                Username = username,
                IsActive = 1,
                AvatarUrl = avatar_url
            };

            return customer;
        }
    }

    
}
