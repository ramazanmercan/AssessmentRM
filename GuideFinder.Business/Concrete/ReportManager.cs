using GuideFinder.API.Model;
using GuideFinder.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuideFinder.Business.Concrete
{
    public class ReportManager : IReportService
    {

        private IReportRepository _reportRepository;

        public ReportManager(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        public ReportType CreateReport(ReportType reportType)
        {
            return _reportRepository.CreateReport(reportType);
        }

        public List<ReportType> GetAllReport()
        {
            return _reportRepository.GetAllReport();
        }

        public ReportType GetReportById(Guid UUID)
        {
            return _reportRepository.GetReportById(UUID);
        }

    }
}
