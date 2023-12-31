﻿using Domain;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Diagnostics.Eventing.Reader;

namespace Infrastructure.Common
{
    public static class Authentication
    {
        private const string UserSessionKey = "current_user";

        public static bool IsAuthenticated(HttpContext httpContext)
        {
            return httpContext.Session.GetString(UserSessionKey) != null;
        }

        public static void SetAuthentication(HttpContext httpContext
            , ApplicationUser user)
        {
            string userJson = JsonConvert.SerializeObject(user);
            httpContext.Session.SetString(UserSessionKey, userJson);
        }

        public static ApplicationUser GetAuthenticatedUser(HttpContext httpContext)
        {
            // Retrieve and deserialize the user's authentication data from the session
            var userJson = httpContext.Session.GetString(UserSessionKey);
            if (userJson != null)
            {
                return JsonConvert.DeserializeObject<ApplicationUser>(userJson);
            }
            return null;
        }

        public static void ClearAuthentication(HttpContext httpContext)
        {
            httpContext.Session.Remove(UserSessionKey);
        }

        public static bool CheckCustomer(HttpContext httpContext)
        {
            if (IsAuthenticated(httpContext))
            {
                ApplicationUser user = GetAuthenticatedUser(httpContext);
                if (user != null && user.RoleId == 1) return true;
            }
            return false;
        }

        public static bool CheckProvider(HttpContext httpContext)
        {
            if (IsAuthenticated(httpContext))
            {
                ApplicationUser user = GetAuthenticatedUser(httpContext);
                if (user != null && user.RoleId == 2) return true;
            }
            return false;
        }

        /*public static bool CheckAdmin(HttpContext httpContext)
        {
            if (IsAuthenticated(httpContext))
            {
                ApplicationUser user = GetAuthenticatedUser(httpContext);
                if (user != null
                    && user.Email.Equals("admin@FUCarRentingSystem.com")
                    && user..Equals("@@admin@@")) return true;
            }
            return false;
        }*/

    }
}
