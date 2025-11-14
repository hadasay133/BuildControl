using BuildControl.models.DAT;
using BuildControl.models.DTO;
using BuildControl.Service.Conversions;
using System.Text.Json;

namespace BuildControl.Service.workSiteFolder
{
    public class WorkSiteRepository : IJsonAction<WorkSiteDto>
    {

        private List<WorkSite> GetWorkSiteList()
        {
            string fileName = "DB.json";
            using FileStream openStream = File.OpenRead(fileName);
            var workSiteList = JsonSerializer.Deserialize<List<WorkSite>>(openStream);

            if (workSiteList == null)
            {
                throw new ArgumentNullException("received a null argument!");
            }

            return workSiteList;

        }
        public void AddValueToDB(WorkSiteDto workSiteDto)
            
        {
            if (workSiteDto == null) {
                throw new ArgumentNullException("received a null argument!");

            }
            string fileName = "DB.json";
            using FileStream openStream = File.OpenWrite(fileName);
            JsonSerializer.SerializeAsync(openStream, workSiteDto);

        }

        public List<WorkSiteDto> GetAll()
        {
            List<WorkSiteDto> result = new List<WorkSiteDto>();

            var workSiteList = GetWorkSiteList();
            for (int i = 0; i < workSiteList.ToArray().Length; i++)
            {
                

                result.Add(WorkSiteCoversion.workSitToWorkSitDto(workSiteList[i]));


            }

            return result;
        }

        public WorkSiteDto GetById(int id)
        {
            var workSiteList = GetWorkSiteList();
            var selectedWorkSite = workSiteList.Where(x => x.Id.Equals(id)).FirstOrDefault();

            if (selectedWorkSite == null)
            {
                throw new ArgumentNullException("received a null argument!");

            }


         return   WorkSiteCoversion.workSitToWorkSitDto(selectedWorkSite);
        }

        public void RemoveValueFromDB(int id)
        {
            var workSiteList = GetWorkSiteList();
            workSiteList.RemoveAll(x => x.Id.Equals(id));
        }

        public void UpdateValueInDB(WorkSiteDto workSiteDto)
        {
            var workSiteList = GetWorkSiteList();
            var selectedWorkSite = workSiteList.Where(x => x.Id.Equals(workSiteDto.Id)).FirstOrDefault();
            if (selectedWorkSite == null)
            {
                throw new ArgumentNullException("received a null argument!");
            }
            selectedWorkSite.WorkSiteName = workSiteDto.WorkSiteName;
           
        }
    }
}
