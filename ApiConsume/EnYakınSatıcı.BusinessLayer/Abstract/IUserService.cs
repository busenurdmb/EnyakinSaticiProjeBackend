using Core.Entities.Concrete;
using EnYakınSatıcı.Core.Utilities.Results;
using EnYakınSatıcı.EntityLayer.Concrete;
using System.Collections.Generic;

namespace EnYakınSatıcı.BusinessLayer.Abstract
{
    public interface IUserService
    {
        List<OperationClaim> GetClaims(User user);
        IDataResult<User> GetById(int userid);
        void Add(User user);
        User GetByMail(string email);
        public IDataResult<User> GetByMaill(string email);

    }
}
