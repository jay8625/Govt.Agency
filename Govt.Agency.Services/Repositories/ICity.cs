using Govt.Agency.DAL.Model;
using System.Collections.Generic;
using System.Linq;

namespace Govt.Agency.Services.Repositories
{
    public interface ICity
    {
        IEnumerable<City> GetAll();
        City GetById(int Id);
        void Add(City city);
        void Update(City city);
        void Delete(int Id);
        bool Any(int Id);
    }
    public class CityRepo : ICity
    {
        private readonly Govt_AgencyContext _context;

        public CityRepo(Govt_AgencyContext context)
        {
            _context = context;
        }

        public void Add(City city)
        {
            _context.Citys.Add(city);
            _context.SaveChanges();
        }

        public bool Any(int Id)
        {
            if (_context.Citys.Any(e => e.Id == Id))
            {
                return true;
            }
            return false;
        }

        public void Delete(int Id)
        {
            City Remove = _context.Citys.Find(Id);
            _context.Citys.Remove(Remove);
            _context.SaveChanges();
        }

        public IEnumerable<City> GetAll()
        {
            return _context.Citys.ToList();
        }

        public City GetById(int Id)
        {
            return _context.Citys.FirstOrDefault(x => x.Id == Id);
        }

        public void Update(City city)
        {
            _context.Entry(city).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
