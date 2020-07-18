using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodingEventsDemo.Data;
using CodingEventsDemo.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace coding_events_practice.Controllers
{
    public class EventsController : Controller
    {


        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.events = EventData.GetAll();

            return View();
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("events/add")]
        public IActionResult NewEvent(Event newEvent)
        {
            EventData.Add(newEvent);
            
            return Redirect("/Events/");
        }

        public IActionResult Delete()
        {
            ViewBag.events = EventData.GetAll();
            return View();

        }

        [HttpPost]
        [Route("/events/delete")]
        public IActionResult Delete(int[] eventIds)
        {
            foreach(int id in eventIds)
            {
                EventData.Remove(id);
            }
            return Redirect("/Events/");
        }

        [Route("/Events/Edit/{eventId}")]
        public IActionResult Edit(int eventId)
        {
            ViewBag.evt = EventData.GetById(eventId);
            ViewBag.title = $"Edit Event {ViewBag.evt.Name} Id Number: {ViewBag.evt.Id}";
            return View();
        }

        [HttpPost]
        [Route("/events/edit/")]
        public IActionResult SubmitEditEventForm(int eventId,string name,string description)
        {
            Event evnt = EventData.GetById(eventId);
            evnt.Name = name;
            evnt.Description = description;
            return Redirect("/Events");
        }
    }
}
