using Core.Entities.Concrete;
using En_YakınSatıcı.DataAccesLayer.Abstract;
using EnYakınSatıcı.Core.DataAcces.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace En_YakınSatıcı.DataAccesLayer.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, EnYakınSatıcıContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new EnYakınSatıcıContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.OperationClaimId equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.UserId
                             select new OperationClaim { OperationClaimId = operationClaim.OperationClaimId, Name = operationClaim.Name };
                return result.ToList();

            }
        }
    }
}
