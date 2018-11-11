using JobList.Common.DTOS;
using JobList.Common.Requests;
using System.Threading.Tasks;

namespace JobList.BusinessLogic.Interfaces
{
    public interface IEmployeeTokensService: ITokensService<EmployeeDTO>
    {
        Task<TokenDTO> CreateTokenByFacebookAsync(FacebookAuthRequest request);
    }
}
