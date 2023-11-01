using GuideFinder.DataAccess.Abstract;
using GuideFinder.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuideFinder.DataAccess.Concrete
{
    public class GuideRepository : IGuideRepository
    {
        public Guide CreateGuide(Guide guide)
        {
            using (var GuideDbContext = new GuideDbContext())
            {
                GuideDbContext.Guides.Add(guide);
                GuideDbContext.SaveChanges();
                return guide;
            }
        }

        public void DeleteGuide(int Id)
        {
            using (var GuideDbContext = new GuideDbContext())
            {
                var deletedGuide = GetGuideById(Id);
                GuideDbContext.Guides.Remove(deletedGuide);
                GuideDbContext.SaveChanges();
            }
        }

        public List<Guide> GetAllGuides()
        {
            using (var GuideDbContext = new GuideDbContext())
            {
                return GuideDbContext.Guides.ToList();
            }
        }

        public Guide GetGuideById(int Id)
        {
            using (var GuideDbContext = new GuideDbContext())
            {
                return GuideDbContext.Guides.Find(Id);
            }
        }

        public Guide UpdateGuide(Guide guide)
        {
            using (var GuideDbContext = new GuideDbContext())
            {
                GuideDbContext.Guides.Update(guide);
                GuideDbContext.SaveChanges();
                return guide;

            }
        }

    }
}
