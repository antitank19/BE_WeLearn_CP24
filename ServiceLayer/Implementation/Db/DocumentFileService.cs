using RepositoryLayer.Interface;
using ServiceLayer.Interface.Db;

namespace ServiceLayer.Implementation.Db;

public class DocumentFileService : IDocumentFileService
{
    private IRepoWrapper repos;

    public DocumentFileService(IRepoWrapper repos)
    {
        this.repos = repos;
    }

    
   
}