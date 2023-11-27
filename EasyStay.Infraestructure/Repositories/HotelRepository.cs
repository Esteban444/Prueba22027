using EasyStay.Contracts.Repositories;
using EasyStay.Infraestructure.DataAcces;
using EasyStay.Infrastructure.Repositories;
using EasyStay.Models.Models;

namespace EasyStay.Infraestructure.Repositories
{
    public class HotelRepository : BaseRepository<Hotel>, IHotelRepository
    {
        public HotelRepository(EasyStayDbContex contex) : base(contex)
        {

        }
    }
}
