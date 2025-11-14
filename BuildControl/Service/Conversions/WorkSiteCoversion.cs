using BuildControl.models.DAT;
using BuildControl.models.DTO;

namespace BuildControl.Service.Conversions
{
    public class WorkSiteCoversion
    {
        public static WorkSiteDto workSitToWorkSitDto(WorkSite workSite)
        {
            if (workSite == null) return null;
            return new WorkSiteDto
            {
                Id = workSite.Id,
                WorkSiteName = workSite.WorkSiteName
            };
        }

        public static WorkSite workSitDtoToWorkSit(WorkSiteDto workSiteDto)
        {
            if (workSiteDto == null) return null;
            return new WorkSite
            {
                Id = workSiteDto.Id,
                WorkSiteName = workSiteDto.WorkSiteName

            };
        }
    }
}
