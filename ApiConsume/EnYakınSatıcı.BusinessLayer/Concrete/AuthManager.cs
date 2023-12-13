﻿
using Core.Entities.Concrete;
using En_YakınSatıcı.DataAccesLayer.Abstract;
using EnYakınSatıcı.BusinessLayer.Abstract;
using EnYakınSatıcı.Core.Utilities.Results;
using EnYakınSatıcı.Core.Utilities.Security.Hashing;
using EnYakınSatıcı.Core.Utilities.Security.JWT;
using EnYakınSatıcı.EntityLayer.DTOs;

namespace EnYakınSatıcı.BusinessLayer.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;
       

		public AuthManager(IUserService userService, ITokenHelper tokenHelper)
		{
			_userService = userService;
			_tokenHelper = tokenHelper;
		
		}

		public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName=userForRegisterDto.LastName,
                 Şehir = userForRegisterDto.Şehir,
                 İlçe = userForRegisterDto.İlçe,
                 Köy = userForRegisterDto.Köy,
                 Telefon = userForRegisterDto.Telefon,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user, "Kayıt oldu");
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>("Kullanıcı bulunamadı");
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>("Parola hatası");
            }
           
            return new SuccessDataResult<User>(userToCheck, "Başarılı giriş");
        }

        public IResult UserExists(string email)
        {
            if (_userService.GetByMail(email) != null)
            {
                return new ErrorResult("Kullanıcı mevcut");
            }
            return new SuccessResult();
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken, "Token oluşturuldu");
        }
    }
}
