using ApiReverseEngineering.Models;

namespace ApiReverseEngineering.Interfaces
{
    public interface IAuth
    {
       Task<UserApi> Get(AuthModel authModel);
       
    }
}
