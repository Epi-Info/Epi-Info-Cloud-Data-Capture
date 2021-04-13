﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epi.Web.Enter.Common.BusinessObject;
using Epi.Web.Enter.Common.Criteria;
using System.Configuration;
using Epi.Web.Enter.Common.Exception;

namespace Epi.Web.BLL
{
    
    public class Report
    {
        public Epi.Web.Enter.Interfaces.DataInterfaces.IReportDao ReportDao;
        public Report(Epi.Web.Enter.Interfaces.DataInterfaces.IReportDao pReportDao)
        {
            this.ReportDao = pReportDao;
        }

        public void PublishReport(ReportInfoBO reportBO)
        {
            this.ReportDao.PublishReport(reportBO);
        }

        public List<ReportInfoBO> GetSurveyReports(string SurveyID , bool IncludHTML) {

            List<ReportInfoBO> List = new List<ReportInfoBO>();


            List = this.ReportDao.GetSurveyReports(SurveyID , IncludHTML);


            return List;


        }
        public List<ReportInfoBO> GetReport(string ReportID)
        {
            List<ReportInfoBO> List = new List<ReportInfoBO>();
          
            List = this.ReportDao.GetReport(ReportID);

            return List;


        }
        public void DeleteReport(ReportInfoBO reportBO)
        {
            this.ReportDao.DeleteReport(reportBO);
        }
    }
}
