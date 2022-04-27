using System.Threading.Tasks;
using VaccineManagement.Models;

namespace VaccineManagement.Services
{
    public interface IMailService
    {
        Task SendEmailForForgotPasswordAsync(ResponeMailForgotPassword res, string passwordResetLink);
    }
}
