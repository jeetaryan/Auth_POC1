using jwt_auth_api.Models;
using jwt_auth_api.Request_models;

namespace jwt_auth_api.Interfaces
{
    public interface IAuthService
    {
        User AddUser(User user);
        String Login(LoginRequest loginRequest);
    }
}
