using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Text;

namespace M2SysAssesment.Common.Helper
{
    public static class Constants
    {
        #region Replaceable Messages
        public static readonly string NotFound = "{0} not found";
        public static readonly string Invalid = "{0} is invalid";
        #endregion
        public static readonly string ExceptionMessage = "Something went wrong. Please try after sometime.";
        public static readonly string UrlExists = "Some url are duplicate";
        public static readonly string AddSuccess = "File Added successfully";
        public static readonly string ImageListNullOrEmpty = "Image list are empty or null can't valid";
    }
}
