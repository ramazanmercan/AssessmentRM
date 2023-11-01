using GuideFinder.DataAccess.Abstract;
using GuideFinder.DataAccess.Concrete;
using GuideFinder.Entities;
using GuideFinfer.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuideFinder.Business.Concrete
{
    public class GuideManager : IGuideService
    {
        private IGuideRepository _guideRepository;

        public GuideManager(IGuideRepository guideRepository)
        {
            _guideRepository = guideRepository;
        }

        public Guide CreateGuide(Guide guide)
        {
            return _guideRepository.CreateGuide(guide);
        }

        public void DeleteGuide(int Id)
        {
            _guideRepository.DeleteGuide(Id);
        }

        public List<Guide> GetAllGuides()
        {
            return _guideRepository.GetAllGuides();
        }

        public Guide GetGuideById(int Id)
        {
            return _guideRepository.GetGuideById(Id);
        }

        public Guide UpdateGuide(Guide guide)
        {
            return _guideRepository.UpdateGuide(guide);
        }


    }
}
