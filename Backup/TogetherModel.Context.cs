namespace RoadBetterTogether
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TogetherContext : DbContext
    {
        public TogetherContext()
            : base("name=TogetherContext")
        {
        }

        public virtual DbSet<AdressesSet> AdressesSet { get; set; }
        public virtual DbSet<AdressesSet_HomeAdress> AdressesSet_HomeAdress { get; set; }
        public virtual DbSet<AdressesSet_WorkAdress> AdressesSet_WorkAdress { get; set; }
        public virtual DbSet<CompagnySiteSet> CompagnySiteSet { get; set; }
        public virtual DbSet<HomeAdressSet> HomeAdressSet { get; set; }
        public virtual DbSet<PostSet> PostSet { get; set; }
        public virtual DbSet<RoadTeamSet> RoadTeamSet { get; set; }
        public virtual DbSet<TogetherCarsSet> TogetherCarsSet { get; set; }
        public virtual DbSet<TogetherCompagnySet> TogetherCompagnySet { get; set; }
        public virtual DbSet<TogetherUsersSet> TogetherUsersSet { get; set; }
        public virtual DbSet<TogetherUsersSet_TogetherDrivers> TogetherUsersSet_TogetherDrivers { get; set; }
        public virtual DbSet<WorkAdressSet> WorkAdressSet { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdressesSet>()
                .HasOptional(e => e.AdressesSet_HomeAdress)
                .WithRequired(e => e.AdressesSet)
                .WillCascadeOnDelete();

            modelBuilder.Entity<AdressesSet>()
                .HasOptional(e => e.AdressesSet_WorkAdress)
                .WithRequired(e => e.AdressesSet)
                .WillCascadeOnDelete();

            modelBuilder.Entity<TogetherCompagnySet>()
                .HasMany(e => e.CompagnySiteSet)
                .WithRequired(e => e.TogetherCompagnySet)
                .HasForeignKey(e => e.TogetherCompagnyId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TogetherUsersSet>()
                .HasMany(e => e.AdressesSet)
                .WithRequired(e => e.TogetherUsersSet)
                .HasForeignKey(e => e.TogetherUsersSet_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TogetherUsersSet>()
                .HasOptional(e => e.TogetherUsersSet_TogetherDrivers)
                .WithRequired(e => e.TogetherUsersSet)
                .WillCascadeOnDelete();

            modelBuilder.Entity<TogetherUsersSet_TogetherDrivers>()
                .HasMany(e => e.TogetherCarsSet)
                .WithRequired(e => e.TogetherUsersSet_TogetherDrivers)
                .HasForeignKey(e => e.TogetherDrivers_Id)
                .WillCascadeOnDelete(false);
        }
    }
}
