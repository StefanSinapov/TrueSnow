namespace TrueSnow.Services.Data.Contracts
{
    using System.Linq;

    using TrueSnow.Data.Models;

    public interface IEventsService
    {
        IQueryable<Event> GetAll();

        Event GetById(string id);

        void Add(Event eventToAdd);
    }
}
