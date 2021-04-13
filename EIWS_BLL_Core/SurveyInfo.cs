﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epi.Web.Enter.Common.BusinessObject;
using Epi.Web.Enter.Common.Criteria;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using Epi.Web.Common.DTO;

namespace Epi.Web.BLL
{

  public  class SurveyInfo
    {
      private Epi.Web.Enter.Interfaces.DataInterfaces.ISurveyInfoDao SurveyInfoDao;
      Dictionary<int, int> ViewIds = new Dictionary<int, int>();

        public SurveyInfo(Epi.Web.Enter.Interfaces.DataInterfaces.ISurveyInfoDao pSurveyInfoDao)
        {
            this.SurveyInfoDao = pSurveyInfoDao;
        }

        public SurveyInfoBO GetSurveyInfoById(string pId)
        {
            List<string> IdList = new List<string>();
            if (! string.IsNullOrEmpty(pId))
            {
                IdList.Add(pId);
            }
            List<SurveyInfoBO> result = this.SurveyInfoDao.GetSurveyInfo(IdList);
            if (result.Count > 0)
            {
                return result[0];
            }
            else
            {
                return null;
            }
        }


     

        /// <summary>
        /// Gets SurveyInfo based on criteria
        /// </summary>
        /// <param name="SurveyInfoId">Unique SurveyInfo identifier.</param>
        /// <returns>SurveyInfo.</returns>
        public List<SurveyInfoBO> GetSurveyInfoById(List<string> pIdList)
        {
            List<SurveyInfoBO> result = this.SurveyInfoDao.GetSurveyInfo(pIdList);
            return result;
        }

        public PageInfoBO GetSurveySizeInfo(List<string> pIdList,int BandwidthUsageFactor, int pResponseMaxSize = -1)
        { 
            List<SurveyInfoBO> SurveyInfoBOList = this.SurveyInfoDao.GetSurveySizeInfo(pIdList, -1, -1, pResponseMaxSize);

            PageInfoBO result = new PageInfoBO();

            result = Epi.Web.BLL.Common.GetSurveySize(SurveyInfoBOList,BandwidthUsageFactor, pResponseMaxSize);
            return result;


        }


