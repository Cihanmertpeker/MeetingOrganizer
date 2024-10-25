using MeetingOrganizer.DtoLayer.MeetingDtos;
using MeetingOrganizer.DtoLayer.ParticipantDtos;
using MeetingOrganizer.EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

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

		[HttpGet]
		public async Task<IActionResult> DeleteMeeting(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"https://localhost:7298/api/Meetings/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> CreateMeeting()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7298/api/Participants");
			var jsonData = await responseMessage.Content.ReadAsStringAsync();
			var values = JsonConvert.DeserializeObject<List<ResultParticipantDto>>(jsonData);
            List<SelectListItem> values2 = (from x in values 
                                                 select new SelectListItem
                                                 {
                                                     Text = x.Name + " " + x.Surname,
                                                     Value = x.ParticipantId.ToString()
                                                 }).ToList();

            ViewBag.Participants = values2;

            return View();
		}
      

        [HttpPost]
		public async Task<IActionResult> CreateMeeting(CreateMeetingDto createMeetingDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createMeetingDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7298/api/Meetings", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
                var responseMessage2 = await client.GetAsync("https://localhost:7298/api/Meetings/");
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultMeetingDto>>(jsonData2);
                var meetingId = values.Count();               
				return RedirectToAction("Index");
			}
			return View();

           
		}

        [HttpGet]
        public async Task<IActionResult> UpdateMeeting(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7298/api/Meetings/{id}");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<UpdateMeetingDto>(jsonData);
            var participantlist = new List<ResultParticipantDto>();
            foreach (var item in values.ParticipantIds)
            {
                var responseMessage1 = await client.GetAsync($"https://localhost:7298/api/Participants/{item}");
                var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
                var values1 = JsonConvert.DeserializeObject<ResultParticipantDto>(jsonData1);
                participantlist.Add(values1);                
            }

            List<SelectListItem> values2 = (from x in participantlist
                                            select new SelectListItem
                                            {
                                                Text = x.Name + " " + x.Surname,
                                                Value = x.ParticipantId.ToString()
                                            }).ToList();



            var responseMessage3 = await client.GetAsync("https://localhost:7298/api/Participants");
            var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
            var values3 = JsonConvert.DeserializeObject<List<ResultParticipantDto>>(jsonData3);
            List<SelectListItem> values4 = (from x in values3
                                            select new SelectListItem
                                            {
                                                Text = x.Name + " " + x.Surname,
                                                Value = x.ParticipantId.ToString()
                                            }).ToList();
            ViewBag.Participants = values4;

            return View(values);
        }




        [HttpPost]
        public async Task<IActionResult> UpdateMeeting(UpdateMeetingDto updateMeetingDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateMeetingDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7298/api/Meetings", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {            
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
