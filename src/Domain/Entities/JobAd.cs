using Domain.Enums;

namespace Domain.Entities;
public record JobAd
{
    public JobAd()
    {

    }

    public JobAd(string? name, string? description, RemoteType remoteType, int? remotePercent, List<City>? cities, List<Salary>? salaries, CompanyName companyName, string slug/*, JustJoinItCategory categoryId*/)
    {
        Name = name;
        Description = description;
        RemoteType = remoteType;
        RemotePercent = remotePercent;
        Cities = cities;
        Salaries = salaries;
        CompanyName = companyName;
        Slug = slug;
        //JobCategoryId = categoryId;
    }

    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public RemoteType RemoteType { get; set; }
    public int? RemotePercent { get; set; }
    public List<City>? Cities { get; set; }
    public List<Salary>? Salaries { get; set; }
    public int? CompanyNameId { get; set; }
    public CompanyName? CompanyName { get; set; }
    public string? Slug { get; set; }
    //public JustJoinItCategory JobCategoryId { get; set; }
}
