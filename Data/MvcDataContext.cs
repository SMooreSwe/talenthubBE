using Microsoft.EntityFrameworkCore;

public class MvcDataContext : DbContext
    {
        public MvcDataContext (DbContextOptions<MvcDataContext> options)
            : base(options)
        {
        }

        public DbSet<Developer> Developers { get; set; } = default!;

        public DbSet<Job> JobDescriptions { get; set; } = default!;

        public DbSet<Skill> Skills { get; set; } = default!;
    }
