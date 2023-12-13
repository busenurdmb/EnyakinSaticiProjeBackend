using Core.Entities.Concrete;

using EnYakınSatıcı.Core.Utilities.Results;
using EnYakınSatıcı.Core.Utilities.Security.JWT;
using EnYakınSatıcı.EntityLayer.DTOs;
using System;
using System.Text;

namespace EnYakınSatıcı.BusinessLayer.Abstract
{

    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
