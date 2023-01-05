using BethanyPieShopHRSM.Models;
using BethanysPieShopHRM.Shared.Domain;
using Blazored.LocalStorage;
using System.Text.Json;

namespace BethanyPieShopHRSM.Services
{
    public class EmployeeDataService : IEmployeeDataService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorageService;

        public EmployeeDataService(HttpClient httpClient, ILocalStorageService localStorageService)
        {
            _httpClient = httpClient;
            _localStorageService = localStorageService;
        }
        public Task<Employee> AddEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Task DeleteEmployee(int employeeId)
        {
            throw new NotImplementedException();
        }

        public async Task<Employee> GetAllEmployeeDetails(int employeeId)
        {
            return await JsonSerializer.DeserializeAsync<Employee>(
                await _httpClient.GetStreamAsync($"api/employee/{employeeId}"),
                    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }
            );
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees(bool refreshRequired = false)
        {
            if (!refreshRequired)
            {
                bool employeeExpirationExists = await _localStorageService
                    .ContainKeyAsync(LocalStorageConstants.EmployeesListExpirationKey);

                if (employeeExpirationExists)
                {
                    var employeeListExpiration = await _localStorageService
                        .GetItemAsync<DateTime>(LocalStorageConstants.EmployeesListExpirationKey);

                    if (employeeListExpiration > DateTime.Now)
                    {
                        if (await _localStorageService.ContainKeyAsync(LocalStorageConstants.EmployeeListKey))
                        {
                            return await _localStorageService.GetItemAsync<List<Employee>>(LocalStorageConstants.EmployeeListKey);
                        }
                    }
                }
            }

            var list = await JsonSerializer.DeserializeAsync<IEnumerable<Employee>>(
                await _httpClient.GetStreamAsync($"api/employee"),
                    new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }
            );

            await _localStorageService.SetItemAsync(LocalStorageConstants.EmployeeListKey, list);
            await _localStorageService.SetItemAsync(LocalStorageConstants.EmployeesListExpirationKey, DateTime.Now.AddMinutes(1));
            return list;
        }

        public Task UpdateEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
