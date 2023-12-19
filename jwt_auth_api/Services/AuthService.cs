using jwt_auth_api.Context;
using jwt_auth_api.Interfaces;
using jwt_auth_api.Models;
using jwt_auth_api.Request_models;
using Microsoft.IdentityModel.JsonWebTokens;
using System.Security.Claims;

namespace jwt_auth_api.Services
{
    public class AuthService : IAuthService
    {
        private readonly JwtContext _jwtContext;
        private readonly IConfiguration _configuration;

        public AuthService(JwtContext jwtContext, IConfiguration configuration)
        {
            _jwtContext = jwtContext;
            _configuration = configuration;
        }

        public User AddUser(User user)
        {
            var addUser = _jwtContext.Users.Add(user);
            _jwtContext.SaveChanges();
            return addUser.Entity;
        }

        public string Login(LoginRequest loginRequest)
        {
            if (loginRequest.Username != null && loginRequest.Password != null)
            {
                var user = _jwtContext.Users.SingleOrDefault(x => x.Email == loginRequest.Username && x.Password == loginRequest.Password);
                if (user != null)
                {
                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim("Id", user.Id.ToString()),
                        new Claim("Username", user.Email),
                        new Claim("Password", user.Password)
                    };
                }
                else {
                    return "no user found";
                }
            }
        }
    }
}
