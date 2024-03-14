using AutoMapper;
using DataLayer.DbObject;
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
            string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "DocumentFiles");
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            string uniqueFileName = Guid.NewGuid().ToString() + "_" + fileUpload.FileName;

            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await fileUpload.CopyToAsync(fileStream);
            }
            DocumentFile file = new DocumentFile();
            file.HttpLink = filePath;
            file.Approved = false;
            file.GroupId = groupId;
            file.AccountId = accountId;
            file.CreatedDate = DateTime.UtcNow;

            await repos.DocumentFiles.CreateAsync(file);

        }
    }
}
