using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace NWBlog.EntityFramework.AuditingDemo.Data
{
    public class DefaultContext : DbContext
    {
        private readonly string _username;

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<AuditEntry> AuditEntries { get; set; }

        public DefaultContext(DbContextOptions<DefaultContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            // Get the claims principal from the HttpContext
            var claimsPrincipal = httpContextAccessor.HttpContext?.User;

            // Get the username claim from the claims principal - if the user is not authenticated the claim will be null
            _username = claimsPrincipal?.Claims?.SingleOrDefault(c => c.Type == "username")?.Value ?? "Unauthenticated user";
        }
    }
}
