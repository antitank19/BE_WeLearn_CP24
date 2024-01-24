using RepositoryLayer.Interface;
using ServiceLayer.Services.Interface.Db;

namespace ServiceLayer.Services.Implementation.Db;

public class DocumentFileService : IDocumentFileService
{
    private IRepoWrapper repos;

    public DocumentFileService(IRepoWrapper repos)
    {
        this.repos = repos;
    }



}