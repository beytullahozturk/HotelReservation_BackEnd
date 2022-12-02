using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IReservationService
    {
        IDataResult<List<Reservation>> GetAll();
        IDataResult<Reservation> GetById(int reservationId);
        IResult Add(Reservation reservation);
        IResult Update(Reservation reservation);
        IResult Delete(int reservationId);
    }
}
