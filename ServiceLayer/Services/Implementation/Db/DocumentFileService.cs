using AutoMapper;
using DataLayer.DbObject;
using Firebase.Storage;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Org.BouncyCastle.Asn1.Ocsp;
using RepoLayer.Interface;
using ServiceLayer.DTOs;
using ServiceLayer.Services.Interface.Db;
using System.IO;

namespace ServiceLayer.Services.Implementation.Db;

public class DocumentFileService : IDocumentFileService
{
    private IRepoWrapper repos;
    private IMapper mapper;
    private IWebHostEnvironment _webHostEnvironment;


    public DocumentFileService(IRepoWrapper repos, IMapper mapper, IWebHostEnvironment webHostEnvironment)
    {
        this.repos = repos;
        this.mapper = mapper;
        _webHostEnvironment = webHostEnvironment;
    }
    public async Task<List<DocumentFileDto>> GetDocumentFilesByGroupId(int groupId)
    {
        var documentFiles = await repos.DocumentFiles.GetDocumentFilesByGroupId(groupId);
        var mapped = mapper.Map<List<DocumentFileDto>>(documentFiles);
        return mapped;
    }
    public async Task ApproveRejectFile(int documentId ,Boolean check)
    {
        var file = await repos.DocumentFiles.GetByIdAsync(documentId);
        file.Approved = check;
        
        await repos.DocumentFiles.ApproveRejectAsync(file);
    }

    public async Task UploadDocumentFIle(IFormFile fileUpload, int groupId, int accountId)
    {
        if (fileUpload != null && fileUpload.Length > 0)
        {
            // Initialize FirebaseStorage instance
            var firebaseStorage = new FirebaseStorage("welearn-2024.appspot.com");

            // Generate a unique file name
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + fileUpload.FileName;

            // Get reference to the file in Firebase Storage
            var fileReference = firebaseStorage.Child("DocumentFiles").Child(uniqueFileName);

            // Upload the file to Firebase Storage
            using (var stream = fileUpload.OpenReadStream())
            {
                await fileReference.PutAsync(stream);
            }

            // Get the download URL of the uploaded file
            string downloadUrl = await fileReference.GetDownloadUrlAsync();

            // Update the discussion entity with the download URL

            DocumentFile file = new DocumentFile();
            file.HttpLink = downloadUrl;
            file.Approved = false;
            file.GroupId = groupId;
            file.AccountId = accountId;
            file.CreatedDate = DateTime.UtcNow;
            file.IsActive = true;

            await repos.DocumentFiles.CreateAsync(file);
        }

    }
}
