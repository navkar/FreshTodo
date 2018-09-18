using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MyTasks.TODO
{
    public static class Config
    {
        /// <summary>
        /// API URL
        /// </summary>
        public static string ApiUrl = "https://vmghq0zpsc.execute-api.us-east-1.amazonaws.com";
        
        /// <summary>
        /// API Host Name
        /// </summary>
        public static string ApiHostName
        {
            get
            {
                var apiHostName = Regex.Replace(ApiUrl, @"^(?:http(?:s)?://)?(?:www(?:[0-9]+)?\.)?", string.Empty, RegexOptions.IgnoreCase)
                                   .Replace("/", string.Empty);
                return apiHostName;
            }
        }
    }
}
