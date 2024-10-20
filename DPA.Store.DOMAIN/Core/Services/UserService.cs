using DPA.Store.DOMAIN.Core.DTO;
using DPA.Store.DOMAIN.Core.Entities;
using DPA.Store.DOMAIN.Core.Interfaces;

namespace DPA.Store.DOMAIN.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJWTService _jwtService;
        public UserService(IUserRepository userRepository, IJWTService jwtService)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
        }



        public async Task<UserResponseAuthDTO> SignIn(string email, string pwd)
        {
            var user = await _userRepository.SignIn(email, pwd);
            if (user == null)
                return null;

            //TODO: implementar token & email
            var token = _jwtService.GenerateJWToken(user);
            var sendEmail = false;

            var userResponseAuth = new UserResponseAuthDTO()
            {
                Id = user.Id,
                Email = email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Country = user.Country,
                DateOfBirth = user.DateOfBirth,
                Token = token,
                IsEmailSent = sendEmail,
                Address = user.Address
            };
            return userResponseAuth;
        }

        public async Task<bool> Insert(User user)
        {
            return await _userRepository.Insert(user);
        }
    }
}
