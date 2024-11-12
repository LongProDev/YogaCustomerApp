using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Text.Json;
using YogaApp.Models;

namespace YogaApp.Services
{
    public class ApiService
    {
        private readonly IYogaApiService _yogaApiService;

        public ApiService()
        {
            _yogaApiService = RestService.For<IYogaApiService>("https://yogaclassmanagement.onrender.com");
        }

        public Task<List<YogaClass>> GetClassesAsync() => _yogaApiService.GetYogaClasses();
        public Task<List<YogaClass>> SearchClassesAsync(string dayOfWeek, string time) =>
            _yogaApiService.SearchYogaClasses(dayOfWeek, time);
    }

}
