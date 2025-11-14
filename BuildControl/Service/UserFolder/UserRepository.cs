using BuildControl.models.DTO;
using BuildControl.Service.Conversions;
using System.Text.Json;
using BuildControl.Models.DAT;

namespace BuildControl.Service.UserFolder
{
    public class UserRepository
    {

        public List<User> GetUserList()
        {
            string fileName = "DB.json";
            using FileStream openStream = File.OpenRead(fileName);
            var userList = JsonSerializer.Deserialize<List<User>>(openStream);

            if (userList == null)
            {
                throw new ArgumentNullException("received a null argument!");
            }

            return userList;

        }
        public void AddValueToDB(UserDto userDto)
        {
            string fileName = "DB.json";
            using FileStream openStream = File.OpenWrite(fileName);
            JsonSerializer.SerializeAsync(openStream, userDto);
        }


        public List<UserDto> GetAll()
        {
            List<UserDto> result = new List<UserDto>();

            var userList = GetUserList();
            for (int i = 0; i < userList.ToArray().Length; i++)
            {

                result.Add(UserConversion.userToUserDto(userList[i]));


            }

            return result;

        }

        public List<UserDto> GetAllUserByTypeAsync(int type)
        {
            List<UserDto> result = new List<UserDto>();

            var userList = GetUserList();



            for (int i = 0; i < userList.ToArray().Length; i++)
            {
                if (userList[i].UserType == type)
                {

                    result.Add(UserConversion.userToUserDto(userList[i]));

                }


            }
            return result;

        }

        public UserDto GetById(int id)
        {
            var userList = GetUserList();
            var selectedUser = userList.Where(x => x.UserId.Equals(id)).FirstOrDefault();

            if (selectedUser == null)
            {
                throw new ArgumentNullException("received a null argument!");

            }


            return UserConversion.userToUserDto(selectedUser);

        }



        public void RemoveValueFromDB(int id)
        {
            var userList = GetUserList();
            userList.RemoveAll(x => x.UserId.Equals(id));

        }


        public void UpdateUserInDB(UserDto userDto)
        {
            var userList = GetUserList();

            var selectedUser = userList.Where(x => x.UserId.Equals(userDto.Id)).FirstOrDefault();
            if (selectedUser == null)
            {
                throw new ArgumentNullException("received a null argument!");
            }

            selectedUser.FirstName = userDto.UserName;
            selectedUser.Password = userDto.Password;
            selectedUser.UserType = userDto.UserType;
            selectedUser.FamilyName = userDto.FamilyName;

            userList.Add(selectedUser);

        }

        public void AddWorkSitesForUser(int userId, List<WorkSiteDto> newSites)
        {
            var existingUser = GetById(userId);
            if (existingUser.UserType != 2)
                throw new InvalidOperationException("User is not a supervisor");
            for (int i = 0; i < newSites.Count; i++)
            {

                existingUser.WorkSites.Add(newSites[i]);


            }


        }

        public void UpdateUserWorkSites(int userId, List<WorkSiteDto> newSites)
        {
            var existingUser = GetById(userId);
            if (existingUser.UserType != 2)
                throw new InvalidOperationException("User is not a supervisor");

            existingUser.WorkSites = newSites;
        }


    }
}

