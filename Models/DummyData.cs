using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZenithWebSite.Data;

namespace ZenithWebSite.Models
{
    public class DummyData
    {
        public static void Initialize(ApplicationDbContext db, IServiceProvider services)
        {
            ServiceInitialize(db,services);
            if (!db.Activities.Any())
            {
                db.Activities.AddRange(GetActivities().ToArray());
                db.SaveChanges();
            }
            if (!db.Events.Any())
            {
                db.Events.AddRange(GetEvents(db).ToArray());
                db.SaveChanges();
            }
        }
            public static Activity[] GetActivities()
        {
            var activities = new List<Activity>
            {
                new Activity
                {
                    ActivityDescription = "Senior’s Golf Tournament",
                    CreationDate = new DateTime(2017, 10, 10, 9, 00, 0)
                },
                new Activity
                {
                    ActivityDescription = "Leadership General Assembly Meeting",
                    CreationDate = new DateTime(2017, 10, 10, 9, 00, 0)
                },
                new Activity
                {
                    ActivityDescription = "Youth Bowling Tournament",
                    CreationDate = new DateTime(2017, 10, 10, 9, 00, 0)
                },
                new Activity
                {
                    ActivityDescription = "Young ladies cooking lessons",
                    CreationDate = new DateTime(2017, 10, 10, 9, 00, 0)
                },
                new Activity
                {
                    ActivityDescription = "Youth craft lessons",
                    CreationDate = new DateTime(2017, 10, 10, 9, 00, 0)
                },
                new Activity
                {
                    ActivityDescription = "Youth choir practice",
                    CreationDate = new DateTime(2017, 10, 10, 9, 00, 0)
                },
                new Activity
                {
                    ActivityDescription = "Lunch",
                    CreationDate = new DateTime(2017, 10, 10, 9, 00, 0)
                },
                new Activity
                {
                    ActivityDescription = "Pancake Breakfast",
                    CreationDate = new DateTime(2017, 10, 10, 9, 00, 0)
                },
                new Activity
                {
                    ActivityDescription = "Swimming Lessons for the youth",
                    CreationDate = new DateTime(2017, 10, 10, 9, 00, 0)
                },
                new Activity
                {
                    ActivityDescription = "Swimming Exercise for parents",
                    CreationDate = new DateTime(2017, 10, 10, 9, 00, 0)
                },
                new Activity
                {
                    ActivityDescription = "Bingo Tournament",
                    CreationDate = new DateTime(2017, 10, 10, 9, 00, 0)
                },
                new Activity
                {
                    ActivityDescription = "BBQ Lunch",
                    CreationDate = new DateTime(2017, 10, 10, 9, 00, 0)
                },
                new Activity
                {
                    ActivityDescription = "Garage Sale",
                    CreationDate = new DateTime(2017, 10, 10, 9, 00, 0)
                },
                new Activity
                {
                    ActivityDescription = "Sleep Time",
                    CreationDate = new DateTime(2017, 10, 10, 9, 00, 0)
                }

            };

            return activities.ToArray();
        }

