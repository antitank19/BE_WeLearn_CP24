using RepositoryLayer.Interface;
using ServiceLayer.Interface;
using ServiceLayer.Interface.Auth;
using ServiceLayer.Interface.Db;
using ServiceLayer.Implementation.Auth;
using Microsoft.Extensions.Configuration;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using ServiceLayer.Implementation.Db;
using ServiceLayer.Implemention.Mail;
using ServiceLayer.Interface.Mail;

namespace ServiceLayer.Implementation
{
    public class ServiceWrapper : IServiceWrapper
    {
        private readonly IRepoWrapper repos;
        private readonly IConfiguration configuration;
        private readonly IMapper mapper;
        private readonly IWebHostEnvironment env;


        public ServiceWrapper(IRepoWrapper repos, IConfiguration configuration, IMapper mapper, IWebHostEnvironment env)
        {
            this.repos = repos;
            this.configuration = configuration;
            this.mapper = mapper;
            this.env = env;
            accounts = new AccountService(repos, mapper);
            auth = new AuthService(repos, configuration);
            groups = new GroupService(repos, mapper);
            subjects = new SubjectService(repos);
            meetings = new MeetingService(repos, mapper);
            groupMembers = new GroupMemberSerivce(repos, mapper);
            documentFiles = new DocumentFileService(repos);
            stats = new StatService(repos, mapper);
            mails = new AutoMailService(env, repos, configuration, Accounts, Stats);
        }

        private IAccountService accounts;
        public IAccountService Accounts
        {
            get
            {
                if (accounts is null)
                {
                    accounts = new AccountService(repos, mapper);
                }
                return accounts;
            }
        }

        private IAuthService auth;
        public IAuthService Auth
        {
            get
            {
                if (auth is null)
                {
                    auth = new AuthService(repos, configuration);
                }
                return auth;
            }
        }

        private IGroupService groups;
        public IGroupService Groups
        {
            get
            {
                if (groups is null)
                {
                    groups = new GroupService(repos, mapper);
                }
                return groups;
            }
        }

        private ISubjectService subjects;
        public ISubjectService Subjects
        {
            get
            {
                if (subjects is null)
                {
                    subjects = new SubjectService(repos);
                }
                return subjects;
            }
        }

        private IMeetingService meetings;
        public IMeetingService Meetings
        {
            get
            {
                if (meetings is null)
                {
                    meetings = new MeetingService(repos, mapper);
                }
                return meetings;
            }
        }

        private IGroupMemberSerivce groupMembers;
        public IGroupMemberSerivce GroupMembers
        {
            get
            {
                if (groupMembers is null)
                {
                    groupMembers = new GroupMemberSerivce(repos, mapper);
                }
                return groupMembers;
            }
        }
        private IDocumentFileService documentFiles;

        public IDocumentFileService DocumentFiles
        {
            get
            {
                if (documentFiles is null)
                {
                    documentFiles = new DocumentFileService(repos);
                }
                return documentFiles;
            }
        }

        private IStatService stats;
        public IStatService Stats
        {
            get
            {
                if (stats is null)
                {
                    stats = new StatService(repos, mapper);
                }
                return stats;
            }
        }
        private IAutoMailService mails;
        public IAutoMailService Mails
        {
            get
            {
                if (mails is null)
                {
                    mails = new AutoMailService(env, repos, configuration, Accounts, Stats);
                }
                return mails;
            }
        }
    }
}

