using ApiReverseEngineering.Data;
using ApiReverseEngineering.Interfaces;
using ApiReverseEngineering.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiReverseEngineering.Services
{
    public class AuthServices: IAuth
    {
        ApisContext apisContext;
        public AuthServices(ApisContext apisContext)
        {
            this.apisContext = apisContext;
        }
        public async Task<UserApi> Get(AuthModel authModel)
        {
            return await this.apisContext.UserApis.SingleOrDefaultAsync(x=>x.User == authModel.User && x.Password== authModel.Password);
        }

       
    }
}
