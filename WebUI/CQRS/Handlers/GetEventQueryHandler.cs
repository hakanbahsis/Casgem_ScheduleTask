using WebUI.CQRS.Results;
using WebUI.DAL;

namespace WebUI.CQRS.Handlers
{
    public class GetEventQueryHandler
    {
        private readonly Context _context;

        public GetEventQueryHandler(Context context)
        {
            _context = context;
        }

        public List<GetEventQueryResult> Handle()
        {
            var values = _context.Events.Select(
              x => new GetEventQueryResult
              {
                  EventID = x.EventID,
                  Subject = x.Subject,
                  Description = x.Description,
                  Start=x.Start,
                  End=x.End,
                  IsFullDay=x.IsFullDay,
                  ThemeColor=x.ThemeColor,
              }).ToList();
            return values;
        }
    }
}
