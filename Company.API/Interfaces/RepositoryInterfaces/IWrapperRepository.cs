namespace Company.API.Interfaces.RepositoryInterfaces;

public interface IWrapperRepository
{
    ICompanyRepository CompanyRepository { get; }
}