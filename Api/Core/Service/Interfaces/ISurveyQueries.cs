using task_app.Domain.Surveys;

namespace task_app.Core.Service.Interfaces
{
    public interface ISurveyQueries
    {
        Task<Survey[]> ListSurveysAsync();

        Task<Survey> GetSurvey(int id);
    }
}
