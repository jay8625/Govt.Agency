using Govt.Agency.DAL.Model;
using Govt.Agency.Services.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Govt.Agency.Services.Repositories
{
    //Interface
    public interface ICity
    {
        IEnumerable<City> GetAll();
        IEnumerable<vmCity> vmGetAll();
        City GetById(int Id);
        void Add(City city);
        void Update(City city);
        void Delete(int Id);
        bool Any(int Id);
    }

    //Implimentation
    public class CityRepo : ICity
    {
        //Injected Dbcontext
        private readonly Govt_AgencyContext _context;

        public CityRepo(Govt_AgencyContext context)
        {
            _context = context;
        }

        //Adds City
        public void Add(City city)
        {
            _context.Citys.Add(city);
            _context.SaveChanges();
        }

        //Any Condition
        public bool Any(int Id)
        {
            if (_context.Citys.Any(e => e.Id == Id))
            {
                return true;
            }
            return false;
        }

        //Removes City
        public void Delete(int Id)
        {
            City Remove = _context.Citys.Find(Id);
            _context.Citys.Remove(Remove);
            _context.SaveChanges();
        }

        //Gets list of Cities
        public IEnumerable<City> GetAll()
        {
            return _context.Citys.ToList();
        }

        //Gets city by Id
        public City GetById(int Id)
        {
            return _context.Citys.FirstOrDefault(x => x.Id == Id);
        }

        //Update Changes in City
        public void Update(City city)
        {
            _context.Entry(city).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public IEnumerable<vmCity> vmGetAll()
        {
            return _context.Citys.Select(x => new vmCity
            {
                Id = x.Id,
                Name = x.Name,
                StateName = _context.States.Where(s=>s.Id==x.StateId).Select(z=>z.Name).FirstOrDefault()
            });
        }
    }
}
