
namespace task_app.Core.Service.Interfaces
{
    public interface ISurveyCommands
    {
        Task SaveSurveyResponse(string firstName,
            string lastName,
            string email,
            int? age);
    }

}
