﻿using DataLayer.DbContext;
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
                Console.WriteLine(ex.ToString());
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

                #region seed subject
                if (!context.Subjects.Any())
                {
                    context.Subjects.AddRange(DbSeed.Subjects);
                }
                #endregion

                #region seed group
                if (!context.Groups.Any())
                {
                    context.Groups.AddRange(DbSeed.Groups);
                }
                #endregion

                #region seed group member
                if (!context.GroupMembers.Any())
                {
                    context.GroupMembers.AddRange(DbSeed.GroupMembers);
                }
                #endregion

                #region seed group subject
                if (!context.GroupSubjects.Any())
                {
                    context.GroupSubjects.AddRange(DbSeed.GroupSubjects);
                }
                #endregion

                #region seed invite
                if (!context.Invites.Any())
                {
                    context.Invites.AddRange(DbSeed.Invites);
                }
                #endregion

                #region seed request
                if (!context.Requests.Any())
                {
                    context.Requests.AddRange(DbSeed.Requests);
                }
                #endregion

                #region seed meeting and schedule
                if (!context.Schedules.Any())
                {
                    context.Schedules.AddRange(DbSeed.Schedules);
                }
                if (!context.Meetings.Any())
                {
                    context.Meetings.AddRange(DbSeed.Meetings);
                }
                #endregion

                #region seed Connection
                if (!context.Connections.Any())
                {
                    context.Connections.AddRange(DbSeed.Connections);
                }
                #endregion

                #region seed Review
                if (!context.Reviews.Any())
                {
                    context.Reviews.AddRange(DbSeed.Reviews);
                }
                #endregion

                #region seed ReviewDetail
                if (!context.ReviewDetails.Any())
                {
                    context.ReviewDetails.AddRange(DbSeed.ReviewDetails);
                }
                #endregion

                #region seed Chat
                if (!context.Chats.Any())
                {
                    context.Chats.AddRange(DbSeed.Chats);
                }
                #endregion

                #region seed Report
                if (!context.Reports.Any())
                {
                    context.Reports.AddRange(DbSeed.Reports);
                }
                #endregion

                #region seed Discussion
                if (!context.Discussions.Any())
                {
                    context.Discussions.AddRange(DbSeed.Discussions);
                }
                #endregion

                #region seed AnswerDiscussion
                if (!context.AnswerDiscussions.Any())
                {
                    context.AnswerDiscussions.AddRange(DbSeed.AnswerDiscussions);
                }
                #endregion

                context.SaveChanges();
            }
        }
    }
}
