using task_app.Domain.Surveys;

namespace task_app.Core.Service.Interfaces
{
    public interface ISurveyCommands
    {
        Task SaveSurveyResponse(SurveyResponse response);
    }

}
