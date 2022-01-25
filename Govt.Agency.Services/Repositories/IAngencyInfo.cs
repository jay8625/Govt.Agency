using Govt.Agency.DAL.Model;
using System.Collections.Generic;
using System.Linq;

namespace Govt.Agency.Services.Repositories
{
    public interface IAngencyInfo
    {
        IEnumerable<AgencyInfo> GetAll();
        IEnumerable<vwCreateView> GetAllViews();
        AgencyInfo GetById(int Id);
        void Add(AgencyInfo agencyInfo);
        void Update(AgencyInfo agencyInfo);
        void Delete(int Id);
        bool Any(int Id);
    }
    public class AgencyInfoRepo : IAngencyInfo
    {
        private readonly Govt_AgencyContext _context;

        public AgencyInfoRepo(Govt_AgencyContext context)
        {
            _context = context;
        }

        public IEnumerable<AgencyInfo> GetAll()
        {
            return _context.AgencyInfo.ToList();
        }
        public void Add(AgencyInfo agencyInfo)
        {
            _context.Add(agencyInfo);
            _context.SaveChanges();
        }

        public bool Any(int Id)
        {
            if (_context.AgencyInfo.Any(e => e.Id == Id))
            {
                return true;
            }
            return false;
        }

        public void Delete(int Id)
        {
            AgencyInfo Remove = _context.AgencyInfo.Find(Id);
            _context.AgencyInfo.Remove(Remove);
            _context.SaveChanges();
        }

        public void Update(AgencyInfo agencyInfo)
        {
            _context.Entry(agencyInfo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }

        public AgencyInfo GetById(int Id)
        {
            return _context.AgencyInfo.FirstOrDefault(x => x.Id == Id);
        }

        public IEnumerable<vwCreateView> GetAllViews()
        {
            return _context.AgencyInfo.Select(x => new vwCreateView()
            {
                Id = x.Id,
                Name = x.Name,
                phone = x.PhoneNumber,
                Email = x.Email,
                Address = x.Address,
                UpdatedDate = x.DateTime
            });
        }
    }
}
