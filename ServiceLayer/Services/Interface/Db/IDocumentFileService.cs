using DataLayer.DbObject;
using Microsoft.AspNetCore.Http;
using ServiceLayer.DTOs;

namespace ServiceLayer.Services.Interface.Db;

public interface IDocumentFileService
{
    public Task<List<DocumentFileDto>> GetDocumentFilesByGroupId(int groupId);
    public Task ApproveRejectFile(DocumentFileDto documentFile);
    public Task UploadDocumentFIle(IFormFile fileUpload, int groupId, int accountId);
}