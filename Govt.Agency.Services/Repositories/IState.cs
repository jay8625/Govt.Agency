using Govt.Agency.DAL.Model;
using Govt.Agency.Services.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace Govt.Agency.Services.Repositories
{
    //Interface
    public interface IState
    {
        IEnumerable<State> GetAll();
        IEnumerable<vmState> vmGetAll();
        State GetById(int Id);
        void Add(State state);
        void Update(State state);
        void Delete(int Id);
        bool Any(int Id);
    }

    //Implimentation
    public class StateRepo : IState
    {
        //Injected Dbcontext
        private readonly Govt_AgencyContext _context;

        public StateRepo(Govt_AgencyContext context)
        {
            _context = context;
        }

        //Adds State
        public void Add(State state)
        {
            _context.States.Add(state);
            _context.SaveChanges();
        }

        //Any State Condition
        public bool Any(int Id)
        {
            if (_context.States.Any(e => e.Id == Id))
            {
                return true;
            }
            return false;
        }

        //Removes State
        public void Delete(int Id)
        {
            State Remove = _context.States.Find(Id);
            _context.States.Remove(Remove);
            _context.SaveChanges();
        }

        //Gets List of States
        public IEnumerable<State> GetAll()
        {
            return _context.States.ToList();
        }

        //Gets State by Id
        public State GetById(int Id)
        {
            return _context.States.FirstOrDefault(x => x.Id == Id);
        }

        //Update State Changes
        public void Update(State state)
        {
            _context.Entry(state).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }

        public IEnumerable<vmState> vmGetAll()
        {
            return _context.States.Select(x => new vmState
            {
                Id = x.Id,
                Name= x.Name,
                CountryName=_context.Countries.Where(s=>s.Id==x.CountryId).Select(z=>z.Name).FirstOrDefault()
            });
        }
    }
}
