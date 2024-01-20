using Karkathamizha.API.IRepository;
using Karkathamizha.API.IService;
using Karkathamizha.API.Model;
using KarkaThamizha.API.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karkathamizha.API.Service.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICommonRepository _commonRepository;

        public UserService(IUserRepository userRepository, ICommonRepository commonRepository)
        {
            _userRepository = userRepository;
            _commonRepository = commonRepository;
        }
        #region User
        public async Task<int> AddUpdateUser(User model)
        {
            if (model.UserId == 0)
            {
                bool isMailExists = await _commonRepository.IsEmailExists(model.Email);
                if (isMailExists)
                {
                    throw new ApplicationException("Email is not exists");
                }
            }
            var userInfo = await _userRepository.AddUpdateUser(model);
            return userInfo;
        }
        
        public Task<string> DeleteUser(int id)
        {
            return _userRepository.DeleteUser(id);
        }

        public Task<IEnumerable<User>> GetAll()
        {
            return _userRepository.GetAll();
        }

        public Task<User> GetUserById(int id)
        {
            return _userRepository.GetUserById(id);
        }
        #endregion
    }
}
