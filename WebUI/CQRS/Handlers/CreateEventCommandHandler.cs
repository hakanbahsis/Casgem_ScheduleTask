using WebUI.CQRS.Commands;
using WebUI.DAL;

namespace WebUI.CQRS.Handlers
{
    public class CreateEventCommandHandler
    {
        private readonly Context _context;

        public CreateEventCommandHandler(Context context)
        {
            _context = context;
        }

        public void Handle(CreateEventCommand command)
        {
            if (command.EventID > 0)
            {
                var v = _context.Events.Where(a => a.EventID == command.EventID).FirstOrDefault();
                if (v != null)
                {
                    v.Subject = command.Subject;
                    v.Start = command.Start;
                    v.End = command.End;
                    v.Description = command.Description;
                    v.IsFullDay = command.IsFullDay;
                    v.ThemeColor = command.ThemeColor;
                }
            }
            else
            {
                _context.Events.Add(new Event
                {
                    Subject = command.Subject,
                    Start = command.Start,
                    End = command.End,
                    Description = command.Description,
                    IsFullDay = command.IsFullDay,
                    ThemeColor = command.ThemeColor,
                });

            }
            _context.SaveChanges();
        }
    }
}