        public bool IsSurveyInfoValidByOrgKeyAndPublishKey(string SurveyId, string Okey, Guid publishKey ,int UserId = -1)
        {

            string EncryptedKey = Epi.Web.Enter.Common.Security.Cryptography.Encrypt(Okey);
            List<SurveyInfoBO> result = this.SurveyInfoDao.GetSurveyInfoByOrgKeyAndPublishKey(SurveyId, EncryptedKey, publishKey,UserId);

             
            if (result != null && result.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        public bool IsSurveyInfoValidByOrgKey(string SurveyId, string pOrganizationKey)
        {

            string EncryptedKey = Epi.Web.Enter.Common.Security.Cryptography.Encrypt(pOrganizationKey);
            List<SurveyInfoBO> result = this.SurveyInfoDao.GetSurveyInfoByOrgKey(SurveyId, EncryptedKey);


            if (result != null && result.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



      /// <summary>
        /// Gets SurveyInfo based on criteria
        /// </summary>
        /// <param name="SurveyInfoId">Unique SurveyInfo identifier.</param>
        /// <returns>SurveyInfo.</returns>
        public List<SurveyInfoBO> GetSurveyInfo(List<string> SurveyInfoIdList, DateTime pClosingDate, string Okey, int pSurveyType = -1, int pPageNumber = -1, int pPageSize = -1)
        {
            string EncryptedKey = Epi.Web.Enter.Common.Security.Cryptography.Encrypt(Okey);
            List<SurveyInfoBO> result = this.SurveyInfoDao.GetSurveyInfo(SurveyInfoIdList, pClosingDate, EncryptedKey, pSurveyType, pPageNumber, pPageSize);
            return result;
        }
        public PageInfoBO GetSurveySizeInfo(List<string> SurveyInfoIdList, DateTime pClosingDate, string Okey, int BandwidthUsageFactor, int pSurveyType = -1, int pPageNumber = -1, int pPageSize = -1, int pResponseMaxSize = -1)
        {

            string EncryptedKey = Epi.Web.Enter.Common.Security.Cryptography.Encrypt(Okey);

            List<SurveyInfoBO> SurveyInfoBOList = this.SurveyInfoDao.GetSurveySizeInfo(SurveyInfoIdList, pClosingDate, EncryptedKey, pSurveyType, pPageNumber, pPageSize, pResponseMaxSize);

            PageInfoBO result = new PageInfoBO();

            result = Epi.Web.BLL.Common.GetSurveySize(SurveyInfoBOList, BandwidthUsageFactor, pResponseMaxSize);
            return result;

        }
      
        public SurveyInfoBO InsertSurveyInfo(SurveyInfoBO pValue)
        {
            SurveyInfoBO result = pValue;
            this.SurveyInfoDao.InsertSurveyInfo(pValue);
            return result;
        }
        public SurveyInfoBO UpdateSurveyInfo(SurveyInfoBO pRequestMessage)
        {
        SurveyInfoBO result = pRequestMessage;
        if (ValidateSurveyFields(pRequestMessage))
            {
                
            if (this.IsRelatedForm(pRequestMessage.XML))
                    {

                    List<SurveyInfoBO> FormsHierarchyIds = this.GetFormsHierarchyIds(pRequestMessage.SurveyId.ToString());
                    
                    // 1- breck down the xml to n views
                    List<string> XmlList = new List<string>();
                    XmlList = XmlChunking(pRequestMessage.XML);

                    // 2- call publish() with each of the views
                    foreach (string Xml in XmlList)
                        {
                        XDocument xdoc = XDocument.Parse(Xml);
                        SurveyInfoBO SurveyInfoBO = new SurveyInfoBO();
                        XElement ViewElement = xdoc.XPathSelectElement("Template/Project/View");
                        int ViewId;
                        int.TryParse(ViewElement.Attribute("ViewId").Value.ToString(), out ViewId);

                        GetRelateViewIds(ViewElement, ViewId);

                        SurveyInfoBO = pRequestMessage;
                        SurveyInfoBO.XML = Xml;
                        SurveyInfoBO.SurveyName = ViewElement.Attribute("Name").Value.ToString();
                        SurveyInfoBO.ViewId = ViewId;

                        SurveyInfoBO pBO = FormsHierarchyIds.Single(x => x.ViewId == ViewId);
                        SurveyInfoBO.SurveyId = pBO.SurveyId;
                        SurveyInfoBO.ParentId = pBO.ParentId;
                        SurveyInfoBO.UserPublishKey = pBO.UserPublishKey;
                        SurveyInfoBO.OwnerId = pRequestMessage.OwnerId;
                        if (SurveyInfoBO.IsSqlProject == true)
                        {
                            this.SurveyInfoDao.ValidateServername(pRequestMessage);
                            SurveyInfoBO.IsSqlProject = pRequestMessage.IsSqlProject;
                        }
                        this.SurveyInfoDao.UpdateSurveyInfo(SurveyInfoBO);

                        //Commented as updating mode does not require update of the display settings
                        //this.SurveyInfoDao.InsertFormdefaultSettings(pRequestMessage.SurveyId, pRequestMessage.IsSqlProject, GetSurveyControls(SurveyInfoBO));
                        }
                    }
                else
                    {
                        if (pRequestMessage.IsSqlProject == true)
                        {
                            this.SurveyInfoDao.ValidateServername(pRequestMessage);
                        }
                        this.SurveyInfoDao.UpdateSurveyInfo(pRequestMessage);

                    this.SurveyInfoDao.UpdateSurveyInfo(pRequestMessage);

                    //Commented as updating mode does not require update of the display settings
                    //this.SurveyInfoDao.InsertFormdefaultSettings(pRequestMessage.SurveyId, pRequestMessage.IsSqlProject, GetSurveyControls(pRequestMessage));
                    }
                result.StatusText = "Successfully updated survey information.";
            }else{
                result.StatusText = "One or more survey required fields are missing values.";
            
            }
            
            return result;
        }

        public bool DeleteSurveyInfo(SurveyInfoBO pValue)
        {
            bool result = false;

            this.SurveyInfoDao.DeleteSurveyInfo(pValue);
            result = true;

            return result;
        }
        private static bool ValidateSurveyFields(SurveyInfoBO pRequestMessage)
        {

            bool isValid = true;


            if (pRequestMessage.ClosingDate == null)
            {

                isValid = false;

            }

           
            else if (string.IsNullOrEmpty(pRequestMessage.SurveyName))
            {

                isValid = false;
            }
 



            return isValid;
        }


        public List<SurveyInfoBO> GetChildInfoByParentId(Dictionary<string ,int > ParentIdList)
            {
            List<SurveyInfoBO> result = new List<SurveyInfoBO>();
            foreach (KeyValuePair<string, int> item in ParentIdList)
                {
                result = this.SurveyInfoDao.GetChildInfoByParentId(item.Key, item.Value);
                }
            return result;
            }
        public SurveyInfoBO GetParentInfoByChildId(string ChildId)
            {
            SurveyInfoBO result = new SurveyInfoBO();

            result = this.SurveyInfoDao.GetParentInfoByChildId(ChildId);
              
            return result;
            }
        public List<FormsHierarchyBO> GetFormsHierarchyIdsByRootId(string RootId)
            {
            List<SurveyInfoBO> SurveyInfoBOList = new List<SurveyInfoBO>();
            List<FormsHierarchyBO> result = new List<FormsHierarchyBO>();

            SurveyInfoBOList = this.SurveyInfoDao.GetFormsHierarchyIdsByRootId(RootId);
            foreach (var item in SurveyInfoBOList)
                {
                FormsHierarchyBO FormsHierarchyBO = new FormsHierarchyBO();
                FormsHierarchyBO.ViewId = item.ViewId;
                FormsHierarchyBO.FormId = item.SurveyId;
                FormsHierarchyBO.SurveyInfo = item;
                FormsHierarchyBO.IsSqlProject = item.IsSqlProject;
                if (item.SurveyId == RootId)
                    {
                    FormsHierarchyBO.IsRoot = true;
                    }
                result.Add(FormsHierarchyBO);
                }

            return result;

            }
        private List<SurveyInfoBO> GetFormsHierarchyIds(string RootId)
            {
            List<SurveyInfoBO> FormsHierarchyIds = new List<SurveyInfoBO>();
            FormsHierarchyIds = this.SurveyInfoDao.GetFormsHierarchyIdsByRootId(RootId);
            return FormsHierarchyIds;
            }
        private bool IsRelatedForm(string Xml)
            {

            bool IsRelatedForm = false;
            XDocument xdoc = XDocument.Parse(Xml);


            int NumberOfViews = xdoc.Descendants("View").Count();
            if (NumberOfViews > 1)
                {
                IsRelatedForm = true;

                }

            return IsRelatedForm;

            }


        private void GetRelateViewIds(XElement ViewElement, int ViewId)
            {

            var _RelateFields = from _Field in
                                    ViewElement.Descendants("Field")
                                where _Field.Attribute("FieldTypeId").Value == "20"
                                select _Field;

            foreach (var Item in _RelateFields)
                {

                int RelateViewId = 0;
                int.TryParse(Item.Attribute("RelatedViewId").Value, out RelateViewId);

                this.ViewIds.Add(RelateViewId, ViewId);
                }


            }

        private List<string> XmlChunking(string Xml)
            {
            List<string> XmlList = new List<string>();
            XDocument xdoc = XDocument.Parse(Xml);
            XDocument xdoc1 = XDocument.Parse(Xml);

            xdoc.Descendants("View").Remove();

            foreach (XElement Xelement in xdoc1.Descendants("Project").Elements("View"))
                {

                //xdoc.Element("Project").Add(Xelement);
                xdoc.Root.Element("Project").Add(Xelement);
                XmlList.Add(xdoc.ToString());
                xdoc.Descendants("View").Remove();
                }

            return XmlList;
            }
        private List<string> GetSurveyControls(SurveyInfoBO SurveyInfoBO)
        {
            List<string> List = new List<string>();

            XDocument xdoc = XDocument.Parse(SurveyInfoBO.XML);

            var _FieldsTypeIDs = from _FieldTypeID in
                                     xdoc.Descendants("Field")
                                 select _FieldTypeID;

            string fieldType = "";

            foreach (var _FieldTypeID in _FieldsTypeIDs.Take(5))
            {
                fieldType = _FieldTypeID.Attribute("FieldTypeId").Value;

                if (fieldType != "2" && fieldType != "21" && fieldType != "3" && fieldType != "20")
                {
                    List.Add(_FieldTypeID.Attribute("Name").Value.ToString());
                }
            }
            return List;
        }

        public List<SourceTableBO> GetSourceTables( string SurveyId)
        {
            List<SourceTableBO> List = new List<SourceTableBO>();
            List = this.SurveyInfoDao.GetSourceTables(SurveyId);

            return List;
        }
        public Web.Enter.Common.Message.SurveyControlsResponse GetSurveyControlList(string SurveyId)
        {
            Web.Enter.Common.Message.SurveyControlsResponse SurveyControlsResponse = new Web.Enter.Common.Message.SurveyControlsResponse();
            if (!string.IsNullOrEmpty(SurveyId))
            {
                SurveyInfoBO SurveyInfoBO = new SurveyInfoBO();
                try
                {
                    SurveyInfoBO = GetSurveyInfoById(SurveyId);
                }
                catch (Exception ex)
                {
                    SurveyControlsResponse.Message = "Survey doesn’t exist.";

                }
                List<SurveyControlDTO> SurveyControlList = new List<SurveyControlDTO>();
                SurveyControlList = _GetSurveyControls(SurveyInfoBO);
                SurveyControlsResponse.SurveyControlList = SurveyControlList;
            }
            return SurveyControlsResponse;
        }
        private List<SurveyControlDTO> _GetSurveyControls(SurveyInfoBO SurveyInfoBO)
        {
            List<SurveyControlDTO> List = new List<SurveyControlDTO>();

            XDocument xdoc = XDocument.Parse(SurveyInfoBO.XML);


            var _FieldsTypeIDs = from _FieldTypeID in
                                      xdoc.Descendants("Field")
                                 select _FieldTypeID;

            foreach (var _FieldTypeID in _FieldsTypeIDs)
            {
                Web.Common.DTO.SurveyControlDTO SurveyControlDTO = new Web.Common.DTO.SurveyControlDTO();
                SurveyControlDTO.ControlId = _FieldTypeID.Attribute("Name").Value.ToString();
                SurveyControlDTO.ControlPrompt = _FieldTypeID.Attribute("PromptText").Value.ToString();
                SurveyControlDTO.ControlType = GetControlType(_FieldTypeID.Attribute("FieldTypeId").Value);
                List.Add(SurveyControlDTO);

            }
            return List;

        }
        private string GetControlType(string Type)
        {
            string ControlType = "";
            switch (Type)
            {
                case "1":
                case "3"://UpperCase
                case "15"://Mirror
                    ControlType = "TextBox";
                    break;

                case "2"://Literal
                    ControlType = "Literal";
                    break;

                case "4"://TextArea
                    ControlType = "TextArea";
                    break;

                case "5"://NumericTextBox
                    ControlType = "NumericTextBox";
                    break;

                case "7"://DatePicker
                    ControlType = "Date";
                    break;

                case "8"://TimePicker
                    ControlType = "Time";
                    break;

                case "10"://CheckBox
                    ControlType = "CheckBox";
                    break;

                case "11": // YesNo
                    ControlType = "YesNo";
                    break;

                case "12"://GroupBoxRadioList
                    ControlType = "GroupBoxRadioList";
                    break;

                case "13"://Button
                    ControlType = "Button";
                    break;

                case "17": // LegalValues/DropDown
                    ControlType = "LegalValues";
                    break;

                case "18": // Codes
                    ControlType = "Codes";
                    break;

                case "19": // CommentLegal
                    ControlType = "CommentLegal";
                    break;

                case "21": //GroupBox
                    ControlType = "GroupBox";
                    break;
            }

            return ControlType;
        }



        public bool ValidateOrganization(Enter.Common.Message.OrganizationRequest Request)
        {
            bool IsValid = false;
            string EncryptedKey = Enter.Common.Security.Cryptography.Encrypt(Request.Organization.OrganizationKey);
            int OrgId = this.SurveyInfoDao.GetOrganizationId(EncryptedKey);
            if (OrgId != -1)
            {
                IsValid = true;

            }
            else
            {
                EncryptedKey = Enter.Common.Security.Cryptography.Encrypt(Request.Organization.OrganizationKey.ToLower());
                OrgId = this.SurveyInfoDao.GetOrganizationId(EncryptedKey);
                if (OrgId != -1)
                {
                    IsValid = true;

                }
            }
            return IsValid;
        }

        public List<SurveyInfoBO> GetAllSurveysByOrgKey(string OrgKey)
        {
            string EncryptedKey = Enter.Common.Security.Cryptography.Encrypt(OrgKey);
            List<SurveyInfoBO> SurveyInfoResponse = this.SurveyInfoDao.GetAllSurveysByOrgKey(EncryptedKey);
            return SurveyInfoResponse;
        }

    }
}
