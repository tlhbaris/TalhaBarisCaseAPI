using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace TalhaBaris.Core.Services
{
    public interface IMailService
    {
        Task SendMessageAsync(string to, string subject, string body);
    }
}
