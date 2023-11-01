using GuideFinder.API.Model;
using GuideFinder.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuideFinder.DataAccess.Abstract
{
    public interface IReportService
    {
        ReportType CreateReport(ReportType reportType);

        ReportType GetReportById(Guid UUID);

        List<ReportType> GetAllReport();

    }
}
