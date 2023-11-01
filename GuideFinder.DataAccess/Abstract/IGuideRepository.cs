using GuideFinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuideFinder.DataAccess.Abstract
{
    public interface IGuideRepository
    {
        List<Guide> GetAllGuides();

        Guide GetGuideById(int Id);

        Guide CreateGuide(Guide guide);

        Guide UpdateGuide(Guide guide);

        void DeleteGuide(int Id);
    }
}
