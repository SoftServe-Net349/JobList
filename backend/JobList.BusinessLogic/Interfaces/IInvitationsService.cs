using JobList.Common.DTOS;
using JobList.Common.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobList.BusinessLogic.Interfaces
{
    public interface IInvitationsService
    {
        Task<IEnumerable<InvitationDTO>> GetAllInvitationsAsync();

        Task<InvitationDTO> GetInvitationByIdAsync(int id);

        Task<InvitationDTO> CreateInvitationAsync(InvitationRequest request);

        Task<bool> UpdateInvitationByIdAsync(InvitationRequest request, int id);

        Task<bool> DeleteInvitationByIdAsync(int id);
    }
}
