﻿using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UdemyJwtApp.BackOffice.Core.Application.Dto;

namespace UdemyJwtApp.BackOffice.Infrastructure.Tools
{
    public class JwtTokenGenerator
    {
        public static TokenResponseDto GenerateToken(CheckUserResponseDto dto)
        {
            var claims = new List<Claim>();

            if(!string.IsNullOrEmpty(dto.Role)) 
                claims.Add(new Claim(ClaimTypes.Role, dto.Role));

            claims.Add(new Claim(ClaimTypes.NameIdentifier,dto.Id.ToString()));
            if (!string.IsNullOrEmpty(dto.Username))
                claims.Add(new Claim("Username", dto.Username));



            var securityKey                 = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key));
            SigningCredentials credentials  = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);
            var expireDate                  = DateTime.UtcNow.AddDays(JwtTokenDefaults.Expire);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(issuer:JwtTokenDefaults.ValidIssuer,audience:JwtTokenDefaults.ValidAudience,claims:claims,
                notBefore:DateTime.UtcNow, expires: expireDate, signingCredentials: credentials);
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            //handler.WriteToken();
            return new TokenResponseDto(handler.WriteToken(jwtSecurityToken),expireDate) ;
        }
    }
}
