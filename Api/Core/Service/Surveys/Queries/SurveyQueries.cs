using task_app.Core.Service.Interfaces;
using task_app.Domain.Surveys;

namespace task_app.Core.Service.Surveys.Queries
{
    public class SurveyQueries : ISurveyQueries
    {
        public Task<Survey> GetSurvey(int id)
        {
            return Task.FromResult(
                new Survey
                {
                    Id = 12,
                    Name = "Sample Form",
                    Description = "<p>This is a sample form<br/>description can have <strong>html encoded</strong></p>",
                    Properties = new SurveyProperties
                    {
                        FirstName = new FormDefinition
                        {
                            Type = "string",
                            Label = "First Name",
                            Required = true,
                        },
                        LastName = new FormDefinition
                        {
                            Type = "string",
                            Label = "Last Name",
                            Required = true,
                        },
                        Email = new FormDefinition
                        {
                            Type = "string",
                            Label = "Email",
                            Required = true,
                        },
                        Age = new FormDefinition
                        {
                            Type = "number",
                            Label = "Your Age",
                            Required = false,
                            MinValue = 18,
                            MaxValue = 135,
                        }
                    }

                });
        }

        public Task<Survey[]> ListSurveysAsync()
        {
            return Task.FromResult(new[]
            {
               new Survey
               {
                Id = 12,
                Name = "Sample Form"
               },
               new Survey
               {
                Id = 12,
                Name = "Another Sample Form with same Id"
               },
               new Survey
               {
                Id = 12,
                Name = "Yet Another Sample Form with same Id"
               }
            });
        }
    }
}
