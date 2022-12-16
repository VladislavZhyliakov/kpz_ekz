using Microsoft.EntityFrameworkCore;
using DAL.ValueConverters;
using Domain.Entities;

namespace DAL
{
    public sealed class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Student> Students  { get; set; }
        public DbSet<UniTask> UniTasks  { get; set; }
        public DbSet<StudentUniTask> StudentUniTasks  { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            Seed(modelBuilder);
       
        }
        
        protected override void ConfigureConventions(ModelConfigurationBuilder modelBuilder)
        {
            modelBuilder.Properties<DateOnly>()
                .HaveConversion<DateOnlyConverter>()
                .HaveColumnType("date");

            modelBuilder.Properties<TimeOnly>()
                .HaveConversion<TimeOnlyConverter>()
                .HaveColumnType("time");
        }

       public void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    Id = 1,
                    FirstName = "Oleg",
                    LastName = "Sencov"
                },
                new Student
                {
                    Id = 2,
                    FirstName = "John",
                    LastName = "Travolta"
                },
                new Student
                {
                    Id = 3,
                    FirstName = "Johnathan",
                    LastName = "Joestar"
                }
                );
            modelBuilder.Entity<UniTask>().HasData(
                new UniTask
                {
                    Id = 1,
                    Description = "Lab1",
                    Priority = "Mid",
                    TaskDate = new DateOnly(2022,10,10)
                },
                 new UniTask
                 {
                     Id = 2,
                     Description = "Lab2",
                     Priority = "Mid",
                     TaskDate = new DateOnly(2022, 10, 20)
                 },
                  new UniTask
                  {
                      Id = 3,
                      Description = "KR",
                      Priority = "High",
                      TaskDate = new DateOnly(2022, 11, 10)
                  }

                );
            modelBuilder.Entity<StudentUniTask>().HasData(
                new StudentUniTask
                     {
                        Id = 1,
                        UniTaskId= 1,
                        StudentId= 1,
                        Grade = 5,
                        IsPresent= true
                     },
                    new StudentUniTask
                    {
                        Id = 2,
                        UniTaskId = 2,
                        StudentId = 1,
                        Grade = 0,
                        IsPresent = false
                    },
                    new StudentUniTask
                    {
                        Id = 3,
                        UniTaskId = 3,
                        StudentId = 1,
                        Grade = 5,
                        IsPresent = true
                    },
                    new StudentUniTask
                    {
                        Id = 4,
                        UniTaskId = 1,
                        StudentId = 2,
                        Grade = 3,
                        IsPresent = true
                    },
                    new StudentUniTask
                    {
                        Id = 5,
                        UniTaskId = 2,
                        StudentId = 2,
                        Grade = 4,
                        IsPresent = true
                    },
                    new StudentUniTask
                    {
                        Id = 6,
                        UniTaskId = 3,
                        StudentId = 2,
                        Grade = 5,
                        IsPresent = true
                    },
                    new StudentUniTask
                    {
                        Id = 7,
                        UniTaskId = 1,
                        StudentId = 3,
                        Grade = 0,
                        IsPresent = false
                    },
                    new StudentUniTask
                    {
                        Id = 8,
                        UniTaskId = 2,
                        StudentId = 3,
                        Grade = 4,
                        IsPresent = true
                    },
                    new StudentUniTask
                    {
                        Id = 9,
                        UniTaskId = 3,
                        StudentId = 3,
                        Grade = 3,
                        IsPresent = true
                    }
                );

        }

    }
}
