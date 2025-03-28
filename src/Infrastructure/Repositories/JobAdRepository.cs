using Application.Interfaces.Repositories;
using Domain;
using Domain.Entities;

namespace Infrastructure.Repositories;
public class JobAdRepository(GatherItDbContext context) : IJobAdRepository
{
    private readonly GatherItDbContext _context = context;

    public IEnumerable<JobAd> GetJobAds(IEnumerable<string> companyNames)
    {
        var companyNamesSet = new HashSet<string>(companyNames, StringComparer.OrdinalIgnoreCase);

        return _context.JobAds.Where(x =>
            (x.CompanyName != null
             && x.CompanyName.Company != null
             && x.CompanyName.Company.Names != null
             && x.CompanyName.Company.Names.Select(n => n.Name).Any(name => companyNamesSet.Contains(name))) ||
            (x.CompanyName != null
             && x.CompanyName.Company == null
             && companyNamesSet.Contains(x.CompanyName.Name)));
    }

    public async Task InsertJobAds(List<JobAd> jobAds)
    {
        await _context.JobAds.AddRangeAsync(jobAds);

        await _context.SaveChangesAsync();
    }
}
