
using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Domain.Interfaces;

public interface IWorkInfoRepository: IDisposable
{
    Task<IEnumerable<WorkInfo>> GetAllWorkInfosAsync();
    Task<WorkInfo?> GetWorkInfoAsync(int id);
    Task<WorkInfo> InsertWorkInfoAsync(WorkInfo workInfo);
    Task DeleteWorkInfoAsync(int workInfoId);
    Task UpdateWorkInfoAsync(WorkInfo workInfo);
}
