using task_app.Core.Service.Interfaces;
using task_app.Domain.Surveys;

namespace task_app.Core.Service.Surveys.Queries
{
    public class SurveyCommands : ISurveyCommands
    {
        private readonly List<SurveyResponse> _responses;

        public SurveyCommands()
        {
            _responses = new List<SurveyResponse>();
        }

        public Task SaveSurveyResponse(
            string firstName,
            string lastName,
            string email,
            int? age)
        {
            var response = new SurveyResponse
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Age = age
            };

            _responses.Add(response);
            return Task.CompletedTask;
        }
    }
}
