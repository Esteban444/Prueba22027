using EasyStay.Contracts.Repositories;
using EasyStay.Infraestructure.DataAcces;
using EasyStay.Infrastructure.Repositories;
using EasyStay.Models.Models;

namespace EasyStay.Infraestructure.Repositories
{
    public class RoomRepository: BaseRepository<Room>, IRoomRepository
    {
        public RoomRepository(EasyStayDbContex contex): base(contex) 
        {
            
        }
    }
}