        private static Event[] GetEvents(ApplicationDbContext context)
        {
            var events = new List<Event>
            {
                new Event
                {
                    EventFrom = new DateTime(2017, 12, 4, 8, 30, 0),
                    EventTo = new DateTime(2017, 12, 4, 9, 30, 0),
                    Username = "Liang",
                    Activity = new Activity()
                    {
                        ActivityDescription = "Senior’s Golf Tournament"
                    },                    CreationDate = new DateTime(2017, 10, 16, 9, 00, 0),
                    IsActive = false
                },
                new Event
                {
                    EventFrom = new DateTime(2017, 12, 5, 9, 30, 0),
                    EventTo = new DateTime(2017, 12, 5, 11, 30, 0),
                    Username = "Liang",
                    Activity = new Activity()
                    {
                        ActivityDescription ="Leadership General Assembly Meeting"
                    },                    CreationDate = new DateTime(2017, 10, 10, 9, 00, 0),
                    IsActive = false
                },
                new Event
                {
                    EventFrom = new DateTime(2017, 12, 5, 11, 30, 0),
                    EventTo = new DateTime(2017, 12, 5, 12, 30, 0),
                    Username = "Liang",
                    Activity = new Activity()
                    {
                        ActivityDescription = "Youth Bowling Tournament"
                    },                    CreationDate = new DateTime(2017, 10, 10, 9, 00, 0),
                    IsActive = false
                },
                new Event
                {
                    EventFrom = new DateTime(2017, 12, 6, 12, 30, 0),
                    EventTo = new DateTime(2017, 12, 6, 13, 30, 0),
                    Username = "Liang",
                    Activity = new Activity()
                    {
                        ActivityDescription = "Young ladies cooking lessons"
                    },                    CreationDate = new DateTime(2017, 2, 10, 9, 00, 0),
                    IsActive = false
                },
                new Event
                {
                    EventFrom = new DateTime(2017, 12, 6, 13, 30, 0),
                    EventTo = new DateTime(2017, 12, 6, 14, 30, 0),
                    Username = "Liang",
                    Activity = new Activity()
                    {
                        ActivityDescription = "Youth craft lessons"
                    },                    CreationDate = new DateTime(2017, 10, 10, 9, 00, 0),
                    IsActive = false
                },
                new Event
                {
                    EventFrom = new DateTime(2017, 12, 7, 14, 30, 0),
                    EventTo = new DateTime(2017, 12, 7, 15, 30, 0),
                    Username = "Jim",
                    Activity = new Activity()
                    {
                        ActivityDescription = "Youth choir practice"
                    },                    CreationDate = new DateTime(2017, 2, 10, 9, 00, 0),
                    IsActive = false
                },
                new Event
                {
                    EventFrom = new DateTime(2017, 12, 8, 8, 00, 0),
                    EventTo = new DateTime(2017, 12, 8, 8, 30, 0),
                    Username = "Liang",
                    Activity = new Activity()
                    {
                        ActivityDescription =  "Lunch"
                    },                    CreationDate = new DateTime(2017, 10, 10, 9, 00, 0),
                    IsActive = true
                },
                new Event
                {
                    EventFrom = new DateTime(2017, 12, 7, 8, 30, 0),
                    EventTo = new DateTime(2017, 12, 7, 9, 30, 0),
                    Username = "Liang",
                    Activity = new Activity()
                    {
                        ActivityDescription = "Pancake Breakfast"
                    },                    CreationDate = new DateTime(2017, 2, 10, 9, 00, 0),
                    IsActive = true
                },
                new Event
                {
                    EventFrom = new DateTime(2017, 12, 2, 9, 30, 0),
                    EventTo = new DateTime(2017, 12, 2, 11, 30, 0),
                    Username = "Jim",
                    Activity = new Activity()
                    {
                        ActivityDescription = "Swimming Lessons for the youth"
                    },                    CreationDate = new DateTime(2017, 10, 10, 9, 00, 0),
                    IsActive = true
                },
                new Event
                {
                    EventFrom = new DateTime(2017, 12, 13, 11, 30, 0),
                    EventTo = new DateTime(2017, 12, 13, 12, 30, 0),
                    Username = "Jim",
                    Activity = new Activity()
                    {
                        ActivityDescription ="Swimming Exercise for parents"
                    },                    CreationDate = new DateTime(2017, 2, 10, 9, 00, 0),
                    IsActive = true
                },
                new Event
                {
                    EventFrom = new DateTime(2017, 12, 12, 12, 30, 0),
                    EventTo = new DateTime(2017, 12, 12, 13, 30, 0),
                    Username = "Liang",
                    Activity = new Activity()
                    {
                        ActivityDescription ="Bingo Tournament"
                    },                    CreationDate = new DateTime(2017, 10, 10, 9, 00, 0),
                    IsActive = true
                },
                new Event
                {
                    EventFrom = new DateTime(2017, 12, 5, 13, 30, 0),
                    EventTo = new DateTime(2017, 12, 5, 14, 30, 0),
                    Username = "Liang",
                    Activity = new Activity()
                    {
                        ActivityDescription = "BBQ Lunch"
                    },                    CreationDate = new DateTime(2017, 2, 10, 9, 00, 0),
                    IsActive = true
                },
                new Event
                {
                    EventFrom = new DateTime(2017, 12, 6, 14, 30, 0),
                    EventTo = new DateTime(2017, 12, 6, 15, 30, 0),
                    Username = "Liang",
                    Activity = new Activity()
                    {
                        ActivityDescription = "Garage Sale"
                    },                    CreationDate = new DateTime(2017, 2, 10, 9, 00, 0),
                    IsActive = true
                },
                new Event
                {
                    EventFrom = new DateTime(2017, 12, 7, 15, 30, 0),
                    EventTo = new DateTime(2017, 12, 7, 16, 30, 0),
                    Username = "Jim",
                    Activity = new Activity()
                    {
                        ActivityDescription = "Sleep Time"
                    },                    CreationDate = new DateTime(2017, 10, 10, 9, 00, 0),
                    IsActive = true
                }
            };

            return events.ToArray();
        }
        public static void ServiceInitialize(ApplicationDbContext db, IServiceProvider services)
        {
            IServiceScopeFactory scopeFactory = services.GetRequiredService<IServiceScopeFactory>();

            using (IServiceScope scope = scopeFactory.CreateScope())
            {
                RoleManager<IdentityRole> roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                UserManager<ApplicationUser> userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                SeedUserRole(db, roleManager, userManager);
            }
        }

        public static async void SeedUserRole(ApplicationDbContext context, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            var isAdminRoleExist = await roleManager.RoleExistsAsync("Admin");
            var isMemberRoleExist = await roleManager.RoleExistsAsync("Member");
            if (!isAdminRoleExist)
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }
            if (!isMemberRoleExist)
            {
                await roleManager.CreateAsync(new IdentityRole("Member"));
            }
            if (await userManager.FindByNameAsync("a") == null)
            {
                var user = new ApplicationUser
                {
                    Email = "a@a.a",
                    UserName = "a"
                };
                var result = await userManager.CreateAsync(user, "P@$$w0rd");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Admin");
                }
            }
            if (await userManager.FindByNameAsync("m") == null)
            {
                var user = new ApplicationUser
                {
                    Email = "m@m.m",
                    UserName = "m"
                };
                var result = await userManager.CreateAsync(user, "P@$$w0rd");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Member");
                }
            }
        }

    }
}
