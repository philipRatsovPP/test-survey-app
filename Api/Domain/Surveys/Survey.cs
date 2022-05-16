using System.ComponentModel.DataAnnotations;

#pragma warning disable CS8618

namespace task_app.Domain.Surveys
{
    public class Survey
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public SurveyProperties Properties { get; set; }
    }

    public class SurveyProperties
    {
        [Required]
        public FormDefinition FirstName { get; set; }

        [Required]
        public FormDefinition LastName { get; set; }

        [Required]
        public FormDefinition Email { get; set; }

        public FormDefinition Age { get; set; }
    }

    public class FormDefinition
    {
        public string Type { get; set; }
        public string Label { get; set; }
        public bool Required { get; set; }
        public int? MinValue { get; set; }
        public int? MaxValue { get; set; }

    }
}
