namespace TrueSnow.Services.Data
{
    using System.Linq;

    using TrueSnow.Data.Common;
    using TrueSnow.Data.Models;
    using TrueSnow.Services.Data.Contracts;
    using Web.Contracts;

    public class EventsService : IEventsService
    {
        private readonly IDbRepository<Event> events;
        private readonly IIdentifierProvider identifierProvider;

        public EventsService(IDbRepository<Event> events, IIdentifierProvider identifierProvider)
        {
            this.events = events;
            this.identifierProvider = identifierProvider;
        }

        public void Add(Event eventToAdd)
        {
            this.events.Add(eventToAdd);
            this.events.Save();
        }

        public IQueryable<Event> GetAll()
        {
            return this.events
                .All()
                .OrderByDescending(p => p.CreatedOn);
        }

        public Event GetById(string id)
        {
            var intId = this.identifierProvider.DecodeId(id);
            return this.events.GetById(intId);
        }

        public void Save()
        {
            this.events.Save();
        }

        public void Delete(int id)
        {
            var eventToDelete = this.events.All().First(x => x.Id == id);
            this.events.Delete(eventToDelete);
            this.Save();
        }
    }
}
