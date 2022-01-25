using Govt.Agency.DAL.Model;
using System.Collections.Generic;
using System.Linq;

namespace Govt.Agency.Services.Repositories
{
    public interface IAgencyType
    {
        IEnumerable<AgencyType> GetAll();
        AgencyType GetById(int Id);
        void Add(AgencyType agencyType);
        void Remove(int Id);
    }
    public class AgencyTypeRepo : IAgencyType
    {
        private readonly Govt_AgencyContext _context;

        public AgencyTypeRepo(Govt_AgencyContext context)
        {
            _context = context;
        }

        public void Add(AgencyType agencyType)
        {
            _context.AgencyTypes.Add(agencyType);
            _context.SaveChanges();
        }

        public IEnumerable<AgencyType> GetAll()
        {
            return _context.AgencyTypes.ToList();
        }

        public AgencyType GetById(int Id)
        {
           return _context.AgencyTypes.FirstOrDefault(x => x.Id == Id);
        }

        public void Remove(int Id)
        {
            AgencyType Remove = _context.AgencyTypes.Find(Id);
            _context.AgencyTypes.Remove(Remove);
            _context.SaveChanges();
        }
    }
}
