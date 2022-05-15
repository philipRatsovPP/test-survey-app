using System.ComponentModel.DataAnnotations;
using task_app.Domain.Surveys;

#pragma warning disable CS8618

namespace task_app.ApiDomain.Surveys
{
    public class ListSurveysResponse
    {
        [Required]
        public Survey[] Surveys { get; set; }
    }
}
