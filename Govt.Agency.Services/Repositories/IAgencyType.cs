using Govt.Agency.DAL.Model;
using System.Collections.Generic;
using System.Linq;

namespace Govt.Agency.Services.Repositories
{
    //Interface
    public interface IAgencyType
    {
        IEnumerable<AgencyType> GetAll();
        AgencyType GetById(int Id);
        void Add(AgencyType agencyType);
        void Remove(int Id);
        bool Any(int Id);
    }

    //Implimentation
    public class AgencyTypeRepo : IAgencyType
    {
        //Injected DbContext
        private readonly Govt_AgencyContext _context;

        public AgencyTypeRepo(Govt_AgencyContext context)
        {
            _context = context;
        }

        //Adds Agency Type
        public void Add(AgencyType agencyType)
        {
            _context.AgencyTypes.Add(agencyType);
            _context.SaveChanges();
        }

        //any Condition
        public bool Any(int Id)
        {
            if (_context.AgencyTypes.Any(e => e.Id == Id))
            {
                return true;
            }
            return false;
        }

        //Gets List Of Agency Types
        public IEnumerable<AgencyType> GetAll()
        {
            return _context.AgencyTypes.ToList();
        }

        //Get Type by Id
        public AgencyType GetById(int Id)
        {
           return _context.AgencyTypes.FirstOrDefault(x => x.Id == Id);
        }

        //Removes Agency Type
        public void Remove(int Id)
        {
            AgencyType Remove = _context.AgencyTypes.Find(Id);
            _context.AgencyTypes.Remove(Remove);
            _context.SaveChanges();
        }
    }
}
