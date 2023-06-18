using AutoMapper;
using WeatherReport.Domain.Mapper;
using WeatherReport.Domain.Service.User.Dto;
using WeatherReport.Domain.Service.User.Entities;
using WeatherReport.SharedKernel.Utils;
using WeatherReport.SharedKernel.Utils.Enums;
using WeatherReport.SharedKernel.Utils.Notifications;

namespace WeatherReport.Domain.Service.User
{
    public class UserService : IUserService
    {
        IMapper mapper = AutoMapperProfile.Initialize();
        private readonly INotification _notification;
        private readonly IUserRepository _userRepository;
        private readonly UserLoggedData _userLoggedData;

        public UserService(INotification notification, IUserRepository userRepository, UserLoggedData userLoggedData)
        {
            _notification = notification;
            _userRepository = userRepository;
            _userLoggedData = userLoggedData;
        }

        public bool Allow(int id)
        {
            var user = _userRepository.GetById(id);
            if (user == null)
                return _notification.AddWithReturn<bool>(ConfigureEnum.GetEnumDescription(UserEnum.IncorrectUsernameOrPassword));

            _userLoggedData.Add(user.Id);

            return true;
        }

        public UserDto Post(UserDto userDto)
        {
            if (string.IsNullOrEmpty(userDto.Name))
                return _notification.AddWithReturn<UserDto>(ConfigureEnum.GetEnumDescription(UserEnum.FieldNameEmpty));

            if (string.IsNullOrEmpty(userDto.Email))
                return _notification.AddWithReturn<UserDto>(ConfigureEnum.GetEnumDescription(UserEnum.FieldEmailEmpty));

            if (string.IsNullOrEmpty(userDto.Password))
                return _notification.AddWithReturn<UserDto>(ConfigureEnum.GetEnumDescription(UserEnum.FieldPasswordEmpty));

            if (userDto.IdCity < 0)
                return _notification.AddWithReturn<UserDto>(ConfigureEnum.GetEnumDescription(UserEnum.FieldCityEmpty));

            //conferir de já está cadastrado

            var userEntity = mapper.Map<UserEntity>(userDto); 

            var userPost = _userRepository.Post(userEntity);

            var userDtoModel = mapper.Map<UserDto>(userPost);

            return userDtoModel;
        }
    }
}
