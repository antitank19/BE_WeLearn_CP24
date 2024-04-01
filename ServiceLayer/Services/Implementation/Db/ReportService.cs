using AutoMapper;
using AutoMapper.QueryableExtensions;
using DataLayer.DbObject;
using DataLayer.Enums;
using Microsoft.EntityFrameworkCore;
using RepoLayer.Interface;
using ServiceLayer.DTOs;
using ServiceLayer.Services.Interface.Db;
using ServiceLayer.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Implementation.Db
{
    public class ReportService : IReportService
    {
        private IRepoWrapper repos;
        private IMapper mapper;

        public ReportService(IRepoWrapper repos, IMapper mapper)
        {
            this.repos = repos;
            this.mapper = mapper;
        }

        public IQueryable<T> GetReportList<T>()
        {
            var list = repos.Reports.GetList()
                 .Include(r => r.Sender)
                 .Include(r => r.Account)
                 .Include(r => r.Group)
                 .Include(r => r.File)
                 .Include(r => r.Discussion);
            if (list == null || !list.Any())
            {
                return null;
            }
            var mapped = list.ProjectTo<T>(mapper.ConfigurationProvider);
            return mapped;
        }
        public IQueryable<T> GetUnresolvedReportList<T>()
        {
            var list = repos.Reports.GetList()
                 .Include(r => r.Sender)
                 .Include(r => r.Account)
                 .Include(r => r.Group)
                 .Include(r => r.File)
                 .Include(r => r.Discussion)
                 .Where(r=>r.State==RequestStateEnum.Waiting);
            if (list == null || !list.Any())
            {
                return null;
            }
            var mapped = list.ProjectTo<T>(mapper.ConfigurationProvider);
            return mapped;
        }

        public IQueryable<T> GetReportedAccountList<T>()
        {
            var list = repos.Accounts.GetList()
                .Include(a => a.ReportedReports)
                .Where(a => a.ReportedReports.Any(r => r.State == RequestStateEnum.Waiting));
            var mapped = list.ProjectTo<T>(mapper.ConfigurationProvider);
            return mapped;
        }

        public IQueryable<T> GetReportedGroupList<T>()
        {
            var list = repos.Groups.GetList()
                .Include(a => a.ReportedReports)
                .Where(a => a.ReportedReports.Any(r => r.State == RequestStateEnum.Waiting));
            var mapped = list.ProjectTo<T>(mapper.ConfigurationProvider);
            return mapped;
        }

        public IQueryable<T> GetReportedDiscussionList<T>()
        {
            var list = repos.Discussions.GetList()
                .Include(a => a.ReportedReports)
                .Where(a => a.ReportedReports.Any(r => r.State == RequestStateEnum.Waiting));
            var mapped = list.ProjectTo<T>(mapper.ConfigurationProvider);
            return mapped;
        }

        public IQueryable<T> GetReportedFileList<T>()
        {
            var list = repos.DocumentFiles.GetList()
                .Include(a => a.ReportedReports)
                .Where(a => a.ReportedReports.Any(r => r.State == RequestStateEnum.Waiting));
            var mapped = list.ProjectTo<T>(mapper.ConfigurationProvider);
            return mapped;
        }

        public async Task CreateReport(ReportCreateDto dto, int senderId)
        {
            var report = mapper.Map<Report>(dto);
            report.SenderId = senderId;
            report.State = RequestStateEnum.Waiting;

            await repos.Reports.CreateAsync(report);
        }

        public async Task<bool> IsReportExist(int reportId)
        {
            return await repos.Requests.IdExistAsync(reportId);
        }

        public async Task ResolveReport(int reportId, bool isApproved)
        {
            var report = await repos.Reports.GetByIdAsync(reportId);
            if(isApproved == true)
            {
                report.State = RequestStateEnum.Approved;

                //Account
                if (report.AccountId is not null)
                {
                    var account = await repos.Accounts.GetByIdAsync(report.AccountId.Value);
      
                    account.ReportCounter = ++account.ReportCounter;

                    if (account.ReportCounter > 5)
                    {
                        account.IsBanned = true;

                        if (account.GroupMembers.Any())
                        {
                            foreach (var groupMember in account.GroupMembers)
                            {
                                groupMember.IsActive = false;

                                var group = groupMember.Group;

                                var document = group.DocumentFiles.Where(x => x.AccountId == account.Id);
                                if (document.Any())
                                {
                                    foreach (var file in document)
                                    {
                                        file.IsActive = false;
                                    }
                                }
                                var discussions = group.Discussions.Where(x => x.AccountId == account.Id);
                                if (discussions.Any())
                                {
                                    foreach (var discussion in discussions)
                                    {
                                        discussion.IsActive = false;

                                        var answerDiscussions = discussion.AnswerDiscussion;
                                        foreach (var answer in answerDiscussions)
                                        {
                                            answer.IsActive = false;
                                        }
                                    }
                                }
                            }
                        }
                    }

                    account.PatchUpdate(account);
                    await repos.Accounts.UpdateAsync(account);
                }
                //Discussion
                else if(report.DiscussionId is not null)
                {
                    var discussion = await repos.Discussions.GetByIdAsync(report.DiscussionId.Value);
                    var account = await repos.Accounts.GetByIdAsync(report.Discussion.AccountId);

                    discussion.IsActive = false;
                    account.ReportCounter = ++account.ReportCounter;

                    if (account.ReportCounter > 5)
                    {
                        account.IsBanned = true;
                        if (account.GroupMembers.Any())
                        {
                            foreach (var groupMember in account.GroupMembers)
                            {
                                groupMember.IsActive = false;

                                var group = groupMember.Group;

                                var document = group.DocumentFiles.Where(x => x.AccountId == account.Id);
                                if (document.Any())
                                {
                                    foreach (var file in document)
                                    {
                                        file.IsActive = false;
                                    }
                                }
                                var discussions = group.Discussions.Where(x => x.AccountId == account.Id);
                                if (discussions.Any())
                                {
                                    foreach (var discuss in discussions)
                                    {
                                        discuss.IsActive = false;

                                        var answerDiscussions = discuss.AnswerDiscussion;
                                        foreach (var answer in answerDiscussions)
                                        {
                                            answer.IsActive = false;
                                        }
                                    }
                                }
                            }
                        }
                    }

                    await repos.Discussions.UpdateAsync(discussion);
                    await repos.Accounts.UpdateAsync(account);
                }
                //DocumentFile
                else if (report.FileId is not null)
                {
                    var docfile = await repos.DocumentFiles.GetByIdAsync(report.FileId.Value);
                    var account = await repos.Accounts.GetByIdAsync(report.File.AccountId);

                    docfile.IsActive = false;
                    account.ReportCounter = ++account.ReportCounter;

                    if (account.ReportCounter > 5)
                    {
                        account.IsBanned = true;

                        if (account.GroupMembers.Any())
                        {
                            foreach (var groupMember in account.GroupMembers)
                            {
                                groupMember.IsActive = false;

                                var group = groupMember.Group;

                                var document = group.DocumentFiles.Where(x => x.AccountId == account.Id);
                                if (document.Any())
                                {
                                    foreach(var file in document)
                                    {
                                        file.IsActive = false;
                                    }
                                }
                                var discussions = group.Discussions.Where(x => x.AccountId == account.Id);
                                if (discussions.Any())
                                {
                                    foreach (var discussion in discussions)
                                    {
                                        discussion.IsActive = false;

                                        var answerDiscussions = discussion.AnswerDiscussion;
                                        foreach(var answer in answerDiscussions)
                                        {
                                            answer.IsActive = false;
                                        }
                                    }
                                }
                            }
                        }
                    }

                    await repos.DocumentFiles.UpdateAsync(docfile);
                    await repos.Accounts.UpdateAsync(account);
                }
                //Group
                else if(report.GroupId is not null)
                {
                    var group = await repos.Groups.GetByIdAsync(report.GroupId.Value);

                    group.BanCounter = ++group.BanCounter;

                    if (group.BanCounter > 3)
                    {
                        group.IsBanned = true;

                        if (group.DocumentFiles.Any()) 
                        {
                            foreach (var doc in group.DocumentFiles)
                            {
                                doc.IsActive = false;
                            }
                        }
                        if (group.Discussions.Any())
                        {
                            foreach (var doc in group.Discussions)
                            {
                                if (doc.AnswerDiscussion.Any())
                                {
                                    foreach(var answer in doc.AnswerDiscussion)
                                    {
                                        answer.IsActive = false;
                                    }
                                }

                                doc.IsActive = false;
                            }
                        }
                        if (group.GroupMembers.Any())
                        {
                            foreach (var doc in group.GroupMembers)
                            {
                                doc.IsActive = false;
                            }
                        }
                        if (group.Schedules.Any())
                        {
                            foreach (var doc in group.Schedules)
                            {
                                doc.IsActive = false;
                            }
                        }
                        if (group.JoinInvites.Any())
                        {
                            foreach (var doc in group.JoinInvites)
                            {
                                doc.State = RequestStateEnum.Decline;
                            }
                        }
                        if (group.JoinRequests.Any())
                        {
                            foreach (var doc in group.JoinRequests)
                            {
                                doc.State = RequestStateEnum.Decline;
                            }
                        }
                    }
                    group.PatchUpdate(group);
                    await repos.Groups.UpdateAsync(group);
                }

            }
            else
            {
                report.State = RequestStateEnum.Decline;
            }
            await repos.Reports.UpdateAsync(report);
        }

    }
}
