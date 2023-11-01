using GuideFinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuideFinder.DataAccess.Abstract
{
    public interface IGuideDetailRepository
    {
        List<GuideDetail> GetAllGuideDetails();

        List<GuideDetail> GetGuideDetails(int guideId);

        GuideDetail GetGuideDetailById(int Id);

        GuideDetail CreateGuideDetail(GuideDetail guide);

        GuideDetail UpdateGuideDetail(GuideDetail guide);

        void DeleteGuideDetail(int Id);
    }
}
