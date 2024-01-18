using DataLayer.DbContext;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.ClassImplement
{
    public class RepoWrapper : IRepoWrapper
    {
        private readonly WeLearnContext dbContext;

        public RepoWrapper(WeLearnContext dbContext)
        {
            this.dbContext = dbContext;
            users = new AccountRepo(dbContext);
            meeting = new MeetingRepository(dbContext);
            groupMembers = new GroupMemberReposity(dbContext);
        }

        private IAccountRepo users;
        public IAccountRepo Accounts
        {
            get
            {
                if (users is null)
                {
                    users = new AccountRepo(dbContext);
                }
                return users;
            }
        }

        //private IMeetingRepository meetingRooms;
        //public IMeetingRepository Meetings
        //{
        //    get
        //    {
        //        if (meetingRooms is null)
        //        {
        //            meetingRooms = new MeetingRepository(dbContext, mapper);
        //        }
        //        return meetingRooms;
        //    }
        //}

        private IMeetingRepository meeting;
        public IMeetingRepository Meetings
        {
            get
            {
                if (meeting is null)
                {
                    meeting = new MeetingRepository(dbContext);
                }
                return meeting;
            }
        }

        private IGroupRepository groups;
        public IGroupRepository Groups
        {
            get
            {
                if (groups is null)
                {
                    groups = new GroupRepository(dbContext);
                }
                return groups;
            }
        }

        private IGroupMemberReposity groupMembers;
        public IGroupMemberReposity GroupMembers
        {
            get
            {
                if (groupMembers is null)
                {
                    groupMembers = new GroupMemberReposity(dbContext);
                }
                return groupMembers;
            }
        }

        private ISubjectRepository subjects;
        public ISubjectRepository Subjects
        {
            get
            {
                if (subjects is null)
                {
                    subjects = new SubjectRepository(dbContext);
                }
                return subjects;
            }
        }

        public IScheduleRepository schedules;
        public IScheduleRepository Schedules
        {
            get
            {
                if (schedules is null)
                {
                    schedules = new ScheduleRepository(dbContext);
                }
                return schedules;
            }

        }

        private IInviteReposity invites;
        public IInviteReposity Invites
        {
            get
            {
                if (invites is null)
                {
                    invites = new InviteReposity(dbContext);
                }
                return invites;
            }

        }

        private IRequestReposity requests;
        public IRequestReposity Requests
        {
            get
            {
                if (requests is null)
                {
                    requests = new RequestReposity(dbContext);
                }
                return requests;
            }

        }
    }
}
