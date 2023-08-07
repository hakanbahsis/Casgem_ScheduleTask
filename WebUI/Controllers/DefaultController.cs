using Microsoft.AspNetCore.Mvc;
using WebUI.CQRS.Commands;
using WebUI.CQRS.Handlers;

namespace WebUI.Controllers
{
    public class DefaultController : Controller
    {
        private readonly GetEventQueryHandler _getEventHandler;
        private readonly CreateEventCommandHandler _createEventHandler;
        private readonly RemoveEventCommandHandler _removeEventHandler;
        public DefaultController(GetEventQueryHandler getEventHandler, CreateEventCommandHandler createEventHandler, RemoveEventCommandHandler removeEventHandler)
        {
            _getEventHandler = getEventHandler;
            _createEventHandler = createEventHandler;
            _removeEventHandler = removeEventHandler;
        }


        public IActionResult Index()
        {
            return View();
        }

        public JsonResult GetEvents()
        {
            var values = _getEventHandler.Handle();
            return new JsonResult(values);
        }

        [HttpPost]
        public JsonResult DeleteEvents(int eventId)
        {
            _removeEventHandler.Handle(eventId);
            return new JsonResult(true);
        }

        [HttpPost]
        public JsonResult SaveEvent(CreateEventCommand command)
        {
            var status = true;
            _createEventHandler.Handle(command);
            return new JsonResult(status);
        }
       
    }
}
