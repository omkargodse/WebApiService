using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Web_API_Service_CQRS.Models;

namespace Web_API_Service_CQRS.Context
{
    public interface IApplicationContext
    {
        DbSet<Product> Products { get; set; }

        Task<int> SaveChanges();
    }
}