using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Application.Interfaces.Repositories;
using Common.Infrastructure;
using Common.Infrastructure.Exceptions;
using Common.Models.Queries;
using Common.Models.RequestModels;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace Application.Features.Commands.User.Login
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserViewModel>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private  int count = 0;

        public LoginUserCommandHandler(IUserRepository userRepository, IMapper mapper, IConfiguration configuration)
        {
            this._userRepository = userRepository;
            this._mapper = mapper;
            this._configuration = configuration;
        }
        public async Task<LoginUserViewModel> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var dbUser = await _userRepository.GetSingleAsync(i => i.Email == request.Email);

            if (dbUser == null)
                throw new DatabaseValidationException("User not found!");

            var pass = PasswordEncryptor.Encrypt(request.Password);
            if (dbUser.Password != pass)
            {
                count++;
                throw new DatabaseValidationException("Password is wrong!");
            }

            if (count >= 3)
            {
                dbUser.Status = false;
                dbUser.FailLoginCount += 1;
            }
            var result = _mapper.Map<LoginUserViewModel>(dbUser);

            var claims = new Claim[]
            {
            new Claim(ClaimTypes.NameIdentifier, dbUser.Id.ToString()),
            new Claim(ClaimTypes.Email, dbUser.Email),
            new Claim(ClaimTypes.GivenName, dbUser.FirstName),
            new Claim(ClaimTypes.Surname, dbUser.LastName)
            };

            result.Token = GenerateToken(claims);

            return result;
        }

        private string GenerateToken(Claim[] claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AuthConfig:Secret"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiry = DateTime.Now.AddDays(10);

            var token = new JwtSecurityToken(claims: claims,
                                             expires: expiry,
                                             signingCredentials: creds,
                                             notBefore: DateTime.Now);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
