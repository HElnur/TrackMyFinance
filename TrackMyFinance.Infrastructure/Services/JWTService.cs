﻿using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TrackMyFinance.Application.Interfaces;

namespace TrackMyFinance.Infrastructure.Services
{
    public class JWTService : IJWTService
    {
        private readonly IConfiguration _configuration;

        public JWTService(IConfiguration configuration)
            => _configuration = configuration;

        public string ValidateJwtToken(string token)
        {
            throw new NotImplementedException();
        }

        public string GenerateJwtToken<TOutput>(TOutput user)
        {
            //var issuer = _configuration["JWTSettings:Issuer"];
            //var audience = _configuration["JWTSettings:Audience"];
            //var key = Encoding.ASCII.GetBytes(_configuration["JWTSettings:Key"]);

            //if(user.GetType().GetProperty("Id") == null || user.GetType().GetProperty("Email") == null)
            //{
            //    throw new ArgumentException("TOutput type must have 'Id' and 'Mail' Properties");
            //}

            //var tokenDescriptor = new SecurityTokenDescriptor
            //{
            //    Subject = new ClaimsIdentity(new[]
            //    {
            //        new Claim("id", user.GetType().GetProperty("Id").GetValue(user).ToString()),
            //        new Claim("Email", user.GetType().GetProperty("Email").GetValue(user).ToString()),
            //        new Claim("UserName", user.GetType().GetProperty("UserName").GetValue(user).ToString()),
            //        new Claim("jti", Guid.NewGuid().ToString().Replace("-", "")),
            //    }),

            //    Expires = DateTime.UtcNow.AddMinutes(Convert.ToInt32(_configuration["JWTSettings:Expiration"])),
            //    Issuer = issuer,
            //    Audience = audience,
            //    SigningCredentials = new SigningCredentials
            //    (new SymmetricSecurityKey(key),
            //    SecurityAlgorithms.HmacSha512Signature)

            //};

            //try
            //{
            //    var tokenHandler = new JwtSecurityTokenHandler();
            //    var token = tokenHandler.CreateToken(tokenDescriptor);
            //    var jwtToken = tokenHandler.WriteToken(token);
            //    var stringToken = tokenHandler.WriteToken(token);
            //    return stringToken;
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"JWT Generation Error: {ex.Message}");
            //    throw;
            //}

            var issuer = _configuration["JWTSettings:Issuer"];
            var audience = _configuration["JWTSettings:Audience"];
            var key = Encoding.ASCII.GetBytes(_configuration["JWTSettings:Key"]);

            if (user.GetType().GetProperty("Id") == null || user.GetType().GetProperty("Email") == null)
            {
                throw new ArgumentException("TOutput type must have 'Id' and 'Mail' Properties");
            }

            // Doğrudan user nesnesinin property'lerine erişim sağlanacak
            var userId = user.GetType().GetProperty("Id")?.GetValue(user)?.ToString();
            var email = user.GetType().GetProperty("Email")?.GetValue(user)?.ToString();
            var userName = user.GetType().GetProperty("UserName")?.GetValue(user)?.ToString();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
            new Claim("id", userId),
            new Claim("Email", email),
            new Claim("UserName", userName),
            new Claim("jti", Guid.NewGuid().ToString().Replace("-", "")),
        }),

                Expires = DateTime.UtcNow.AddMinutes(Convert.ToInt32(_configuration["JWTSettings:Expiration"])),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha512Signature)
            };

            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"JWT Generation Error: {ex.Message}");
                throw;
            }


        }
    }
}
