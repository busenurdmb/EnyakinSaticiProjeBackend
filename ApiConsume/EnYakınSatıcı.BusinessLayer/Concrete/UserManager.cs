
using Core.Entities.Concrete;

using En_YakınSatıcı.DataAccesLayer.Abstract;
using EnYakınSatıcı.BusinessLayer.Abstract;
using EnYakınSatıcı.Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnYakınSatıcı.BusinessLayer.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        public void Add(User user)
        {
            _userDal.Add(user);
        }

        public IDataResult<User> GetByMaill(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Email == email));
        }

        public IDataResult<User> GetById(int userid)
        {
            return new SuccessDataResult<User>(_userDal.Get(x=>x.UserId== userid));
        }

        public User GetByMail(string email)
        {
            return _userDal.Get(u=>u.Email == email);
        }
    }
}
