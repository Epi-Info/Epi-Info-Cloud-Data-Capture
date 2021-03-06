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
    
    public partial class SurveyMetaData
    {
        public SurveyMetaData()
        {
            this.Users = new HashSet<User>();
            this.ResponseDisplaySettings = new HashSet<ResponseDisplaySetting>();
            this.SurveyMetaData1 = new HashSet<SurveyMetaData>();
            this.SurveyMetaDataTransforms = new HashSet<SurveyMetaDataTransform>();
            this.EIDatasources = new HashSet<EIDatasource>();
            this.SurveyResponses = new HashSet<SurveyResponse>();
            this.Organizations = new HashSet<Organization>();
            this.SurveyReportsInfoes = new HashSet<SurveyReportsInfo>();
        }
    
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
        public Nullable<bool> IsShareable { get; set; }
        public Nullable<int> DataAccessRuleId { get; set; }
        public Nullable<bool> ShowAllRecords { get; set; }
        public Nullable<System.DateTime> LastUpdate { get; set; }
    
        public virtual lk_SurveyType lk_SurveyType { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<ResponseDisplaySetting> ResponseDisplaySettings { get; set; }
        public virtual ICollection<SurveyMetaData> SurveyMetaData1 { get; set; }
        public virtual SurveyMetaData SurveyMetaData2 { get; set; }
        public virtual ICollection<SurveyMetaDataTransform> SurveyMetaDataTransforms { get; set; }
        public virtual ICollection<EIDatasource> EIDatasources { get; set; }
        public virtual ICollection<SurveyResponse> SurveyResponses { get; set; }
        public virtual ICollection<Organization> Organizations { get; set; }
        public virtual DataAccessRule DataAccessRule { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual ICollection<SurveyReportsInfo> SurveyReportsInfoes { get; set; }
    }
}
