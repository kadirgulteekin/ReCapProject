using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UsersManager : IUsersService
    {
        IUserDal _usersDal;

        public UsersManager(IUserDal usersDal)
        {
            _usersDal = usersDal;
        }

        public IResult Add(User users)
        {
            if (users.FirstName ==  null )
            {
                return new ErrorResult(Messages.CarNameInValid);
            }
            _usersDal.Add(users);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(User users)
        {
            _usersDal.Delete(users);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            if (DateTime.Now.Hour == 21)
            {
                return new ErrorDataResult<List<User>>(Messages.MaintananceTime);
            }

            return new SuccessDataResult<List<User>>(_usersDal.GetAll(), Messages.CarsListed);
        }

        public IDataResult<User> GetById(int Id)
        {
            return new SuccessDataResult<User>(_usersDal.Get(p => p.UserId == Id));
        }

        public IResult Update(User users)
        {

            _usersDal.Update(users);
            return new SuccessResult(Messages.CarUpdated);
        }

       
    }
}
