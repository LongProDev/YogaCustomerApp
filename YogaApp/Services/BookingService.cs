using System;
using System.Net.Http;              
using System.Net.Http.Json;        
using System.Threading.Tasks;       
using System.Text.Json;
using YogaApp.Models;
using YogaApp.ViewModels;
using YogaApp.Services;
using YogaApp.Views;



namespace YogaApp.Services
{
    public class BookingService
    {
        private readonly HttpClient _client;
        private readonly string _baseUrl = "https://yogaclassmanagement.onrender.com";

        public BookingService(HttpClient client)
        {
            _client = client;
        }

        public async Task<Booking> CreateBooking(int classInstanceId, string userId)
        {
            var booking = new Booking
            {
                ClassInstanceId = classInstanceId,
                UserId = userId,
                BookingDate = DateTime.UtcNow,
                Status = "Confirmed"
            };

            var response = await _client.PostAsJsonAsync($"{_baseUrl}/api/bookings", booking);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Booking>();
            }
            throw new Exception("Failed to create booking");
        }

        public async Task<ClassDetails> GetClassDetails(int classInstanceId)
        {
            var response = await _client.GetAsync($"{_baseUrl}/api/classes/{classInstanceId}/details");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<ClassDetails>();
            }
            throw new Exception("Failed to fetch class details");
        }

        public async Task CancelBooking(int bookingId)
        {
            var response = await _client.DeleteAsync($"{_baseUrl}/api/bookings/{bookingId}");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Failed to cancel booking");
            }
        }
    }
}
