using Govt.Agency.DAL.Model;
using System.Collections.Generic;
using System.Linq;

namespace Govt.Agency.Services.Repositories
{
    //Interface
    public interface ICountry
    {
        IEnumerable<Country> GetAll();
        Country GetById(int Id);
        void Add(Country country);
        void Remove(int Id);
        bool Any(int Id);
        void Update(Country country);
    }

    //Implimentation
    public class CountryRepo : ICountry
    {
        //injected DbContext
        private readonly Govt_AgencyContext _context;

        public CountryRepo(Govt_AgencyContext context)
        {
            _context = context;
        }

        //Adds Country
        public void Add(Country country)
        {
            _context.Add(country);
            _context.SaveChanges();
        }

        //Any country condition
        public bool Any(int Id)
        {
            if (_context.Countries.Any(e => e.Id == Id))
            {
                return true;
            }
            return false;
        }

        //Gets all Countries
        public IEnumerable<Country> GetAll()
        {
            return _context.Countries.ToList();
        }

        //Gets country by Id
        public Country GetById(int Id)
        {
            return _context.Countries.FirstOrDefault(x => x.Id == Id);
        }

        //Removes Country 
        public void Remove(int Id)
        {
            Country Remove = _context.Countries.Find(Id);
            _context.Countries.Remove(Remove);
            _context.SaveChanges();
        }

        //Update changes in city
        public void Update(Country country)
        {
            _context.Entry(country).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
