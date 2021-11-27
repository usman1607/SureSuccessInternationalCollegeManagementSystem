using AuthServeice.Interfaces;
using Domain.Dtos;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using SSICMS.Core.Domain.Dtos;
using SSICMS.Core.Domain.Entities;
using SSICMS.Core.Domain.Extensions;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AuthServeice.Implementation
{
     class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        HttpClient _client = new();

        private readonly string key = "f8978942-1f29-4bfc-bcb6-f0051bd67c93";

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        private string GenerateSalt()
        {

            byte[] salt = new byte[128 / 8];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            string saltString = Convert.ToBase64String(salt);

            return saltString;
        }

        public async Task<StudentResponseModel> Register(StudentRequestModel model)
        {
            var url = $"https://localhost:44398/api/v1/create/register";
            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(url, content);
            var student = await response.ReadContentAs<StudentDto>();

            string salt = GenerateSalt();

            var user = new User
            {
                Id = student.Id,
                Email = student.Email,
                HashSalt = salt,
                PasswordHash = HashPassword(model.Password, salt),
                Role = "Student"
            };

            await _userRepository.AddUser(user);

            return new StudentResponseModel
            {
                Message = "Student Registration Created Successfully.",
                Status = true,
                StudentDto = new StudentDto
                {
                    Id = student.Id,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    PhoneNumber = student.PhoneNumber,
                    Email = student.Email,
                    Address = student.Address,
                    Country = student.Country,
                    State = student.State
                }
            };
        }

        public async Task<string> Login(LoginRequestModel model)
        {

            var user = await _userRepository.GetUser(model.Email);

            if (user == null) return null;

            var passwordHash = HashPassword(model.Password, user.HashSalt);

            if (!user.PasswordHash.Equals(passwordHash)) return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.Now.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }


        private string HashPassword(string password, string salt)
        {
            byte[] saltByte = Convert.FromBase64String(salt);
            // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: saltByte,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return hashed;
        }
    }
}
