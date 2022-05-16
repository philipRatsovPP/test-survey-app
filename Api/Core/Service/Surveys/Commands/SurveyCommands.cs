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

        public Task SaveSurveyResponse(SurveyResponse response)
        {
            _responses.Add(response);
            return Task.CompletedTask;
        }
    }
}
