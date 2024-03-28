using Microsoft.EntityFrameworkCore;
using RepoLayer.Interface;
using ServiceLayer.DTOs;
using ServiceLayer.Utils;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DataLayer.Enums;
using DataLayer.DbObject;
using ServiceLayer.Utils;
using ServiceLayer.Services.Interface.Db;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Firebase.Storage;
using System.Security.Principal;
using ServiceLayer.Validation.FileUpload;

namespace ServiceLayer.Services.Implementation.Db
{
    public class GroupService : IGroupService
    {
        private IRepoWrapper repos;
        private readonly IMapper mapper;
        private IWebHostEnvironment _webHostEnvironment;

        public GroupService(IRepoWrapper repos, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            this.repos = repos;
            this.mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
        }
        public IQueryable<T> GetList<T>()
        {
            var list = repos.Groups.GetList();
            var mapped = list.ProjectTo<T>(mapper.ConfigurationProvider);
            return mapped;
        }

        public async Task<IQueryable<T>> SearchGroups<T>(string search, int studentId, bool newGroup)
        {
            search = search.ConvertToUnsign().ToLower();
            if (newGroup)
            {

                var list = repos.Groups.GetList()
                    .Include(e => e.GroupMembers)
                    .Include(e => e.GroupSubjects).ThenInclude(e => e.Subject)
                    .Where(e =>
                        !e.GroupMembers.Any(e => e.AccountId == studentId)
                        && (EF.Functions.Like(e.Id.ToString(), search + "%")
                        || e.Name.ConvertToUnsign().ToLower().Contains(search)
                        //|| search.Contains(e.ClassId.ToString())
                        || e.GroupSubjects.Any(gs => gs.Subject.Name.ConvertToUnsign().ToLower().Contains(search))));
                var mapped = list.ProjectTo<T>(mapper.ConfigurationProvider);
                return mapped;
            }
            else
            {
                var list = repos.Groups.GetList()
                 .Include(e => e.GroupMembers)
                 .Include(e => e.GroupSubjects).ThenInclude(e => e.Subject)
                 .Where(e =>
                     EF.Functions.Like(e.Id.ToString(), search + "%")
                     || e.Name.ConvertToUnsign().ToLower().Contains(search)
                     //|| search.Contains(e.ClassId.ToString())
                     || e.GroupSubjects.Any(gs => gs.Subject.Name.ConvertToUnsign().ToLower().Contains(search)));
                var mapped = list.ProjectTo<T>(mapper.ConfigurationProvider);
                return mapped;
            }
        }

        public async Task<IQueryable<T>> SearchGroupsBySubject<T>(string search, int studentId, bool newGroup)
        {
            search = search.ConvertToUnsign().ToLower();
            if (newGroup)
            {
                var list = repos.Groups.GetList()
                    .Include(e => e.GroupMembers)
                    .Include(e => e.GroupSubjects).ThenInclude(e => e.Subject)
                    .Where(e => !e.GroupMembers.Any(e => e.AccountId == studentId)
                        && e.GroupSubjects.Any(gs => gs.Subject.Name.ConvertToUnsign().ToLower().Contains(search)));
                var mapped = list.ProjectTo<T>(mapper.ConfigurationProvider);
                return mapped;
            }
            else
            {
                var list = repos.Groups.GetList()
                .Include(e => e.GroupMembers)
                .Include(e => e.GroupSubjects).ThenInclude(e => e.Subject)
                .Where(e => e.GroupSubjects.Any(gs => gs.Subject.Name.ConvertToUnsign().ToLower().Contains(search)));
                var mapped = list.ProjectTo<T>(mapper.ConfigurationProvider);
                return mapped;
            }
        }


        public async Task<IQueryable<T>> GetJoinGroupsOfStudentAsync<T>(int studentId)
        {
            var list = repos.GroupMembers.GetList()
                .Include(e => e.Group).ThenInclude(e => e.GroupMembers)
                .Where(e => e.AccountId == studentId && e.IsActive == true)
                .Select(e => e.Group);
            var mapped = list.ProjectTo<T>(mapper.ConfigurationProvider);
            return mapped;
        }

