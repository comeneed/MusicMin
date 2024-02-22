using MusicMin.Models;
using MusicMin.ViewModels;

namespace MusicMin.Service.Interfaces
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        User GetById(int Id);
    }
}
