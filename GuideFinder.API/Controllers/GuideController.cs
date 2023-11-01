using GuideFinder.Business.Concrete;
using GuideFinder.Entities;
using GuideFinfer.Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GuideFinder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuideController : ControllerBase
    {
        private IGuideService _guideService;

        public GuideController(IGuideService guideService)
        {
            _guideService = guideService;
        }


        [HttpGet]
        public List<Guide> Get()
        {
            return _guideService.GetAllGuides();
        }

        [HttpGet("{id}")]
        public Guide Get(int id)
        {
            return _guideService.GetGuideById(id);
        }


        [HttpPost]
        public Guide Post([FromBody] Guide guide)
        {
            return _guideService.CreateGuide(guide);
        }


        [HttpPut]
        public Guide Put([FromBody] Guide guide)
        {
            return _guideService.UpdateGuide(guide);
        }

        [HttpDelete]
        public void Delete(int Id)
        {
            _guideService.DeleteGuide(Id);
        }
    }
}
