using GuideFinder.API.Model;
using GuideFinder.DataAccess.Abstract;
using GuideFinder.Entities;
using GuideFinfer.Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace GuideFinder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpPost("CreateReport")]
        public ReportType Post([FromBody] ReportType report)
        {
            return _reportService.CreateReport(report);
        }

        [HttpGet("{UUID}")]
        public ReportType Get(Guid UUID)
        {
            return _reportService.GetReportById(UUID);
        }

        [HttpGet]
        public List<ReportType> Get()
        {
            return _reportService.GetAllReport();
        }
    }
}
