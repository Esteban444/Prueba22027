using EasyStay.Models.Dto.Request;
using EasyStay.Models.Dto.Response;

namespace EasyStay.Contracts.Services
{
    public interface IClientService
    {
        public Task<IEnumerable<ClientResponseDto>> GetClients();
        public Task<ClientResponseDto> GetClient(Guid id);
        public Task<ClientResponseDto> AddClient(ClientRequestDto request);
        public Task<ClientResponseDto> UpdadateClient(Guid id, ClientRequestDto request);
        public Task<ClientResponseDto> DeleteClient(Guid id);
    }
}
