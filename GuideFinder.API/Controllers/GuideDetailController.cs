using GuideFinder.Business.Concrete;
using GuideFinder.Entities;
using GuideFinfer.Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GuideFinder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuideDetailController : ControllerBase
    {
        private IGuideDetailService _guideDetailService;


        public GuideDetailController(IGuideDetailService guideDetailService)
        {
            _guideDetailService = guideDetailService;
        }

        [HttpGet]
        public List<GuideDetail> Get()
        {
            return _guideDetailService.GetAllGuideDetails();
        }

        [HttpGet("{id}")]
        public GuideDetail Get(int id)
        {

            return _guideDetailService.GetGuideDetailById(id);
        }

        [HttpPost]
        public GuideDetail Post([FromBody] GuideDetail guide)
        {
            return _guideDetailService.CreateGuideDetail(guide);
        }

        [HttpPut]
        public GuideDetail Put([FromBody] GuideDetail guide)
        {
            return _guideDetailService.UpdateGuideDetail(guide);
        }
        [HttpDelete]
        public void Delete(int Id)
        {
            _guideDetailService.DeleteGuideDetail(Id);
        }

        [HttpGet("GetGuideDetails")]
        public List<GuideDetail> GetAllGuideDetails(int guideId)
        {
            return _guideDetailService.GetGuideDetails(guideId);
        }
    }
}
