using jwt_auth_api.Models;
using jwt_auth_api.Request_models;
using Microsoft.AspNetCore.Mvc;

namespace jwt_auth_api.Interfaces
{
    public interface IAuthService
    {
        JsonResult AddUser(User user);
        String Login(LoginRequest loginRequest);
    }
}
