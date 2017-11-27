using IdentityServer4.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Services;


namespace Autenticacion
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        public Task<GrantValidationResult> ValidateAsync(string userName, string password, ValidatedTokenRequest request)
        {
            // Check The UserName And Password In Database, Return The Subject If Correct, Return Null Otherwise
            string subject = null;
            if (userName == "bob" && password == "1234")
            {
                subject = "validated";
            }
           
            if (subject == null)
            {
                var result = new GrantValidationResult(subject, "Username Or Password Incorrect");
                return Task.FromResult(result);
            }
            else
            {
                var result = new GrantValidationResult(subject, "password");
                return Task.FromResult(result);
            }
        }

      
    }
}
