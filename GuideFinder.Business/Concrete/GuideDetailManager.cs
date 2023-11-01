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
    public class GuideDetailManager : IGuideDetailService
    {
        private IGuideDetailRepository _guideDetailRepository;

        public GuideDetailManager(IGuideDetailRepository guideDetailRepository)
        {
            _guideDetailRepository = guideDetailRepository;
        }

        public GuideDetail CreateGuideDetail(GuideDetail guideDetail)
        {
            return _guideDetailRepository.CreateGuideDetail(guideDetail);
        }

        public void DeleteGuideDetail(int Id)
        {
            _guideDetailRepository.DeleteGuideDetail(Id);
        }

        public List<GuideDetail> GetAllGuideDetails()
        {
            return _guideDetailRepository.GetAllGuideDetails();
        }

        public GuideDetail GetGuideDetailById(int Id)
        {
            return _guideDetailRepository.GetGuideDetailById(Id);
        }

        public List<GuideDetail> GetGuideDetails(int guideId)
        {
            return _guideDetailRepository.GetGuideDetails(guideId) ;
        }

        public GuideDetail UpdateGuideDetail(GuideDetail guideDetail)
        {
            return _guideDetailRepository.UpdateGuideDetail(guideDetail);
        }

    }
}
