//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Epi.Web.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class SurveyReport
    {
        public System.Guid ReportId { get; set; }
        public System.Guid GadgetId { get; set; }
        public int GadgetNumber { get; set; }
        public int GadgetVersion { get; set; }
        public string ReportHtml { get; set; }
        public System.DateTime DateCreated { get; set; }
        public System.DateTime DateEdited { get; set; }
    
        public virtual SurveyReportsInfo SurveyReportsInfo { get; set; }
    }
}