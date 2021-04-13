﻿using Epi.Web.Enter.Common.Exception;
using Epi.Web.Enter.Common.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Epi.Web.WCF.SurveyService
{
    [ServiceContract]
    public interface IEWEManagerServiceV2 : IEWEManagerService
    {

        [OperationContract]
        [FaultContract(typeof(CustomFaultException))]
        bool ValidateOrganization(OrganizationRequest Request);
        [OperationContract]
        [FaultContract(typeof(CustomFaultException))]
        SurveyInfoResponse GetAllSurveysByOrgKey(string OrgKey);
        //[OperationContract]
        //[FaultContract(typeof(CustomFaultException))]
        //string SetJsonColumn(List<string> SurveyIds, string OrgId);
        //[OperationContract]
        //[FaultContract(typeof(CustomFaultException))]
        //string SetJsonColumnAll(string AdminKey);
        //[OperationContract]
        //[FaultContract(typeof(CustomFaultException))]
        //UserResponse GetLoginToken(UserRequest UserInfo);
        //[OperationContract]
        //[FaultContract(typeof(CustomFaultException))]
        //bool SetUserInfo(UserRequest UserInfo);
        //[OperationContract]
        //[FaultContract(typeof(CustomFaultException))]
        //bool GetExistingUser(UserRequest UserInfo);
        //[OperationContract]
        //[FaultContract(typeof(CustomFaultException))]
        //UserResponse GetUserListByOrganization(UserRequest UserInfo);
        //[OperationContract]
        //[FaultContract(typeof(CustomFaultException))]
        //bool DeleteUser(UserRequest UserInfo);
        //[OperationContract]
        //[FaultContract(typeof(CustomFaultException))]
        //bool UpdateUserInfo(UserRequest UserInfo);
        //[OperationContract]
        //[FaultContract(typeof(CustomFaultException))]
        //UserResponse GetUserByUserId(UserRequest UserInfo);
        [OperationContract]
        [FaultContract(typeof(CustomFaultException))]
        string GetJsonResponseAll(string SurveyId, string OrganizationId, string PublisherKey);
        [OperationContract]
        [FaultContract(typeof(CustomFaultException))]
        PublishReportResponse PublishReport(PublishReportRequest Request);
        [OperationContract]
        [FaultContract(typeof(CustomFaultException))]
        PublishReportResponse DeleteReport(PublishReportRequest Request);
    }
}
