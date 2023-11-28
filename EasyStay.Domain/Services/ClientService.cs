using AutoMapper;
using EasyStay.Contracts.Repositories;
using EasyStay.Contracts.Services;
using EasyStay.Domain.Helpers;
using EasyStay.Models.Dto.Request;
using EasyStay.Models.Dto.Response;
using EasyStay.Models.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace EasyStay.Domain.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;
        public ClientService(IClientRepository clientRepository, IMapper mapper)
        {
            this._clientRepository = clientRepository;
            this._mapper = mapper;
        }

        public async Task<ClientResponseDto> AddClient(ClientRequestDto request)
        {
            try
            {
                var newClient = _mapper.Map<Client>(request);
                await _clientRepository.Add(newClient);
                var response = _mapper.Map<ClientResponseDto>(newClient);
                return response;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ClientResponseDto> DeleteClient(Guid id)
        {
            try
            {
                var result = await _clientRepository.FindByAsNoTracking(x => x.Id == id).FirstOrDefaultAsync();
                if (result != null)
                {
                    await _clientRepository.Delete(result);
                }
                return _mapper.Map<ClientResponseDto>(result);
            }
            catch (Exception)
            {
                throw new HandlingExcepciones(HttpStatusCode.NotFound, new { Mensage = "The client cannot be deleted from the database." });

            }
        }

        public async Task<ClientResponseDto> GetClient(Guid id)
        {
            try
            {
                var result = await _clientRepository.FindByAsNoTracking(x => x.Id == id).FirstOrDefaultAsync();
                if (result != null)
                {
                    return _mapper.Map<ClientResponseDto>(result);
                }
                else
                {
                    throw new Exception();
                }

            }
            catch (Exception)
            {
                throw new HandlingExcepciones(HttpStatusCode.NotFound, new { Mensage = "The client does not exist or is not available." });
            }
        }

        public async Task<IEnumerable<ClientResponseDto>> GetClients()
        {
            try
            {
                var clients = await _clientRepository.GetAll().ToListAsync();
                var response = _mapper.Map<IEnumerable<ClientResponseDto>>(clients);
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ClientResponseDto> UpdadateClient(Guid id, ClientRequestDto request)
        {
            try
            {
                var result = await _clientRepository.FindBy(x => x.Id == id).FirstOrDefaultAsync();
                if (result != null)
                {
                    var properties = new UpdatedMapperProperties<Client, ClientRequestDto>();
                    var resultToUpdate = await properties.MapperUpdate(result!, request);

                    await _clientRepository.Update(resultToUpdate);
                    var response = _mapper.Map<ClientResponseDto>(resultToUpdate);
                    return response;
                }
                else
                {
                    throw new HandlingExcepciones(HttpStatusCode.NotFound, new { Mensaje = "The client you wish to update does not exist in the database." });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
