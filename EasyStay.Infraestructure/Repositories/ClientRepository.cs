using EasyStay.Contracts.Repositories;
using EasyStay.Infraestructure.DataAcces;
using EasyStay.Infrastructure.Repositories;
using EasyStay.Models.Models;

namespace EasyStay.Infraestructure.Repositories
{
    public class ClientRepository: BaseRepository<Client>, IClientRepository
    {
        public ClientRepository(EasyStayDbContex contex):base(contex) 
        {
            
        }
    }
}
