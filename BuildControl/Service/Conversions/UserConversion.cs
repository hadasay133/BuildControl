using BuildControl.models.DTO;
using BuildControl.Models.DAT;

namespace BuildControl.Service.Conversions
{
    public class UserConversion
    {

        public static UserDto userToUserDto(User user)
        {
            if (user == null) return null;
            return new UserDto
            {
                Id = user.UserId,
                UserName = user.FirstName,
                FamilyName = user.FamilyName,
                UserType = user.UserType,
                Password = user.Password

            };
        }

        public static User UserDtoToUser(UserDto userDto)
        {
            if (userDto == null) return null;
            return new User
            {
                UserId = userDto.Id,
                FirstName = userDto.UserName,
                FamilyName = userDto.FamilyName,
                UserType = userDto.UserType,
                Password = userDto.Password

            };
        }
    }
}
