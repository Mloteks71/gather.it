﻿using Domain.Entities;
using Domain.Enums;
using System.Text.Json.Serialization;

namespace Application.Dtos.JustJoinIt;
public class JustJoinItResponse
{
    [JsonPropertyName("data")]
    public required List<JustJoinItJob> Jobs { get; set; }
    [JsonPropertyName("meta")]
    public required JustJoinItMetadata MetaData { get; set; }

    public List<JobAd> CreateDtos()
    {
        List<JobAd> Dtos = [];

        foreach (JustJoinItJob job in Jobs ?? [])
        {
            List<City> citys = job.Multilocation?.Select(x => new City(x.City)).ToList() ?? [];
            citys.Add(new City(job.City));
            citys = citys.Distinct().ToList();
            List<Salary> salarys = job.EmploymentTypes?.Select(x => new Salary(MapToContractType(x.Type), Convert.ToInt32(x.FromPln), Convert.ToInt32(x.ToPln))).ToList() ?? [];
            CompanyName companyName = new(job.CompanyName);
            JobAd JobAd = new(job.Title, null/*dodać w serwisie pytanie w pętli o każdą ofertę, żeby mieć opis*/, MapToRemoteType(job.WorkplaceType), null, citys, salarys, companyName, job.Slug/*, job.CategoryId*/);
            Dtos.Add(JobAd);
        }

        return Dtos;
    }

    #region mappings

    private static readonly Dictionary<string, ContractType> ContractTypeMap = new(StringComparer.OrdinalIgnoreCase)
    {
        { "permanent", ContractType.UoP },
        { "B2B", ContractType.B2B },
        { "mandate_contract", ContractType.UZ },
        { "any", ContractType.Any }
    };

    private static ContractType MapToContractType(string input)
    {
        if (ContractTypeMap.TryGetValue(input, out var result))
        {
            return result;
        }
        throw new ArgumentException($"No enum value mapped to string: {input}");
    }

    private static readonly Dictionary<string, RemoteType> RemoteTypeMap = new(StringComparer.OrdinalIgnoreCase)
    {
        { "Remote", RemoteType.Remote },
        { "Office", RemoteType.Stationary },
        { "Hybrid", RemoteType.Hybrid }
    };

    private static RemoteType MapToRemoteType(string type)
    {
        RemoteType result = RemoteType.None;

        if (RemoteTypeMap.TryGetValue(type, out RemoteType flag))
        {
            result |= flag; // Combine flags using bitwise OR
        }

        return result;
    }

    #endregion

    #region classes
    public class JustJoinItJob
    {
        [JsonPropertyName("slug")]
        public required string Slug { get; set; }

        [JsonPropertyName("title")]
        public required string Title { get; set; }

        [JsonPropertyName("requiredSkills")]
        public List<string>? RequiredSkills { get; set; }

        [JsonPropertyName("niceToHaveSkills")]
        public List<string>? NiceToHaveSkills { get; set; }

        [JsonPropertyName("workplaceType")]
        public required string WorkplaceType { get; set; }

        [JsonPropertyName("workingTime")]
        public required string WorkingTime { get; set; }

        [JsonPropertyName("experienceLevel")]
        public required string ExperienceLevel { get; set; }

        [JsonPropertyName("employmentTypes")]
        public List<JustJoinItEmploymentType>? EmploymentTypes { get; set; }

        [JsonPropertyName("categoryId")]
        public required JustJoinItCategory CategoryId { get; set; }

        [JsonPropertyName("multilocation")]
        public List<JustJoinItMultilocation>? Multilocation { get; set; }

        [JsonPropertyName("city")]
        public required string City { get; set; }

        [JsonPropertyName("street")]
        public required string Street { get; set; }

        [JsonPropertyName("latitude")]
        public required double? Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public required double? Longitude { get; set; }

        [JsonPropertyName("remoteInterview")]
        public required bool RemoteInterview { get; set; }

        [JsonPropertyName("companyName")]
        public required string CompanyName { get; set; }

        [JsonPropertyName("companyLogoThumbUrl")]
        public required string CompanyLogoThumbUrl { get; set; }

        [JsonPropertyName("publishedAt")]
        public required DateTime PublishedAt { get; set; }

        [JsonPropertyName("openToHireUkrainians")]
        public required bool OpenToHireUkrainians { get; set; }

        [JsonPropertyName("languages")]
        public List<JustJoinItLanguage>? Languages { get; set; }
    }

    public class JustJoinItMetadata
    {
        [JsonPropertyName("NextPage")]
        public required int? NextPage { get; set; }
        [JsonPropertyName("Page")]
        public required int Page { get; set; }
        [JsonPropertyName("PrevPage")]
        public required int? PrevPage { get; set; }
        [JsonPropertyName("TotalItems")]
        public required int? TotalItems { get; set; }
        [JsonPropertyName("TotalPages")]
        public required int TotalPages { get; set; }
    }

    public class JustJoinItEmploymentType
    {
        [JsonPropertyName("from")]
        public double? From { get; set; }

        [JsonPropertyName("to")]
        public double? To { get; set; }

        [JsonPropertyName("currency")]
        public required string Currency { get; set; }

        [JsonPropertyName("type")]
        public required string Type { get; set; }

        [JsonPropertyName("unit")]
        public required string Unit { get; set; }

        [JsonPropertyName("gross")]
        public bool Gross { get; set; }

        [JsonPropertyName("fromChf")]
        public double? FromChf { get; set; }

        [JsonPropertyName("fromEur")]
        public double? FromEur { get; set; }

        [JsonPropertyName("fromGbp")]
        public double? FromGbp { get; set; }

        [JsonPropertyName("fromPln")]
        public double? FromPln { get; set; }

        [JsonPropertyName("fromUsd")]
        public double? FromUsd { get; set; }

        [JsonPropertyName("toChf")]
        public double? ToChf { get; set; }

        [JsonPropertyName("toEur")]
        public double? ToEur { get; set; }

        [JsonPropertyName("toGbp")]
        public double? ToGbp { get; set; }

        [JsonPropertyName("toPln")]
        public double? ToPln { get; set; }

        [JsonPropertyName("toUsd")]
        public double? ToUsd { get; set; }
    }

    public class JustJoinItMultilocation
    {
        [JsonPropertyName("city")]
        public required string City { get; set; }

        [JsonPropertyName("slug")]
        public required string Slug { get; set; }

        [JsonPropertyName("street")]
        public required string Street { get; set; }

        [JsonPropertyName("latitude")]
        public required double? Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public required double? Longitude { get; set; }
    }

    public class JustJoinItLanguage
    {
        [JsonPropertyName("code")]
        public required string Code { get; set; }

        [JsonPropertyName("level")]
        public required string Level { get; set; }
    }

    //public enum JustJoinItCategory
    //{
    //    JS = 1,
    //    HTML = 2,
    //    PHP = 3,
    //    Ruby = 4,
    //    Python = 5,
    //    Java = 6,
    //    dotNET = 7,
    //    Scala = 8,
    //    C = 9,
    //    Mobile = 10,
    //    Testing = 11,
    //    DevOps = 12,
    //    Admin = 13,
    //    UXUI = 14,
    //    PM = 15,
    //    Game = 16,
    //    Analytics = 17,
    //    Security = 18,
    //    Data = 19,
    //    Go = 20,
    //    Support = 21,
    //    ERP = 22,
    //    Architecture = 23,
    //    Other = 24,
    //    AI = 25
    //}
}
#endregion