using Foodie.Application.Common.Interfaces.Auth.Services;

namespace Foodie.Infrastructure.Common.Implemetations.Auth.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime GmtNow => DateTime.Now;
    }
}