using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TunisBrandCo.Domain.Exceptions
{
    public class AlreadyExistsException : BusinessException
    {
        public AlreadyExistsException(string message) : base(ErrorCodes.AlreadyExists, message)
        {
        }
    }
}
