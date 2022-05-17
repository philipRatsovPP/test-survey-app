using Microsoft.AspNetCore.Mvc;

using task_app.ApiDomain.Surveys;
using task_app.Core.Service.Interfaces;

namespace task_app.Controllers;

[ApiController]
[Produces("application/json")]
[Route("[controller]")]
public class SurveyController : ControllerBase
{
    #region Dependencies

    private readonly ILogger<SurveyController> _logger;

    private readonly ISurveyQueries _surveyQueries;

    private readonly ISurveyCommands _surveyCommands;

    #endregion

    public SurveyController(
        ILogger<SurveyController> logger,
        ISurveyQueries surveyQueries,
        ISurveyCommands surveyCommands)
    {
        _logger = logger;
        _surveyQueries = surveyQueries;
        _surveyCommands = surveyCommands;
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

        var survey = await _surveyQueries.GetSurvey(id);

        var response = new GetSurveyResponse
        {
            Survey = survey,
        };

        return Ok(response);
    }

    /// <summary>
    /// Save a survey response.
    /// </summary>
    [HttpPost]
    [Route("response/{id}")]
    public async Task<ActionResult<SaveSurveyResponse>> SaveSurvey(
        [FromRoute] int id,
        [FromBody] SaveSurveyInput input)
    {
        _logger.LogDebug(
            "executing {Operation} ({SurveyId})",
            nameof(SaveSurvey),
            id);

        await _surveyCommands.SaveSurveyResponse(input.FirstName,
            input.LastName,
            input.Email,
            input.Age);

        var response = new SaveSurveyResponse();

        return Ok(response);
    }
}
