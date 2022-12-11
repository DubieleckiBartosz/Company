using Company.API.Interfaces.RepositoryInterfaces;

namespace Company.API.Repositories.MongoRepositories;

public class WrapperRepository : IWrapperRepository
{
    private ICompanyRepository _companyRepository;
    private readonly MongoContext _context;

    public WrapperRepository(MongoContext context)
    {
        _context = context;
    }

    public ICompanyRepository CompanyRepository
    {
        get
        {
            return _companyRepository ??= new CompanyRepository(_context);
        }
    }
}