using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerameworkGeneral.Application
{
   public class OperationResult
    {
        public OperationResult()
        {
                IsSecceded=false;
        }

        public string Message { get; set; }
        public bool IsSecceded { get; set; }
        public OperationResult Success(string message="عملیات با موفقیت انجام شد")
        {
            Message=message;
            IsSecceded=true;
            return this;
        }
        public OperationResult Fail(string message )
        {
            Message = message;
            IsSecceded = false;
            return this;
        }
    }
}
