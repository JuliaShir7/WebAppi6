using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection.Metadata;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WebAppi6.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Cuisine> Cuisines { get; set; }
        public DbSet<FoodRestriction> FoodRestrictions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Individual> Individuals { get; set; }
        public DbSet<Attraction> Attractions { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<WorkingHours> WorkingHours { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Preference> Preferences { get; set; }

        private readonly StreamWriter logStream = new StreamWriter("dblogs.txt", append: true);

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseMySql(
                "server=localhost;user=root;password=23571788ysik;database=test;",
                new MySqlServerVersion(new Version(8, 0, 11))
            );
            optionsBuilder.LogTo(logStream.WriteLine).EnableDetailedErrors(); 
        }
        public override void Dispose()
        {
            base.Dispose();
            logStream.Dispose();
        }

        public override async ValueTask DisposeAsync()
        {
            await base.DisposeAsync();
            await logStream.DisposeAsync();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //////////////////////////////////////////
            //настройка связей классов с соттветствующими таблицами
            /////////////////////////////////////////
            modelBuilder.Entity<Category>().ToTable("categories");
            modelBuilder.Entity<SubCategory>().ToTable("subcategories");
            modelBuilder.Entity<Cuisine>().ToTable("cuisine");
            modelBuilder.Entity<FoodRestriction>().ToTable("food_Restrictions");

            modelBuilder.Entity<Attraction>().ToTable("attractions");
            modelBuilder.Entity<WorkingHours>().ToTable("working_hours");
            modelBuilder.Entity<Review>().ToTable("reviews");
            modelBuilder.Entity<Route>().ToTable("routes_description");
            modelBuilder.Entity<Attendance>().ToTable("attendance");
            modelBuilder.Entity<CurrentRoute>().ToTable("current_routes");

            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<Company>().ToTable("companies");
            modelBuilder.Entity<Individual>().ToTable("individuals");
            modelBuilder.Entity<Request>().ToTable("requests");
            modelBuilder.Entity<Note>().ToTable("notes");
            modelBuilder.Entity<Preference>().ToTable("preferences");
            //////////////////////////////////////////
            //связи для категорий информации
            /////////////////////////////////////////
            modelBuilder.Entity<Category>()
             .HasMany(e => e.SubCategories)
             .WithOne()
             .HasForeignKey("ID_Category")
             .IsRequired();

            //////////////////////////////////////////
            //связи для достопримечательностей
            /////////////////////////////////////////
            modelBuilder.Entity<Attraction>()
                .HasOne(w => w.WorkingHours)
                .WithOne()
                .HasForeignKey<WorkingHours>("ID_Attraction")
                .IsRequired();

            modelBuilder.Entity<Attraction>()
                  .HasMany(s => s.SubCategories)
                  .WithMany()
                  .UsingEntity<Dictionary<string, object>>(
                  right => right
                  .HasOne<SubCategory>()
                  .WithMany().HasForeignKey("ID_Subcategory").HasPrincipalKey(nameof(SubCategory.ID)),
                  left => left
                  .HasOne<Attraction>()
                  .WithMany().HasForeignKey("ID_Attraction").HasPrincipalKey(nameof(Attraction.ID)),
                  join => join
                  .ToTable("subcategories_to_attraction"));

            modelBuilder.Entity<Attraction>()
                .HasMany(e => e.Reviews)
                .WithOne()
                .HasForeignKey("ID_Attraction")
                .IsRequired();

            //для кафе и ресторанов
            modelBuilder.Entity<Attraction>()
                  .HasMany(s => s.FoodRestrictions)
                  .WithMany()
                  .UsingEntity<Dictionary<string, object>>(
                  right => right
                  .HasOne<FoodRestriction>()
                  .WithMany().HasForeignKey("ID_Food_Restriction").HasPrincipalKey(nameof(FoodRestriction.ID)),
                  left => left
                  .HasOne<Attraction>()
                  .WithMany().HasForeignKey("ID_Attraction").HasPrincipalKey(nameof(Attraction.ID)),
                  join => join
                  .ToTable("food_restrictions_to_attraction"));

            modelBuilder.Entity<Attraction>()
                 .HasMany(s => s.Cuisines)
                 .WithMany()
                 .UsingEntity<Dictionary<string, object>>(
                 right => right
                 .HasOne<Cuisine>()
                 .WithMany().HasForeignKey("ID_Cuisine").HasPrincipalKey(nameof(Cuisine.ID)),
                 left => left
                 .HasOne<Attraction>()
                 .WithMany().HasForeignKey("ID_Attraction").HasPrincipalKey(nameof(Attraction.ID)),
                 join => join
                 .ToTable("cuisine_to_attraction"));

            //////////////////////////////////////////
            //связи для маршрутов
            /////////////////////////////////////////
            modelBuilder.Entity<Route>()
                .HasOne(c => c.Category)
                .WithOne()
                .HasForeignKey<Route>("ID_Category")
                .IsRequired();

            modelBuilder.Entity<Route>()
                   .HasMany(p => p.Places)
                   .WithMany()
                   .UsingEntity<Dictionary<string, object>>(
                   right => right
                   .HasOne<Attraction>()
                   .WithMany().HasForeignKey("ID_Attraction").HasPrincipalKey(nameof(Attraction.ID)),
                   left => left
                   .HasOne<Route>()
                   .WithMany().HasForeignKey("ID_Routes_Description").HasPrincipalKey(nameof(Route.ID)),
                   join => join
                   .ToTable("routes"));

           
            modelBuilder.Entity<Individual>()
                .HasOne(cr => cr.CurrentRoute)
                .WithOne()
                .HasForeignKey<CurrentRoute>("ID_Individual")
                .IsRequired();
           
            //////////////////////////////////////////
            //связи для всех категорий пользователей
            /////////////////////////////////////////

            //модераторы
            modelBuilder.Entity<Request>()
                .HasOne(a => a.Attraction)
                .WithMany()
                .HasForeignKey("ID_Attraction")
                .IsRequired();

            modelBuilder.Entity<Request>()
                .HasOne(ind => ind.Individual)
                .WithMany()
                .HasForeignKey("ID_Individual")
                .IsRequired();

            modelBuilder.Entity<User>()
               .HasMany(m => m.Requests)
               .WithOne()
               .HasForeignKey("ID_User")
               .IsRequired();

            //компании
            modelBuilder.Entity<Company>()
                  .HasMany(cl => cl.Clients)
                  .WithMany()
                  .UsingEntity<Dictionary<string, object>>(
                  right => right
                  .HasOne<Individual>()
                  .WithMany().HasForeignKey("ID_Individual").HasPrincipalKey(nameof(Individual.ID)),
                  left => left
                  .HasOne<Company>()
                  .WithMany().HasForeignKey("ID_Company").HasPrincipalKey(nameof(Company.ID)),
                  join => join
                  .ToTable("companies_clients"));

            modelBuilder.Entity<Company>()
                .HasMany(p => p.Partners)
                .WithMany()
                .UsingEntity<Dictionary<string, object>>(
                right => right
                .HasOne<Attraction>()
                .WithMany().HasForeignKey("ID_Attraction").HasPrincipalKey(nameof(Attraction.ID)),
                left => left
                .HasOne<Company>()
                .WithMany().HasForeignKey("ID_Company").HasPrincipalKey(nameof(Company.ID)),
                join => join
                .ToTable("cooperations"));


            //физические лица
            modelBuilder.Entity<Individual>()
                   .HasMany(e => e.FoodRestrictions)
                   .WithMany()
                   .UsingEntity<Dictionary<string, object>>(
                   right => right
                   .HasOne<FoodRestriction>()
                   .WithMany().HasForeignKey("ID_FoodRestriction").HasPrincipalKey(nameof(FoodRestriction.ID)),
                   left => left
                   .HasOne<Individual>()
                   .WithMany().HasForeignKey("ID_Individual").HasPrincipalKey(nameof(Individual.ID)),
                   join => join
                   .ToTable("individuals_food_restrictions"));


            modelBuilder.Entity<Individual>()
                    .HasMany(e => e.Routes)
                    .WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                    right => right
                    .HasOne<Route>()
                    .WithMany().HasForeignKey("ID_Routes_Descroption").HasPrincipalKey(nameof(Route.ID)),
                    left => left
                    .HasOne<Individual>()
                    .WithMany().HasForeignKey("ID_Individual").HasPrincipalKey(nameof(Individual.ID)),
                    join => join
                    .ToTable("individuals_routes"));

            //заметки о местах
            modelBuilder.Entity<Individual>()
                .HasMany(n => n.Notes)
                .WithOne()
                .HasForeignKey("ID_Individual")
                .IsRequired();

            modelBuilder.Entity<Note>()
                .HasOne(n => n.Attraction)
                .WithMany()
                .HasForeignKey("ID_Attraction")
                .IsRequired();
            
            //предпочтения
            modelBuilder.Entity<Individual>()
                .HasMany(p => p.Preferences)
                .WithOne()
                .HasForeignKey("ID_Individual")
                .IsRequired();

            modelBuilder.Entity<Preference>()
               .HasOne(c => c.Category)
               .WithMany()
               .HasForeignKey("ID_Category");

            modelBuilder.Entity<Preference>()
              .HasOne(s => s.SubCategory)
              .WithMany()
              .HasForeignKey("ID_SubCategory");

            modelBuilder.Entity<Preference>()
              .HasOne(c => c.Cuisine)
              .WithMany()
              .HasForeignKey("ID_Cuisine");

            modelBuilder.Entity<Preference>()
              .HasOne(c => c.Attraction)
              .WithMany()
              .HasForeignKey("ID_Attraction");

            //посещенность мест 
            modelBuilder.Entity<Attendance>()
               .HasOne(a => a.Attraction)
               .WithMany()
               .HasForeignKey("ID_Attraction")
               .IsRequired();

            modelBuilder.Entity<Individual>()
               .HasMany(a => a.Attendances)
               .WithOne()
               .HasForeignKey("ID_Individual")
               .IsRequired();
        }
    }
}
