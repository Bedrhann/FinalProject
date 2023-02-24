using FinalProject.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;


namespace FinalProject.Application.Interfaces.Repositories.Common
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }
    }
}
