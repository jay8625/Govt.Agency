using Govt.Agency.DAL.Model;
using System.Collections.Generic;
using System.Linq;

namespace Govt.Agency.Services.Repositories
{
    public interface IState
    {
        IEnumerable<State> GetAll();
        State GetById(int Id);
        void Add(State state);
        void Update(State state);
        void Delete(int Id);
        bool Any(int Id);
    }
    public class StateRepo : IState
    {
        private readonly Govt_AgencyContext _context;

        public StateRepo(Govt_AgencyContext context)
        {
            _context = context;
        }

        public void Add(State state)
        {
            _context.States.Add(state);
            _context.SaveChanges();
        }

        public bool Any(int Id)
        {
            if (_context.States.Any(e => e.Id == Id))
            {
                return true;
            }
            return false;
        }

        public void Delete(int Id)
        {
            State Remove = _context.States.Find(Id);
            _context.States.Remove(Remove);
            _context.SaveChanges();
        }

        public IEnumerable<State> GetAll()
        {
            return _context.States.ToList();
        }

        public State GetById(int Id)
        {
            return _context.States.FirstOrDefault(x => x.Id == Id);
        }

        public void Update(State state)
        {
            _context.Entry(state).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
