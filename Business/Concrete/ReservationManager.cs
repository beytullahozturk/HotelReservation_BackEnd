using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ReservationManager : IReservationService
    {
        IReservationDal _reservationDal;
        public ReservationManager(IReservationDal reservationDal)
        {
            _reservationDal = reservationDal;
        }
        public IResult Add(Reservation reservation)
        {
            try
            {
                var reservationAdd = new Reservation
                {
                    CustomerId = reservation.CustomerId,
                    HotelId = reservation.HotelId,
                    Start_Date = reservation.Start_Date,
                    End_Date = reservation.End_Date
                };

                _reservationDal.Add(reservationAdd);

                return new SuccessResult(Messages.ReservationAdded);
            }
            catch (Exception Ex)
            {
                return new ErrorResult(Ex.Message);
            }
        }

        public IResult Delete(int reservationId)
        {
            try
            {
                var postData = _reservationDal.GetAll();
                var deleteData = postData.Find(p => p.Id == reservationId);
                _reservationDal.Delete(deleteData);
                return new SuccessResult(Messages.ReservationDeleted);
            }
            catch (Exception Ex)
            {
                return new ErrorResult(Ex.Message);
            }
        }

        public IDataResult<List<Reservation>> GetAll()
        {
            try
            {
                return new SuccessDataResult<List<Reservation>>(_reservationDal.GetAll(), Messages.ReservationListedSuccess);
            }
            catch (Exception Ex)
            {
                return new ErrorDataResult<List<Reservation>>(Ex.Message);
            }
        }

        public IDataResult<Reservation> GetById(int reservationId)
        {
            try
            {
                return new SuccessDataResult<Reservation>(_reservationDal.Get(p => p.Id == reservationId));
            }
            catch (Exception Ex)
            {
                return new ErrorDataResult<Reservation>(Ex.Message);
            }
        }

        public IResult Update(Reservation reservation)
        {
            try
            {
                var postData = _reservationDal.GetAll();
                var updateData = postData.Find(p => p.Id == reservation.Id);

                updateData.CustomerId = reservation.CustomerId;
                updateData.HotelId = reservation.HotelId;
                updateData.Start_Date = reservation.Start_Date;
                updateData.End_Date = reservation.End_Date;

                _reservationDal.Update(updateData);
                return new SuccessResult(Messages.ReservationUpdated);
            }
            catch (Exception Ex)
            {
                return new ErrorResult(Ex.Message);
            }
        }
    }
}
