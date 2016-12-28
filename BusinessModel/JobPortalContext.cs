using System.Data.Entity;
using JobPortal.BusinessModel;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace JobPortal.BusinessModel
{
    public class JobPortalContext:DbContext
    {
        public JobPortalContext()
            : base("name=JobPortalConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<JobPortalContext>(null);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<ClientMaster> ClientMaster { get; set; }
        public DbSet<UserLogin> UserLogin { get; set; }
    }
}