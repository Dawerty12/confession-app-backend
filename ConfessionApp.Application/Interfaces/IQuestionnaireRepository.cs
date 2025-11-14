using ConfessionApp.Core.Entities;

namespace ConfessionApp.Application.Interfaces
{
    // O "Contrato"
    public interface IQuestionnaireRepository
    {
        // Apenas a "promessa" da função
        Task<Questionnaire?> GetStepByIdAsync(int id);

        // Apenas a "promessa" da função
        Task<List<int>> GetStepsOrderAsync();
    }
}