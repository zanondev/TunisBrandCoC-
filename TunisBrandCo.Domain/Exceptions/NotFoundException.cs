using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TunisBrandCo.Domain.Exceptions
{
    public class NotFoundException : BusinessException
    {
        public NotFoundException(string message) : base(ErrorCodes.NotFound, message)
        {

        }
    }
}

