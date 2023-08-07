using WebUI.DAL;

namespace WebUI.CQRS.Handlers
{
    public class RemoveEventCommandHandler
    {
        private readonly Context _context;

        public RemoveEventCommandHandler(Context context)
        {
            _context = context;
        }

        public void Handle(int id)
        {
            var values = _context.Events.Find(id);
            _context.Events.Remove(values);
            _context.SaveChanges();
        }
    }
}
