using Domain.Entities;

namespace Application.Interfaces;
public interface IComulator
{
    public Task<List<JobAd>> Comulate();
}
