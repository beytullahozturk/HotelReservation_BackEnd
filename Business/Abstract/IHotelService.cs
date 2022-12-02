using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IHotelService
    {
        IDataResult<List<Hotel>> GetAll();
        IDataResult<Hotel> GetById(int hotelId);
        IResult Add(Hotel hotel);
        IResult Update(Hotel hotel);
        IResult Delete(int hotelId);
    }
}
