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
    
    public partial class ErrorLog
    {
        public System.DateTime ErrorDate { get; set; }
        public Nullable<System.Guid> SurveyId { get; set; }
        public Nullable<System.Guid> ResponseId { get; set; }
        public string Comment { get; set; }
        public Nullable<int> ERROR_NUMBER { get; set; }
        public string ERROR_MESSAGE { get; set; }
        public Nullable<int> ERROR_SEVERITY { get; set; }
        public Nullable<int> ERROR_STATE { get; set; }
        public string ERROR_PROCEDURE { get; set; }
        public Nullable<int> ERROR_LINE { get; set; }
        public string ErrorText { get; set; }
        public string ErrorText2 { get; set; }
        public string XML { get; set; }
    }
}
