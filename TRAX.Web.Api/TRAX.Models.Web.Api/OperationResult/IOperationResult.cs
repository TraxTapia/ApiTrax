using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRAX.Models.Web.Api.OperationResult
{
    public class IOperationResult
    {
        public IOperationResult()
        {

        }
        public string Code { get; set; }
        public string Message { get; set; }
    }
}
