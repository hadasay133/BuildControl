using BuildControl.models.DAT;
using BuildControl.models.DTO;
using BuildControl.Models.DAT;
using BuildControl.Service.Conversions;

namespace BuildControl.Service.UserFolder
{
    public class SupervisorManagementScreen
    {

        private static UserRepository userRepository = new UserRepository();

        public static void AddUser(User user)
        {
            UserDto userDto = UserConversion.userToUserDto(user);
            userRepository.AddValueToDB(userDto);


        }

        public static void DeleteUser(int id)
        {

            userRepository.RemoveValueFromDB(id);



        }

        public static List<UserDto> GetAll()
        {
            return userRepository.GetAllUserByTypeAsync(2);
        }


        public static UserDto GetById(int id)
        {
            return userRepository.GetById(id);
        }

        public static void UpdateUser(User user)
        {
            UserDto userDto = UserConversion.userToUserDto(user);
            userRepository.UpdateUserInDB(userDto);
        }


        public static void AddWorkSitesForUser(int userId, List<WorkSite> newSites)
        {

            List<WorkSiteDto> newList = new List<WorkSiteDto>();
            for (int i = 0; i < newSites.Count; i++)
            {

                newList.Add(WorkSiteCoversion.workSitToWorkSitDto(newSites[i]));


            }
            userRepository.UpdateUserWorkSites(userId, newList);


        }

        public static void UpdateWorkSitesForUser(int userId, List<WorkSite> newSites)
        {

            List<WorkSiteDto> newList = new List<WorkSiteDto>();

            for (int i = 0; i < newSites.Count; i++)
            {

                newList.Add(WorkSiteCoversion.workSitToWorkSitDto(newSites[i]));


            }
            userRepository.AddWorkSitesForUser(userId, newList);


        }
    }
}

