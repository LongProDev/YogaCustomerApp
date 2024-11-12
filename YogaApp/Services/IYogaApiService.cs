using Refit;
using YogaApp.Models;

namespace YogaApp.Services
{
    public interface IYogaApiService
    {
        [Get("/api/yoga-Classes")]
        Task<List<YogaClass>> GetYogaClasses();

        [Get("/api/yoga-Classes/{id}")]
        Task<YogaClass> GetYogaClass(int id);

        [Get("/api/yoga-Classes/{id}/details")]
        Task<ClassDetails> GetClassDetails(int id);

        [Get("/api/yoga-Classes/search")]
        Task<List<YogaClass>> SearchYogaClasses([AliasAs("dayOfWeek")] string dayOfWeek, [AliasAs("time")] string time);

        [Post("/api/bookings")]
        Task<Booking> CreateBooking([Body] Booking booking);
    }
}
