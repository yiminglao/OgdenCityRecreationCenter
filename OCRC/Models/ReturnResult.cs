using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OCRC.Models
{
    /// <summary>
    /// Can hold an object and an error code to better handle exceptions
    /// </summary>
    public class ReturnResult
    {
        public int returnCode { get; set; }
        public object data { get; set; }
        public ReturnResult() { }

        public ReturnResult(int err, object dataObject)
        {
            returnCode = err;
            data = dataObject;
        }

    }

    static class ReturnCode
    {
        public const int SUCCESS = 0;
        public const int FAILURE = 1;
        public const int UNEXPECTED = 2; //TODO : we could use arbitrary numbers instead of these codes,

    }
}