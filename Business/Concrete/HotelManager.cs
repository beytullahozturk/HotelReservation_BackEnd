using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class HotelManager : IHotelService
    {
        IHotelDal _hotelDal;
        public HotelManager(IHotelDal hotelDal)
        {
            _hotelDal = hotelDal;
        }
        public IResult Add(Hotel hotel)
        {
            try
            {
                var hotelAdd = new Hotel
                {
                    Name = hotel.Name,
                    City = hotel.City
                };

                _hotelDal.Add(hotelAdd);

                return new SuccessResult(Messages.HotelAdded);
            }
            catch (Exception Ex)
            {
                return new ErrorResult(Ex.Message);
            }
        }

        public IResult Delete(int hotelId)
        {
            try
            {
                var postData = _hotelDal.GetAll();
                var deleteData = postData.Find(p => p.Id == hotelId);
                _hotelDal.Delete(deleteData);
                return new SuccessResult(Messages.HotelDeleted);
            }
            catch (Exception Ex)
            {
                return new ErrorResult(Ex.Message);
            }
        }

        public IDataResult<List<Hotel>> GetAll()
        {
            try
            {
                return new SuccessDataResult<List<Hotel>>(_hotelDal.GetAll(), Messages.HotelListedSuccess);
            }
            catch (Exception Ex)
            {
                return new ErrorDataResult<List<Hotel>>(Ex.Message);
            }
        }

        public IDataResult<Hotel> GetById(int hotelId)
        {
            try
            {
                return new SuccessDataResult<Hotel>(_hotelDal.Get(p => p.Id == hotelId));
            }
            catch (Exception Ex)
            {
                return new ErrorDataResult<Hotel>(Ex.Message);
            }
        }

        public IResult Update(Hotel hotel)
        {
            try
            {
                var postData = _hotelDal.GetAll();
                var updateData = postData.Find(p => p.Id == hotel.Id);

                updateData.Name = hotel.Name;
                updateData.City = hotel.City;

                _hotelDal.Update(updateData);
                return new SuccessResult(Messages.HotelUpdated);
            }
            catch (Exception Ex)
            {
                return new ErrorResult(Ex.Message);
            }
        }
    }
}
