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
    
    public partial class familyset
    {
        public System.Guid SurveyId { get; set; }
        public int OwnerId { get; set; }
        public string SurveyNumber { get; set; }
        public int SurveyTypeId { get; set; }
        public System.DateTime ClosingDate { get; set; }
        public string SurveyName { get; set; }
        public string OrganizationName { get; set; }
        public string DepartmentName { get; set; }
        public string IntroductionText { get; set; }
        public string TemplateXML { get; set; }
        public string ExitText { get; set; }
        public System.Guid UserPublishKey { get; set; }
        public long TemplateXMLSize { get; set; }
        public System.DateTime DateCreated { get; set; }
        public int OrganizationId { get; set; }
        public bool IsDraftMode { get; set; }
        public System.DateTime StartDate { get; set; }
        public Nullable<System.Guid> ParentId { get; set; }
        public Nullable<int> ViewId { get; set; }
        public Nullable<bool> IsSQLProject { get; set; }
    }
}
