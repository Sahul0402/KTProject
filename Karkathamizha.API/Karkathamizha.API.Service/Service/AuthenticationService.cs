using Karkathamizha.API.IRepository;
using Karkathamizha.API.IService;
using Karkathamizha.API.IService.Common;
using Karkathamizha.API.Model;
using Karkathamizha.API.Service.ServiceConfiguration;
using KarkaThamizha.API.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karkathamizha.API.Service.Service
{
    internal class AuthenticationService : IAuthenticationService
    {
        private readonly ICommonRepository _commonRepository;
        private readonly IAuthenticationRepository _authenticationRepository;
        private readonly IUserRepository _userRepository;
        private readonly ITokenGeneration _tokenGeneration;
        private readonly IEmailService _emailService;

        public AuthenticationService(IAuthenticationRepository authenticationRepository, IUserRepository userRepository, ICommonRepository commonRepository, ITokenGeneration tokenGeneration, IEmailService emailService)
        {
            _authenticationRepository = authenticationRepository;
            _userRepository = userRepository;
            _commonRepository = commonRepository;
            _tokenGeneration = tokenGeneration;
            _emailService = emailService;
        }

        public async Task<int> Registeration(Register model)
        {
            bool isMailExists = await _commonRepository.IsEmailExists(model.Email);
            if (isMailExists)
            {
                throw new ApplicationException("Email is not exists");
            }
            var userInfo = await _authenticationRepository.Registeration(model);
            return userInfo;
        }

        public async Task<LoginSuccess> Login(Login login)
        {
            LoginSuccess response = new LoginSuccess();
            var user = await _userRepository.GetUserByEmailId(login.Email.Trim().ToLower());
            if (user == null)
            {
                throw new ApplicationException("Email not found");
            }

            //var passwordHash = PasswordHash.HashPasword(login.Password, out byte[] salt);

            //if (userInfo.Password != passwordHash)
            //{
            //    throw new ApplicationException("Invalid Password");
            //}

            // authentication successful so generate jwt token
            var token = await _tokenGeneration.GenerateJwtToken(user);
            response.Token = token;
            response.UserInfo = user;
            return response;
        }

        public async Task<LoginSuccess> ForgotPassword(Login login)
        {
            LoginSuccess response = new LoginSuccess();
            var userInfo = await _userRepository.GetUserByEmailId(login.Email.Trim().ToLower());
            if (userInfo == null)
            {
                throw new ApplicationException("Email not found");
            }
            else
            {
                _emailService.SendForgotPasswordEmail(login.Email.Trim().ToLower());
            }

            // authentication successful so generate jwt token
            var token = await _tokenGeneration.GenerateJwtToken(userInfo);
            response.Token = token;
            response.UserInfo = userInfo;
            return response;
        }
    }
}
