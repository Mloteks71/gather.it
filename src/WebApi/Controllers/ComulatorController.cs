using Application.Interfaces;
using Domain.Entities;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ComulatorController(IComulatorProvider comulatorProvider, IJobAdsService jobAdsService) : ControllerBase
{
    private readonly IComulatorProvider _comulatorProvider = comulatorProvider;

    [HttpPost("download")]
    public async Task<ActionResult> DownloadJobData([FromQuery] string startPage, [FromQuery] string endPage, CancellationToken cancellationToken)
    {
        long startPageNumeric;
        long endPageNumeric;

        bool startPageParseResult = long.TryParse(startPage, out startPageNumeric);
        bool endPageParseResult = long.TryParse(endPage, out endPageNumeric);

        if (!startPageParseResult || !endPageParseResult)
            BadRequest("Invalid parameters");

        List<JobAd> jobAds = await _comulatorProvider.Get(ComulatorType.JustJoinIt).Comulate((options) => {
            options.StartPage = 1;
            options.EndPage = 10;
        });

        await jobAdsService.Save(jobAds, cancellationToken);
        return Ok();
    }
}
