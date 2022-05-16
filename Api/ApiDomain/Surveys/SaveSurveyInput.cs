using System.ComponentModel.DataAnnotations;

#pragma warning disable CS8618

namespace task_app.ApiDomain.Surveys
{
    public class SaveSurveyInput
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        public int? Age { get; set; }
    }

    public class SaveSurveyResponse
    {
    }
}
