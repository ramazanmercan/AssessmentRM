using GuideFinder.DataAccess.Abstract;
using GuideFinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GuideFinder.DataAccess.Concrete
{
    public class GuideDetailRepository : IGuideDetailRepository
    {
        public GuideDetail CreateGuideDetail(GuideDetail guidedetail)
        {
            using (var GuideDbContext = new GuideDbContext())
            {
                GuideDbContext.GuideDetails.Add(guidedetail);
                GuideDbContext.SaveChanges();
                return guidedetail;
            }
        }

        public void DeleteGuideDetail(int Id)
        {
            using (var GuideDbContext = new GuideDbContext())
            {
                var deletedGuide = GetGuideDetailById(Id);
                GuideDbContext.GuideDetails.Remove(deletedGuide);
                GuideDbContext.SaveChanges();
            }
        }

        public List<GuideDetail> GetAllGuideDetails()
        {
            using (var GuideDbContext = new GuideDbContext())
            {
                return GuideDbContext.GuideDetails.ToList();
            }
        }

        public GuideDetail GetGuideDetailById(int Id)
        {
            using (var GuideDbContext = new GuideDbContext())
            {
                return GuideDbContext.GuideDetails.Find(Id);
            }
        }

        public List<GuideDetail> GetGuideDetails(int guideId)
        {
            using (var GuideDbContext = new GuideDbContext())
            {
                return GuideDbContext.GuideDetails.Where(x => x.GuideId == guideId).ToList();
            }
        }

        public GuideDetail UpdateGuideDetail(GuideDetail guide)
        {
            using (var GuideDbContext = new GuideDbContext())
            {
                GuideDbContext.GuideDetails.Update(guide);
                GuideDbContext.SaveChanges();
                return guide;
            }
        }

    }
}
