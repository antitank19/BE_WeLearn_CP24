using DataLayer.DbContext;
using DataLayer.DbObject;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.DbSeeding
{
    public static class DbInitializerExtension
    {
        public static IApplicationBuilder SeedInMemoryDb(this IApplicationBuilder app)
        {
            ArgumentNullException.ThrowIfNull(app, nameof(app));

            using var scope = app.ApplicationServices.CreateScope();
            var services = scope.ServiceProvider;
            try
            {
                var context = services.GetRequiredService<WeLearnContext>();
                DbInitializer.Initialize(context);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return app;
        }
        public class DbInitializer
        {
            internal static void Initialize(WeLearnContext context)
            {
                ArgumentNullException.ThrowIfNull(context, nameof(context));
                //context.Database.EnsureCreated();
                #region seed Role
                if (!context.Roles.Any())
                {

                    context.Roles.AddRange(DbSeed.Roles);
                }
                #endregion

                #region seed Account
                if (!context.Accounts.Any())
                {

                    context.Accounts.AddRange(DbSeed.Accounts);

                }
                #endregion

               
                context.SaveChanges();
            }
        }
    }
}
