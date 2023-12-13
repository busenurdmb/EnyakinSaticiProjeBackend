using Core.Entities.Concrete;
using En_YakınSatıcı.DataAccesLayer.Abstract;
using EnYakınSatıcı.Core.DataAcces.EntityFramework;
using EnYakınSatıcı.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace En_YakınSatıcı.DataAccesLayer.Concrete.EntityFramework
{
	public class EfOperationClaimsDal : EfEntityRepositoryBase<UserOperationClaim, EnYakınSatıcıContext>, IOperationClaimsDal
	{
	}
}
