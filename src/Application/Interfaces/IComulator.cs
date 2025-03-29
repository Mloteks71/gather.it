using Application.Dtos;
using Domain.Entities;

namespace Application.Interfaces;
public interface IComulator
{
    public Task<List<JobAd>> Comulate(Action<RequestOptions> options);
}
