﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class OSELS_EWEEntities : DbContext
    {
        public OSELS_EWEEntities()
            : base("name=OSELS_EWEEntities")
        {
        }
        public OSELS_EWEEntities(string connectionstring) : base(connectionstring)
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<lk_Status> lk_Status { get; set; }
        public DbSet<lk_SurveyType> lk_SurveyType { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<SurveyMetaData> SurveyMetaDatas { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ResponseDisplaySetting> ResponseDisplaySettings { get; set; }
        public DbSet<ResponseXml> ResponseXmls { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserOrganization> UserOrganizations { get; set; }
        public DbSet<SurveyMetaDataTransform> SurveyMetaDataTransforms { get; set; }
        public DbSet<EIDatasource> EIDatasources { get; set; }
        public DbSet<lk_RecordSource> lk_RecordSource { get; set; }
        public DbSet<SurveyResponse> SurveyResponses { get; set; }
        public DbSet<SurveyMetaDataView> SurveyMetaDataViews { get; set; }
        public DbSet<SurveyResponseTracking> SurveyResponseTrackings { get; set; }
        public DbSet<ErrorLog> ErrorLogs { get; set; }
        public DbSet<familyset> familysets { get; set; }
        public DbSet<ErrorLogSorted> ErrorLogSorteds { get; set; }
        public DbSet<DataAccessRule> DataAccessRules { get; set; }
        public DbSet<Canva> Canvas { get; set; }
        public DbSet<SharedCanvas> SharedCanvases { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<SourceTable> SourceTables { get; set; }
        public DbSet<State> States { get; set; }
    
        public virtual int usp_AddDatasource(string datasourceServerName, string databaseType, string initialCatalog, string persistSecurityInfo, string databaseUserID, Nullable<System.Guid> surveyID, string password)
        {
            var datasourceServerNameParameter = datasourceServerName != null ?
                new ObjectParameter("DatasourceServerName", datasourceServerName) :
                new ObjectParameter("DatasourceServerName", typeof(string));
    
            var databaseTypeParameter = databaseType != null ?
                new ObjectParameter("DatabaseType", databaseType) :
                new ObjectParameter("DatabaseType", typeof(string));
    
            var initialCatalogParameter = initialCatalog != null ?
                new ObjectParameter("InitialCatalog", initialCatalog) :
                new ObjectParameter("InitialCatalog", typeof(string));
    
            var persistSecurityInfoParameter = persistSecurityInfo != null ?
                new ObjectParameter("PersistSecurityInfo", persistSecurityInfo) :
                new ObjectParameter("PersistSecurityInfo", typeof(string));
    
            var databaseUserIDParameter = databaseUserID != null ?
                new ObjectParameter("DatabaseUserID", databaseUserID) :
                new ObjectParameter("DatabaseUserID", typeof(string));
    
            var surveyIDParameter = surveyID.HasValue ?
                new ObjectParameter("SurveyID", surveyID) :
                new ObjectParameter("SurveyID", typeof(System.Guid));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("usp_AddDatasource", datasourceServerNameParameter, databaseTypeParameter, initialCatalogParameter, persistSecurityInfoParameter, databaseUserIDParameter, surveyIDParameter, passwordParameter);
        }
    
        public virtual int usp_soft_delete_Epi7_record(Nullable<System.Guid> responseId, Nullable<System.Guid> surveyId, Nullable<bool> isResponsePresent)
        {
            var responseIdParameter = responseId.HasValue ?
                new ObjectParameter("ResponseId", responseId) :
                new ObjectParameter("ResponseId", typeof(System.Guid));
    
            var surveyIdParameter = surveyId.HasValue ?
                new ObjectParameter("SurveyId", surveyId) :
                new ObjectParameter("SurveyId", typeof(System.Guid));
    
            var isResponsePresentParameter = isResponsePresent.HasValue ?
                new ObjectParameter("IsResponsePresent", isResponsePresent) :
                new ObjectParameter("IsResponsePresent", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("usp_soft_delete_Epi7_record", responseIdParameter, surveyIdParameter, isResponsePresentParameter);
        }
    
        public virtual ObjectResult<usp_GetErrorInfo_Result> usp_GetErrorInfo()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<usp_GetErrorInfo_Result>("usp_GetErrorInfo");
        }
    
        public virtual int usp_log_to_errorlog(Nullable<System.Guid> surveyId, Nullable<System.Guid> responseId, string comment, string errorText, string errorText2, Nullable<int> errorNumber, Nullable<int> errorSeverity, Nullable<int> errorState, string errorProcedure, Nullable<int> errorLine, string errorMessage, string xml)
        {
            var surveyIdParameter = surveyId.HasValue ?
                new ObjectParameter("SurveyId", surveyId) :
                new ObjectParameter("SurveyId", typeof(System.Guid));
    
            var responseIdParameter = responseId.HasValue ?
                new ObjectParameter("ResponseId", responseId) :
                new ObjectParameter("ResponseId", typeof(System.Guid));
    
            var commentParameter = comment != null ?
                new ObjectParameter("Comment", comment) :
                new ObjectParameter("Comment", typeof(string));
    
            var errorTextParameter = errorText != null ?
                new ObjectParameter("ErrorText", errorText) :
                new ObjectParameter("ErrorText", typeof(string));
    
            var errorText2Parameter = errorText2 != null ?
                new ObjectParameter("ErrorText2", errorText2) :
                new ObjectParameter("ErrorText2", typeof(string));
    
            var errorNumberParameter = errorNumber.HasValue ?
                new ObjectParameter("ErrorNumber", errorNumber) :
                new ObjectParameter("ErrorNumber", typeof(int));
    
            var errorSeverityParameter = errorSeverity.HasValue ?
                new ObjectParameter("ErrorSeverity", errorSeverity) :
                new ObjectParameter("ErrorSeverity", typeof(int));
    
            var errorStateParameter = errorState.HasValue ?
                new ObjectParameter("ErrorState", errorState) :
                new ObjectParameter("ErrorState", typeof(int));
    
            var errorProcedureParameter = errorProcedure != null ?
                new ObjectParameter("ErrorProcedure", errorProcedure) :
                new ObjectParameter("ErrorProcedure", typeof(string));
    
            var errorLineParameter = errorLine.HasValue ?
                new ObjectParameter("ErrorLine", errorLine) :
                new ObjectParameter("ErrorLine", typeof(int));
    
            var errorMessageParameter = errorMessage != null ?
                new ObjectParameter("ErrorMessage", errorMessage) :
                new ObjectParameter("ErrorMessage", typeof(string));
    
            var xmlParameter = xml != null ?
                new ObjectParameter("Xml", xml) :
                new ObjectParameter("Xml", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("usp_log_to_errorlog", surveyIdParameter, responseIdParameter, commentParameter, errorTextParameter, errorText2Parameter, errorNumberParameter, errorSeverityParameter, errorStateParameter, errorProcedureParameter, errorLineParameter, errorMessageParameter, xmlParameter);
        }
    
        public virtual int usp_process_sql_server_project_response(Nullable<System.Guid> responseId, Nullable<System.Guid> surveyId, string responseXML, Nullable<bool> isSQLProject, Nullable<bool> isDraftMode, Nullable<int> statusId, Nullable<bool> isSQLResponse, string firstSaveLogonName)
        {
            var responseIdParameter = responseId.HasValue ?
                new ObjectParameter("ResponseId", responseId) :
                new ObjectParameter("ResponseId", typeof(System.Guid));
    
            var surveyIdParameter = surveyId.HasValue ?
                new ObjectParameter("SurveyId", surveyId) :
                new ObjectParameter("SurveyId", typeof(System.Guid));
    
            var responseXMLParameter = responseXML != null ?
                new ObjectParameter("ResponseXML", responseXML) :
                new ObjectParameter("ResponseXML", typeof(string));
    
            var isSQLProjectParameter = isSQLProject.HasValue ?
                new ObjectParameter("IsSQLProject", isSQLProject) :
                new ObjectParameter("IsSQLProject", typeof(bool));
    
            var isDraftModeParameter = isDraftMode.HasValue ?
                new ObjectParameter("IsDraftMode", isDraftMode) :
                new ObjectParameter("IsDraftMode", typeof(bool));
    
            var statusIdParameter = statusId.HasValue ?
                new ObjectParameter("StatusId", statusId) :
                new ObjectParameter("StatusId", typeof(int));
    
            var isSQLResponseParameter = isSQLResponse.HasValue ?
                new ObjectParameter("IsSQLResponse", isSQLResponse) :
                new ObjectParameter("IsSQLResponse", typeof(bool));
    
            var firstSaveLogonNameParameter = firstSaveLogonName != null ?
                new ObjectParameter("FirstSaveLogonName", firstSaveLogonName) :
                new ObjectParameter("FirstSaveLogonName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("usp_process_sql_server_project_response", responseIdParameter, surveyIdParameter, responseXMLParameter, isSQLProjectParameter, isDraftModeParameter, statusIdParameter, isSQLResponseParameter, firstSaveLogonNameParameter);
        }
    }
}