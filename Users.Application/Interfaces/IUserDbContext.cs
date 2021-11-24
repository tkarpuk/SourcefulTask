using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Users.Domain.Entities;

namespace Users.Application.Interfaces
{
    public interface IUserDbContext
    {
        DbSet<UserInfo> Users { get; set; }
        DbSet<Address> Addresses { get; set; }
        DbSet<Film> Films { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
