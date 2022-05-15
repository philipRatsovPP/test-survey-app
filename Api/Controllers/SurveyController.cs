using Microsoft.AspNetCore.Mvc;
using task_app.ApiDomain.Surveys;
using task_app.Core.Service.Interfaces;
using task_app.Domain.Surveys;

namespace task_app.Controllers;

[ApiController]
[Route("[controller]")]
public class SurveyController : ControllerBase
{
    #region Dependencies

    private readonly ILogger<SurveyController> _logger;

    private readonly ISurveyQueries _surveyQueries;

    #endregion

    public SurveyController(
        ILogger<SurveyController> logger,
        ISurveyQueries surveyQueries)
    {

        _logger = logger;
        _surveyQueries = surveyQueries;
    }


    /// <summary>
    /// List all existing surveys.
    /// </summary>
    [HttpGet]
    [Route("surveys")]
    public async Task<ActionResult<ListSurveysResponse>> ListSurveys()
    {
        _logger.LogDebug(
            "executing {Operation}",
            nameof(ListSurveys));

        var surveys = await _surveyQueries.ListSurveysAsync();

        var response = new ListSurveysResponse
        {
            Surveys = surveys,
        };

        return Ok(response);
    }

    /// <summary>
    /// Gets an existing survey by its id.
    /// </summary>
    /// <param name="id">The id of the survey.</param>
    [HttpGet]
    [Route("surveys/{id}")]
    public async Task<ActionResult<GetSurveyResponse>> GetSurvey(
        [FromRoute] int id)
    {
        _logger.LogDebug(
            "executing {Operation} ({SurveyId})",
            nameof(GetSurvey),
            id);

        var servey = await _surveyQueries.GetSurvey(id);

        var response = new GetSurveyResponse
        {
            Survey = servey,
        };

        return Ok(response);
    }
}

