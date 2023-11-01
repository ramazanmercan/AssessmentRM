using GuideFinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuideFinfer.Business.Abstract
{
    public interface IGuideService
    {
        List<Guide> GetAllGuides();

        Guide GetGuideById(int Id);

        Guide CreateGuide(Guide guide);

        Guide UpdateGuide(Guide guide);

        void DeleteGuide(int Id);
    }
}
