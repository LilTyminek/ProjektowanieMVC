using Microsoft.AspNetCore.Identity;
using System;
using MVC.Models;
namespace MVC.Data
{
    public static class ContextSeed
    {
        public static async Task SeedSuperAdminAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Default User
            var defaultUser = new IdentityUser
            {
                UserName = "superadmin",
                Email = "superadmin@gmail.com",
                EmailConfirmed = true,
                PhoneNumberConfirmed = false
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "123Pa$$word.");
                    await userManager.AddToRoleAsync(defaultUser, Enums.Roles.Basic.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Enums.Roles.Moderator.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Enums.Roles.Admin.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Enums.Roles.SuperAdmin.ToString());
                }

            }
        }
        public static async Task SeedRolesAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Roles
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.SuperAdmin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Moderator.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Basic.ToString()));
        }
        public static async Task SeedStudentsAsync(ApplicationDbContext context)
        {
            if (!context.Students.Any())
            {
                var students = new List<Student>
        {
            new Student{FirstMidName="Carson",LastName="Alexander",EnrollmentDate=DateTime.Parse("2005-09-01")},
            new Student{FirstMidName="Meredith",LastName="Alonso",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new Student{FirstMidName="Arturo",LastName="Anand",EnrollmentDate=DateTime.Parse("2003-09-01")},
            new Student{FirstMidName="Gytis",LastName="Barzdukas",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new Student{FirstMidName="Yan",LastName="Li",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new Student{FirstMidName="Peggy",LastName="Justice",EnrollmentDate=DateTime.Parse("2001-09-01")},
            new Student{FirstMidName="Laura",LastName="Norman",EnrollmentDate=DateTime.Parse("2003-09-01")},
            new Student{FirstMidName="Nino",LastName="Olivetto",EnrollmentDate=DateTime.Parse("2005-09-01")}
        };

                await context.Students.AddRangeAsync(students);
                await context.SaveChangesAsync();
            }
            if (!context.Courses.Any())
            {
                var courses = new List<Course>
    {
        new Course{CourseID=1050,Title="Chemistry",Credits=3,},
        new Course{CourseID=4022,Title="Microeconomics",Credits=3,},
        new Course{CourseID=4041,Title="Macroeconomics",Credits=3,},
        new Course{CourseID=1045,Title="Calculus",Credits=4,},
        new Course{CourseID=3141,Title="Trigonometry",Credits=4,},
        new Course{CourseID=2021,Title="Composition",Credits=3,},
        new Course{CourseID=2042,Title="Literature",Credits=4,},
    };

                await context.Courses.AddRangeAsync(courses);
                await context.SaveChangesAsync();
            }
            if (!context.Enrollments.Any())
            {
                var enrollments = new List<Enrollment>
    {
        new Enrollment{StudentID=1,CourseID=1050,Grade=Grade.A},
        new Enrollment{StudentID=1,CourseID=4022,Grade=Grade.C},
        new Enrollment{StudentID=1,CourseID=4041,Grade=Grade.B},
        new Enrollment{StudentID=2,CourseID=1045,Grade=Grade.B},
        new Enrollment{StudentID=2,CourseID=3141,Grade=Grade.F},
        new Enrollment{StudentID=2,CourseID=2021,Grade=Grade.F},
        new Enrollment{StudentID=3,CourseID=1050},
        new Enrollment{StudentID=4,CourseID=1050,},
        new Enrollment{StudentID=4,CourseID=4022,Grade=Grade.F},
        new Enrollment{StudentID=5,CourseID=4041,Grade=Grade.C},
        new Enrollment{StudentID=6,CourseID=1045},
        new Enrollment{StudentID=7,CourseID=3141,Grade=Grade.A},
    };

                await context.Enrollments.AddRangeAsync(enrollments);
                await context.SaveChangesAsync();
            }

        }
        
    }

    public class Enums
    {
        public enum Roles
        {
            SuperAdmin,
            Admin,
            Moderator,
            Basic
        }
    }
}
