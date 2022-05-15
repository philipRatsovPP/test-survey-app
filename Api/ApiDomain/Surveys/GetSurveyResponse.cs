using System.ComponentModel.DataAnnotations;
using task_app.Domain.Surveys;

#pragma warning disable CS8618

namespace task_app.ApiDomain.Surveys
{
    public class GetSurveyResponse
    {
        [Required]
        public Survey Survey { get; init; }
    }
}
