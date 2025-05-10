namespace LMSAdmin.Models.IRepositories
{
    public interface ILanguageRepository
    {
        Task<IEnumerable<Language>> GetLanguagesAsync();


        Task<int> AddLanguageAsync(Language language);


        Task<int> UpdateLanguage(Language language);

        Task<Language?> GetLanguageByIdAsync(int id);

        Task<int> DeleteLanguage(int id);
    }
}
