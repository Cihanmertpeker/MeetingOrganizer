using MeetingOrganizer.DtoLayer.MeetingDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MeetingOrganizerWebUI.Controllers
{
    public class MeetingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MeetingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7298/api/Meetings/");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultMeetingDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
