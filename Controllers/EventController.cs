using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Activities.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Activities.Controllers
{
    
    public class EventController : Controller
    {

        //==================================================================================
        // DB Connection settings. 
        //==================================================================================
        
        private EventContext _context; 

        public EventController(EventContext context)
        {
            _context = context;
        }

        //==================================================================================
        // Root Route. Checks for session data and goes to Dashboard if found.
        //==================================================================================

        [HttpGet]
        [Route("main")]
        public IActionResult Main()
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            
            if (UserId == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                string CurrUserAlias = HttpContext.Session.GetString("UserAlias");
                ViewBag.CurrUserAlias = CurrUserAlias;

                List<Event> AllEvents = _context.Events
                    .ToList();
                ViewBag.AllEvents = AllEvents;
                return View();
            }
        }
        
        //==================================================================================
        // New Event Route.
        //==================================================================================

        [HttpGet]
        [Route("NewEvent")]
        public IActionResult NewEvent()
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            if (UserId == null)
            {
                return RedirectToAction("Index", "Login");            
            } else {
                return View("NewEvent");
            }
        }

        //==================================================================================
        // Create Event Route.
        //==================================================================================

        [HttpPost]
        [Route("CreateEvent")]
        public IActionResult CreateEvent(NewEventViewModel model)
        {     
            if(ModelState.IsValid)
            {
                Event NewEvent = new Event
                    {
                        Title = model.Title,
                        EventDate = model.EventDate,
                        EventTime = model.EventTime,
                        Duration = model.Duration,
                        DurationType = model.DurationType,
                        Description = model.Description,
                        CreatedById = (int)HttpContext.Session.GetInt32("UserId"),
                        CreatedByFirstName = (string)HttpContext.Session.GetString("UserAlias"),
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                    };
                _context.Add(NewEvent);
                _context.SaveChanges();
                return RedirectToAction("Main", "Event");
            } else {
                return View("NewEvent");
            }
        }

        //==================================================================================
        // View Event Route.
        //==================================================================================
        [HttpGet]
        [Route("ViewEvent/{EventId}")]
        public IActionResult ViewEvent(string EventId)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            if (UserId == null)
            {
                return RedirectToAction("Index", "Login");            
            } else {

                Event GetEvent = _context.Events.SingleOrDefault(Event => Event.EventId.ToString() == EventId);





                ViewBag.CurrentEvent = GetEvent;
                return View("ViewEvent");
            }
            
        }


    }
}