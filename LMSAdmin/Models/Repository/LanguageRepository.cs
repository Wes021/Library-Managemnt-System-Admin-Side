using LMSAdmin.Models.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace LMSAdmin.Models.Repository
{
    public class LanguageRepository:ILanguageRepository
    {
        private readonly LMSV2Context _lMSV2Context;

        public LanguageRepository(LMSV2Context lMSV2Context)
        {
            _lMSV2Context = lMSV2Context;
        }

        public async Task<int> DeleteLanguage(int id)
        {
            var anyBooks = _lMSV2Context.Books.Any(b => b.Language == id);

            if (anyBooks)
            {
                throw new Exception("There are books in this language. Delete the books first or change their language.");
            }

            var languageToDelete = await _lMSV2Context.Languages.FirstOrDefaultAsync(l => l.LanguageId == id);

            if (languageToDelete != null)
            {
                _lMSV2Context.Languages.Remove(languageToDelete);
                return await _lMSV2Context.SaveChangesAsync();
            }

            throw new Exception("Language not found");
        }


        public async Task<Language?> GetLanguageByIdAsync(int id)
        {
            return await _lMSV2Context.Languages.FirstOrDefaultAsync(l => l.LanguageId == id);
        }

        public async Task<int> UpdateLanguage(Language language)
        {
            var languageToUpdate = await _lMSV2Context.Languages.FirstOrDefaultAsync(l => l.LanguageId == language.LanguageId);

            if (!(language == null))
            {
                languageToUpdate.LanguageN = language.LanguageN;

                _lMSV2Context.Languages.Update(languageToUpdate);

                return await _lMSV2Context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException("The language to update cannot be found.");
            }
        }

        public async Task<int> AddLanguageAsync(Language language)
        {
            bool checkLanguage = await _lMSV2Context.Languages.AnyAsync(l=>l.LanguageN==language.LanguageN);

            if (checkLanguage)
            {
                throw new Exception("Language already exists");
            }

            _lMSV2Context.Languages.Add(language);
            return await _lMSV2Context.SaveChangesAsync(); 
        }

        

        public async Task<IEnumerable<Language>> GetLanguagesAsync()
        {
            return await _lMSV2Context.Languages.OrderBy(l=>l.LanguageId).ToListAsync();
        }
    }
}
