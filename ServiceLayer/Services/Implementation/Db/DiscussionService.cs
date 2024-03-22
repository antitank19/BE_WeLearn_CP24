using AutoMapper;
using DataLayer.DbObject;
using Firebase.Storage;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using RepoLayer.Interface;
using ServiceLayer.DTOs;
using ServiceLayer.Services.Interface.Db;
using ServiceLayer.Utils;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ServiceLayer.Services.Implementation.Db
{
    public class DiscussionService : IDiscussionService
    {
        private IRepoWrapper _repos;
        private IMapper _mapper;
        private IWebHostEnvironment _webHostEnvironment;

        public DiscussionService(IRepoWrapper repoWrapper, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _mapper = mapper;
            _repos = repoWrapper;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<List<DiscussionDto>> GetDocumentFilesByGroupId(int groupId)
        {
            var discussion = await _repos.Discussions.GetDocumentFilesByGroupId(groupId);
            var mapper = _mapper.Map<List<DiscussionDto>>(discussion);
            return mapper;
        }

        public async Task UdateDiscussion(int discussionId, UploadDiscussionDto discussionDto, IFormFile? file)
        {
            var discussion = await _repos.Discussions.GetByIdAsync(discussionId);
            
            string filePath = null;
          
            if (file != null && file.Length > 0)
            {
                // Initialize FirebaseStorage instance
                var firebaseStorage = new FirebaseStorage("welearn-2024.appspot.com");

                // Generate a unique file name
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;

                // Get reference to the file in Firebase Storage
                var fileReference = firebaseStorage.Child("DiscussionFiles").Child(uniqueFileName);

                // Upload the file to Firebase Storage
                using (var stream = file.OpenReadStream())
                {
                    await fileReference.PutAsync(stream);
                }

                // Get the download URL of the uploaded file
                string downloadUrl = await fileReference.GetDownloadUrlAsync();

                // Update the discussion entity with the download URL
                discussion.FilePath = downloadUrl;
            }

            discussion.PatchUpdate(discussionDto);

            await _repos.Discussions.UpdateAsync(discussion);
        }

        public async Task UploadDiscussion(int accountId, int groupId, UploadDiscussionDto discussiondto, IFormFile? file)
        {
            string filePath;
            Discussion discussion = _mapper.Map<Discussion>(discussiondto);
            discussion.GroupId = groupId;
            discussion.AccountId = accountId;

            if (file != null && file.Length > 0)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "DiscussionFiles");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;

                filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
                discussion.FilePath = filePath;

            }

            await _repos.Discussions.CreateAsync(discussion);
        }
    }
}
