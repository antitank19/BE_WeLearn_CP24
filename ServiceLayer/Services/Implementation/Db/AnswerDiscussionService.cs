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

namespace ServiceLayer.Services.Implementation.Db
{
    internal class AnswerDiscussionService : IAnswerDiscussionService
    {
        private IRepoWrapper _repos;
        private IMapper _mapper;
        private IWebHostEnvironment _webHostEnvironment;

        public AnswerDiscussionService(IRepoWrapper repoWrapper, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _mapper = mapper;
            _repos = repoWrapper;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<List<AnswerDiscussion>> GetAnswerDiscussionByDiscussionId(int discussionId)
        {
            return await _repos.AnswerDiscussions.GetAnswerDiscussionsByDiscussionId(discussionId);
        }

        public async Task UpdateAnswerDiscussion(int answeDiscussionId, UploadAnswerDiscussionDto answerDiscussionDto)
        {
            var answerDiscussion = await _repos.AnswerDiscussions.GetByIdAsync(answeDiscussionId);

            if (answerDiscussionDto.File != null && answerDiscussionDto.File.Length > 0)
            {
                // Initialize FirebaseStorage instance
                var firebaseStorage = new FirebaseStorage("welearn-2024.appspot.com");

                // Generate a unique file name
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + answerDiscussionDto.File.FileName;

                // Get reference to the file in Firebase Storage
                var fileReference = firebaseStorage.Child("DiscussionFiles").Child(uniqueFileName);

                // Upload the file to Firebase Storage
                using (var stream = answerDiscussionDto.File.OpenReadStream())
                {
                    await fileReference.PutAsync(stream);
                }

                // Get the download URL of the uploaded file
                string downloadUrl = await fileReference.GetDownloadUrlAsync();

                // Update the discussion entity with the download URL
                answerDiscussion.FilePath = downloadUrl;
            }

            answerDiscussion.PatchUpdate(answerDiscussionDto);

            await _repos.AnswerDiscussions.UpdateAsync(answerDiscussion);
        }

        public async Task UploadAnswerDiscussion(int accountId, int discussionId, UploadAnswerDiscussionDto answerDiscussionDto)
        {
            string filePath;
            AnswerDiscussion answerDiscussion = _mapper.Map<AnswerDiscussion>(answerDiscussionDto);
            answerDiscussion.DiscussionId = discussionId;
            answerDiscussion.AccountId = accountId;

            if (answerDiscussionDto.File != null && answerDiscussionDto.File.Length > 0)
            {
                // Initialize FirebaseStorage instance
                var firebaseStorage = new FirebaseStorage("welearn-2024.appspot.com");

                // Generate a unique file name
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + answerDiscussionDto.File.FileName;

                // Get reference to the file in Firebase Storage
                var fileReference = firebaseStorage.Child("DiscussionFiles").Child(uniqueFileName);

                // Upload the file to Firebase Storage
                using (var stream = answerDiscussionDto.File.OpenReadStream())
                {
                    await fileReference.PutAsync(stream);
                }

                // Get the download URL of the uploaded file
                string downloadUrl = await fileReference.GetDownloadUrlAsync();

                // Update the discussion entity with the download URL
                answerDiscussion.FilePath = downloadUrl;
            }

            await _repos.AnswerDiscussions.CreateAsync(answerDiscussion);
        }
    }
}