        public async Task<IQueryable<T>> GetMemberGroupsOfStudentAsync<T>(int studentId)
        {
            var list = repos.GroupMembers.GetList()
                .Include(e => e.Group).ThenInclude(e => e.GroupMembers)
                .Include(e => e.Group).ThenInclude(e => e.Discussions).ThenInclude(d=>d.AnswerDiscussion)
                .Where(e => e.AccountId == studentId && e.MemberRole == GroupMemberRole.Member && e.IsActive == true)
                .Select(e => e.Group);
            var mapped = list.ProjectTo<T>(mapper.ConfigurationProvider);
            return mapped;
        }

        public async Task<IQueryable<T>> GetLeaderGroupsOfStudentAsync<T>(int studentId)
        {
            var list = repos.GroupMembers.GetList()
                .Include(e => e.Group).ThenInclude(e => e.GroupMembers)
                .Include(e => e.Group).ThenInclude(e => e.Discussions).ThenInclude(d=>d.AnswerDiscussion)
                .Where(e => e.AccountId == studentId && e.MemberRole == GroupMemberRole.Leader && e.IsActive == true)
                .Select(e => e.Group);
            var mapped = list.ProjectTo<T>(mapper.ConfigurationProvider);
            return mapped;
        }

        public async Task<T> GetFullByIdAsync<T>(int id)
        {
            Group group = await repos.Groups.GetByIdAsync(id);
            T mapped = mapper.Map<T>(group);
            return mapped;
        }


        public async Task CreateAsync(GroupCreateDto dto, int creatorId)
        {
            string filePath = null;
            if (dto.Image != null && dto.Image.Length > 0)
            {
                if (dto.Image.FileName.HasImageExtension())
                {
                    // Initialize FirebaseStorage instance
                    var firebaseStorage = new FirebaseStorage("welearn-2024.appspot.com");

                    // Generate a unique file name
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + dto.Image.FileName;

                    // Get reference to the file in Firebase Storage
                    var fileReference = firebaseStorage.Child("Images").Child(uniqueFileName);

                    // Upload the file to Firebase Storage
                    using (var stream = dto.Image.OpenReadStream())
                    {
                        await fileReference.PutAsync(stream);
                    }

                    // Get the download URL of the uploaded file
                    string downloadUrl = await fileReference.GetDownloadUrlAsync();
                    filePath = downloadUrl;
                }
                else
                {
                    throw new ArgumentException("Not support file type!", nameof(dto.Image.FileName));
                }
            }
            else
            {
                var bucket = "welearn-2024.appspot.com";
                var path = "Images/groupdefault.jpg"; // Path to image

                // Initialize Firebase storage
                var storage = new FirebaseStorage(bucket);

                // Get the download URL for the image
                string downloadUrl = await storage.Child(path).GetDownloadUrlAsync();
                filePath = downloadUrl;
            }

            Group entity = mapper.Map<Group>(dto);
            entity.GroupMembers.Add(new GroupMember
            {
                AccountId = creatorId,
                MemberRole = GroupMemberRole.Leader
            });
            entity.ImagePath = filePath;

            await repos.Groups.CreateAsync(entity);
        }

        public async Task RemoveAsync(int id)
        {
            await repos.Groups.RemoveAsync(id);
        }

        //public async Task UpdateAsync(Group entity)
        //{
        //    await repos.Groups.UpdateAsync(entity);
        //}

