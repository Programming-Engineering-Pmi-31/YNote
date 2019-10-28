using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using YNoteWPF_DL.Configurations;
using YNoteWPF_DL.Entities;

namespace YNoteWPF_DL
{
    public class YNoteDbContext: DbContext
    {
        public YNoteDbContext() : base("YNoteDB") { }

        public DbSet<UserEntity> Users { get; set; }

        public DbSet<SpaceEntity> Spaces { get; set; }

        public DbSet<GroupEntity> Groups { get; set; }

        public DbSet<NoteEntity> Notes { get; set; }

        public DbSet<TaskEntity> Tasks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //Seed seed = new Seed();
            //seed.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new UserConfiguration());

            modelBuilder.Configurations.Add(new SpaceConfiguration());

            modelBuilder.Configurations.Add(new GroupConfiguration());

            modelBuilder.Configurations.Add(new NoteConfiguration());

            modelBuilder.Configurations.Add(new TaskConfiguration());
        }
    }
}
