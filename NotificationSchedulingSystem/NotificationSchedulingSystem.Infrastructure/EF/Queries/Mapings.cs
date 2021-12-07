using NotificationSchedulingSystem.Application.DTO;
using NotificationSchedulingSystem.Infrastructure.EF.Models;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace NotificationSchedulingSystem.Infrastructure.Queries
{
    internal static class Mapings
    {
        public static CompanyDTO AsCompanyDto(this CompanyReadModel readModel)
            => new()
            {
                CompanyId = readModel.CompanyId,
                Name = readModel.Name,
                CompanyNumber = readModel.CompanyNumber,
                CompanyType = readModel.CompanyType,
                Market = readModel.Market,
                Notifications = readModel.Notifications?.Select(n => new NotificationDTO
                {
                    SendDate = n.SendDate,
                })
            };

        public static ScheduleDTO AsScheduleDto(this CompanyReadModel readModel)
        {
            List<string> list = readModel.Notifications?.Select(n => n.SendDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)).ToList();
            string[] result = list.Where(x => x != null).Select(x => x.ToString()).ToArray();

            return new ScheduleDTO()
            {
                CompanyId = readModel.CompanyId,
                Notifications = result
            };
        }
    }
}