        public async Task UpdateAsync(GroupUpdateDto dto)
        {
            var group = await repos.Groups.GetByIdAsync(dto.Id);

            //Image
            if(dto.Image != null && dto.Image.Length > 0)
            {
                if (dto.Image.FileName.HasImageExtension())
                {
                    // Initialize FirebaseStorage instance
                    var firebaseStorage = new FirebaseStorage("welearn-2024.appspot.com");

                    // Generate a unique file name
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + dto.Image.FileName;

                    // Get reference to the file in Firebase Storage
                    var fileReference = firebaseStorage.Child("Images").Child(uniqueFileName);

                    // Upload the file to Firebase Storage
                    using (var stream = dto.Image.OpenReadStream())
                    {
                        await fileReference.PutAsync(stream);
                    }

                    // Get the download URL of the uploaded file
                    string downloadUrl = await fileReference.GetDownloadUrlAsync();
                    group.ImagePath = downloadUrl;
                }
                else
                {
                    throw new ArgumentException("Not support file type!", nameof(dto.Image.FileName));
                }
            }

            //Remove subject, nếu dto ko có thì sẽ loại
            group.PatchUpdate(dto);
            List<GroupSubject> groupSubjects = group.GroupSubjects.ToList();
            foreach (GroupSubject groupSubject in groupSubjects)
            {
                if (!dto.SubjectIds.Cast<int>().Contains(groupSubject.SubjectId))
                {
                    group.GroupSubjects.Remove(groupSubject);
                }
            }
            //Add new subject, nếu group ko có thì add
            foreach (int subjectId in dto.SubjectIds)
            {
                if (!group.GroupSubjects.Any(e => e.SubjectId == subjectId))
                {
                    group.GroupSubjects.Add(new GroupSubject { GroupId = group.Id, SubjectId = subjectId });
                }
            }
            //if (dto.())
            //{
            //    repos.G
            //}
            //group.GroupSubjects = dto.SubjectIds.Select(subId => new GroupSubject { GroupId = dto.Id, SubjectId = (int)subId }).ToList();
            await repos.Groups.UpdateAsync(group);
        }

        public async Task<List<int>> GetLeaderGroupsIdAsync(int studentId)
        {
            return repos.GroupMembers.GetList()
                .Include(e => e.Group).ThenInclude(e => e.GroupMembers)
                .Where(e => e.AccountId == studentId && e.MemberRole == GroupMemberRole.Leader && e.IsActive == true)
                .Select(e => e.GroupId).ToList();
        }

        public async Task<bool> IsStudentLeadingGroupAsync(int studentId, int groupId)
        {
            return await repos.GroupMembers.GetList()
                .AnyAsync(e => e.AccountId == studentId && e.GroupId == groupId && e.MemberRole == GroupMemberRole.Leader
                     && e.IsActive == true);
        }

        public async Task<bool> IsStudentMemberGroupAsync(int studentId, int groupId)
        {
            return await repos.GroupMembers.GetList()
                .AnyAsync(e => e.AccountId == studentId && e.GroupId == groupId && e.MemberRole == GroupMemberRole.Member
                     && e.IsActive == true);
        }

        public async Task<bool> IsStudentJoiningGroupAsync(int studentId, int groupId)
        {
            return await repos.GroupMembers.GetList()
               .AnyAsync(e => e.AccountId == studentId && e.GroupId == groupId
                    && e.IsActive == true);
        }
        //Fix later
        public async Task<bool> IsStudentRequestingToGroupAsync(int studentId, int groupId)
        {
            return await repos.Requests.GetList()
              .AnyAsync(e => e.AccountId == studentId && e.GroupId == groupId
                && e.State == RequestStateEnum.Waiting
              );
        }
        //Fix later
        public async Task<bool> IsStudentInvitedToGroupAsync(int studentId, int groupId)
        {
            return await repos.GroupMembers.GetList()
              .AnyAsync(e => e.AccountId == studentId && e.GroupId == groupId && e.IsActive == true
              //&& (e.State == GroupMemberState.Inviting)
              );
        }

        public async Task<bool> IsStudentBannedToGroupAsync(int studentId, int groupId)
        {
            return await repos.GroupMembers.GetList()
                .AnyAsync(e => e.AccountId == studentId && e.GroupId == groupId && e.IsActive == false);
        }

        public async Task<bool> ExistsAsync(int groupId)
        {
            return await repos.Groups.IdExistAsync(groupId);
        }
    }
}
