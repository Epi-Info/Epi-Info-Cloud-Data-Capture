﻿using Epi.Web.Enter.Common.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epi.Web;
using Epi.Web.Enter.Common.ObjectMapping;
using Epi.Web.Enter.Common;
using Epi.Web.Enter.Common.DTO;
using Epi.Web.Enter.Common.Exception;
using System.ServiceModel;
using System.Configuration;

namespace Epi.Web.WCF.SurveyService
{
    public class EWEManagerServiceV2 : EWEManagerService , IEWEManagerServiceV2
    {
        public bool ValidateOrganization(OrganizationRequest Request)
        {
            bool IsValid;
            try
            {


                Enter.Interfaces.DataInterfaces.ISurveyInfoDao ISurveyInfoDao = new EF.EntitySurveyInfoDao();
                Epi.Web.BLL.SurveyInfo Implementation = new Epi.Web.BLL.SurveyInfo(ISurveyInfoDao);
                IsValid = Implementation.ValidateOrganization(Request);

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return IsValid;
        }

        public SurveyInfoResponse GetAllSurveysByOrgKey(string OrgKey)

        {
            SurveyInfoResponse SurveyInfoResponse = new SurveyInfoResponse();
            try
            {

                Enter.Interfaces.DataInterfaces.ISurveyInfoDao ISurveyInfoDao = new EF.EntitySurveyInfoDao();
                Epi.Web.BLL.SurveyInfo Implementation = new Epi.Web.BLL.SurveyInfo(ISurveyInfoDao);
                SurveyInfoResponse.SurveyInfoList = Mapper.ToDataTransferObject(Implementation.GetAllSurveysByOrgKey(OrgKey));
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return SurveyInfoResponse;
        }



        //    public string SetJsonColumn(List<string> SurveyIds, string OrgId)
        //    {

        //        return "";

        //    }

        //    public string SetJsonColumnAll(string AdminKey)
        //    {
        //        string Key = EIWSConfig.AdminKey.ToString();
        //        if (AdminKey == Key)
        //        {


        //        }
        //        return " Done";

        //    }
        //    public UserResponse GetLoginToken(UserRequest UserInfo)
        //    {

        //        UserResponse UserResponse = new UserResponse();
        //        UserRequest UserRequest = new UserRequest();


        //        try
        //        {


        //            Enter.Interfaces.DataInterfaces.IUserDao IUserDao = new EF.EntityUserDao();
        //            Epi.Web.BLL.User Implementation = new Epi.Web.BLL.User(IUserDao);
        //            bool UserExist = Implementation.GetExistingUser(Mapper.ToUserBO(UserRequest.User));

        //            if (UserExist)
        //            {
        //                UserResponse.Message = ConfigurationManager.AppSettings[""];

        //            }
        //        }
        //        catch (Exception ex)
        //        {

        //            throw ex;
        //        }
        //        return UserResponse;

        //    }
        //    public bool UpdateUserInfo(UserRequest UserInfo)
        //    {
        //        Enter.Interfaces.DataInterfaces.IDaoFactory entityDaoFactory = new EF.EntityDaoFactory();
        //        Enter.Interfaces.DataInterfaces.IUserDao IUserDao = new EF.EntityUserDao();
        //        Epi.Web.BLL.User Implementation = new Epi.Web.BLL.User(IUserDao);

        //        var UserBO = Mapper.ToUserBO(UserInfo.User);
        //        OrganizationBO OrgBO = new OrganizationBO();
        //        OrgBO = Mapper.ToBusinessObject(UserInfo.Organization);
        //        return Implementation.UpdateUser(UserBO, OrgBO);

        //    }
        //    public bool DeleteUser(UserRequest UserInfo)
        //    {

        //        UserRequest UserRequest = new UserRequest();


        //        return true;
        //    }

        //    public UserResponse GetUserListByOrganization(UserRequest UserInfo)
        //    {
        //        UserResponse UserResponse = new UserResponse();
        //        UserRequest UserRequest = new UserRequest();



        //        Epi.Web.Enter.Interfaces.DataInterfaces.IOrganizationDao IOrganizationDao = new EF.EntityOrganizationDao();
        //        Epi.Web.BLL.Organization OrgImplementation = new Epi.Web.BLL.Organization(IOrganizationDao);


        //        OrganizationBO OrganizationBO = OrgImplementation.GetOrganizationByKey(UserInfo.Organization.OrganizationKey);



        //        Epi.Web.Enter.Interfaces.DataInterfaces.IDaoFactory entityDaoFactory = new EF.EntityDaoFactory();
        //        Epi.Web.Enter.Interfaces.DataInterfaces.IUserDao IUserDao = new EF.EntityUserDao();
        //        Epi.Web.BLL.User Implementation = new Epi.Web.BLL.User(IUserDao);
        //        UserResponse.User = Mapper.ToUserDTO(Implementation.GetUsersByOrgId(OrganizationBO.OrganizationId));

        //        return UserResponse;

        //    }

        //    public bool SetUserInfo(UserRequest UserInfo)
        //    {



        //        OrganizationRequest OrganizationRequest = new OrganizationRequest();
        //        OrganizationRequest.Organization.OrganizationKey = UserInfo.Organization.OrganizationKey;
        //        bool IsSet = false;

        //        try
        //        {


        //            Epi.Web.Interfaces.DataInterfaces.IUserDao IUserDao = new EF.EntityUserDao();
        //            Epi.Web.BLL.User Implementation = new Epi.Web.BLL.User(IUserDao);

        //            Epi.Web.Interfaces.DataInterfaces.IOrganizationDao IOrganizationDao = new EF.EntityOrganizationDao();
        //            Epi.Web.BLL.Organization OrgImplementation = new Epi.Web.BLL.Organization(IOrganizationDao);


        //            OrganizationBO OrganizationBO = OrgImplementation.GetOrganizationByKey(UserInfo.Organization.OrganizationKey);

        //            IsSet = Implementation.SetUserInfo(Mapper.ToUserBO(UserInfo.User), OrganizationBO);


        //        }
        //        catch (Exception ex)
        //        {

        //            throw ex;
        //        }
        //        return IsSet;


        //    }
        //    public bool GetExistingUser(UserRequest UserInfo)
        //    {


        //        UserRequest UserRequest = new UserRequest();

        //        bool UserExist = false;
        //        try
        //        {


        //            Epi.Web.Interfaces.DataInterfaces.IUserDao IUserDao = new EF.EntityUserDao();
        //            Epi.Web.BLL.User Implementation = new Epi.Web.BLL.User(IUserDao);
        //            UserExist = Implementation.GetExistingUser(Mapper.ToUserBO(UserRequest.User));


        //        }
        //        catch (Exception ex)
        //        {

        //            throw ex;
        //        }
        //        return UserExist;

        //    }

        //    public UserResponse GetUserByUserId(UserRequest UserInfo)
        //    {


        //        UserResponse UserResponse = new UserResponse();

        //        Epi.Web.Enter.Interfaces.DataInterfaces.IUserDao IUserDao = new EF.EntityUserDao();
        //        Epi.Web.BLL.User Implementation = new Epi.Web.BLL.User(IUserDao);
        //        var CurrentUser = Implementation.GetUserByUserId(Mapper.ToUserBO(UserInfo.User), Mapper.ToBusinessObject(UserInfo.Organization));
        //        UserResponse.User = new List<UserDTO>();
        //        UserResponse.User.Add(Mapper.ToUserDTO(CurrentUser));


        //        return UserResponse;


        //    }
        public string GetJsonResponseAll(string SurveyId, string OrganizationId, string PublisherKey)
        {



            return Enter.Common.Helper.SqlHelper.GetJsonResponseAll(SurveyId);



        }

        public PublishReportResponse PublishReport(PublishReportRequest Request)
        {
            try
            {
                PublishReportResponse result = new PublishReportResponse();
                Epi.Web.Enter.Interfaces.DataInterfaces.IReportDao IReportDao = new EF.EntityReportDao();



                Epi.Web.BLL.Report Implementation = new Epi.Web.BLL.Report(IReportDao);

                Epi.Web.Enter.Common.BusinessObject.ReportInfoBO ReportInfoBO = Mapper.ToReportInfoBO(Request.ReportInfo);

                Implementation.PublishReport(ReportInfoBO);

                result.Message = "The report was successfully published";
                var ReportInfo = new ReportInfoDTO();
                ReportInfo.ReportURL = ConfigurationManager.AppSettings["ReportURL"] + Request.ReportInfo.ReportId;
                result.Reports = new List<ReportInfoDTO>();
                result.Reports.Add(ReportInfo);
                return result;
            }
            catch (Exception ex)
            {
                CustomFaultException customFaultException = new CustomFaultException();
                customFaultException.CustomMessage = ex.Message;
                customFaultException.Source = ex.Source;
                customFaultException.StackTrace = ex.StackTrace;
                customFaultException.HelpLink = ex.HelpLink;
                throw new FaultException<CustomFaultException>(customFaultException);
            }

        }
        public PublishReportResponse DeleteReport(PublishReportRequest Request)
        {
            try
            {
                PublishReportResponse result = new PublishReportResponse();
                Epi.Web.Enter.Interfaces.DataInterfaces.IReportDao IReportDao = new EF.EntityReportDao();



                Epi.Web.BLL.Report Implementation = new Epi.Web.BLL.Report(IReportDao);

                Epi.Web.Enter.Common.BusinessObject.ReportInfoBO ReportInfoBO = Mapper.ToReportInfoBO(Request.ReportInfo);

                Implementation.DeleteReport(ReportInfoBO);

                result.Message = "The report was successfully Deleted";
                return result;
            }
            catch (Exception ex)
            {
                CustomFaultException customFaultException = new CustomFaultException();
                customFaultException.CustomMessage = ex.Message;
                customFaultException.Source = ex.Source;
                customFaultException.StackTrace = ex.StackTrace;
                customFaultException.HelpLink = ex.HelpLink;
                throw new FaultException<CustomFaultException>(customFaultException);
            }

        }
    }
}
