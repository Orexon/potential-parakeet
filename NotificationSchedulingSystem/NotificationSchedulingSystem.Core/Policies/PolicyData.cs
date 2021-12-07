using NotificationSchedulingSystem.Core.CompanyAggregate;

namespace NotificationSchedulingSystem.Core.Policies
{
    public record PolicyData(CompanyType CompanyType, CompanyAggregate.Market Market);
}
