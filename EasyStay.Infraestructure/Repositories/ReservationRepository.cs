using EasyStay.Contracts.Repositories;
using EasyStay.Infraestructure.DataAcces;
using EasyStay.Infrastructure.Repositories;
using EasyStay.Models.Models;

namespace EasyStay.Infraestructure.Repositories
{
    public class ReservationRepository: BaseRepository<Reservation>, IReservationRepository
    {
        public ReservationRepository(EasyStayDbContex contex): base(contex)
        {
            
        }
    }
}
