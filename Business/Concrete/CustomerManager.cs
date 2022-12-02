using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Add(Customer customer)
        {
            try
            {
                var customerAdd = new Customer
                {
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Address = customer.Address,
                    Phone = customer.Phone,
                    Email = customer.Email,
                };

                _customerDal.Add(customerAdd);

                return new SuccessResult(Messages.CustomerAdded);
            }
            catch (Exception Ex)
            {
                return new ErrorResult(Ex.Message);
            }
        }

        public IResult Delete(int customerId)
        {
            try
            {
                var postData = _customerDal.GetAll();
                var deleteData = postData.Find(p => p.Id == customerId);
                _customerDal.Delete(deleteData);
                return new SuccessResult(Messages.CustomerDeleted);
            }
            catch (Exception Ex)
            {
                return new ErrorResult(Ex.Message);
            }
        }

        public IDataResult<List<Customer>> GetAll()
        {
            try
            {
                return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Messages.CustomerListedSuccess);
            }
            catch (Exception Ex)
            {
                return new ErrorDataResult<List<Customer>>(Ex.Message);
            }
        }

        public IDataResult<Customer> GetById(int customerId)
        {
            try
            {
                return new SuccessDataResult<Customer>(_customerDal.Get(p => p.Id == customerId));
            }
            catch (Exception Ex)
            {
                return new ErrorDataResult<Customer>(Ex.Message);
            }
        }

        public IResult Update(Customer customer)
        {
            try
            {
                var postData = _customerDal.GetAll();
                var updateData = postData.Find(p => p.Id == customer.Id);

                updateData.FirstName = customer.FirstName;
                updateData.LastName = customer.LastName;
                updateData.Address = customer.Address;
                updateData.Phone = customer.Phone;
                updateData.Email = customer.Email;

                _customerDal.Update(updateData);
                return new SuccessResult(Messages.CustomerUpdated);
            }
            catch (Exception Ex)
            {
                return new ErrorResult(Ex.Message);
            }
        }
    }
}
