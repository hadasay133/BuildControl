using BuildControl.models.DAT;
using BuildControl.models.DTO;
using BuildControl.Service.Conversions;


namespace BuildControl.Service.workSiteFolder
{
    public class WorkSiteManegmentScreen
    {


       private static WorkSiteRepository workSiteRepositor=new WorkSiteRepository();


        public static List<WorkSiteDto> GetAll()
        {
            return workSiteRepositor.GetAll();
        }

        public static void UpdateWorkSite(WorkSite worksite )
        {
            

            workSiteRepositor.UpdateValueInDB(WorkSiteCoversion.workSitToWorkSitDto(worksite));
        }

        public static void DeleteWorkSite(int id)
        {


            workSiteRepositor.RemoveValueFromDB(id);
        }

        public static void AddWorkSite(WorkSite worksite)
        {


            workSiteRepositor.AddValueToDB(WorkSiteCoversion.workSitToWorkSitDto(worksite));
        }

        public static WorkSiteDto GetWorkSiteById(int id)
        {


             return  workSiteRepositor.GetById(id);
        }

       
    }
}
