using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karkathamizha.API.IService.Common
{
    public interface IEmailService
    {
        void SendForgotPasswordEmail(string mail);
    }
}
