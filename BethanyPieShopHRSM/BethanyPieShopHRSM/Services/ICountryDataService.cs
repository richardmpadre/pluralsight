using BethanysPieShopHRM.Shared.Domain;

namespace BethanyPieShopHRSM.Services
{
    public interface ICountryDataService
    {
        Task<IEnumerable<Country>> GetAllCountries();
        Task<Country> GetCountryById(int countryId);
    }
}
