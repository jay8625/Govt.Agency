using Govt.Agency.DAL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Govt.Agency.Services.Repositories
{
    //Interface
    public interface IAngencyInfo
    {
        IEnumerable<AgencyInfo> GetAll();
        IEnumerable<vwCreateView> GetAllViews();
        AgencyInfo GetById(int Id);
        void Add(AgencyInfo agencyInfo);
        void Update(AgencyInfo agencyInfo);
        void Delete(int Id);
        bool Any(int Id);
        List<vwCreateView> SortByName();
        List<vwCreateView> SortByPhone();
        List<vwCreateView> SortByEmail();
        List<vwCreateView> SortByDate();
    }

    //Implimentation
    public class AgencyInfoRepo : IAngencyInfo 
    {
        //injected Dbcontext
        private readonly Govt_AgencyContext _context;

        public AgencyInfoRepo(Govt_AgencyContext context)
        {
            _context = context;
        }

        //Get Agencies List
        public IEnumerable<AgencyInfo> GetAll()
        {
            return _context.AgencyInfo.ToList();
        }

        //Add Agency
        public void Add(AgencyInfo agencyInfo)
        {
            agencyInfo.DateTime = DateTime.Now;
            _context.Add(agencyInfo);
            _context.SaveChanges();
        }

        //Any Condition
        public bool Any(int Id)
        {
            if (_context.AgencyInfo.Any(e => e.Id == Id))
            {
                return true;
            }
            return false;
        }

        //Removes Agency
        public void Delete(int Id)
        {
            AgencyInfo Remove = _context.AgencyInfo.Find(Id);
            _context.AgencyInfo.Remove(Remove);
            _context.SaveChanges();
        }

        //Update Changes in agencies
        public void Update(AgencyInfo agencyInfo)
        {
            _context.Entry(agencyInfo).State = EntityState.Modified;
            _context.SaveChanges();
        }

        //Gets Agency by Id
        public AgencyInfo GetById(int Id)
        {
            return _context.AgencyInfo.FirstOrDefault(x => x.Id == Id);
        }

        //Adding parameters to ViewModel
        public IEnumerable<vwCreateView> GetAllViews()
        {
            return _context.AgencyInfo.Select(x => new vwCreateView()
            {
                Id = x.Id,
                Name = x.Name,
                Phone = x.PhoneNumber,
                Email = x.Email,
                Address = x.Address,
                UpdatedDate = x.DateTime
            });
        }

        //Sorts by Name
        public List<vwCreateView> SortByName()
        {
            return _context.AgencyInfo.Select(x => new vwCreateView()
            {
                Id = x.Id,
                Name = x.Name,
                Phone = x.PhoneNumber,
                Email = x.Email,
                Address = x.Address,
                UpdatedDate = x.DateTime
            }).OrderBy(x => x.Name).ToList();
        }

        //Sorts by Phoneno.
        public List<vwCreateView> SortByPhone()
        {
            return _context.AgencyInfo.Select(x => new vwCreateView()
            {
                Id = x.Id,
                Name = x.Name,
                Phone = x.PhoneNumber,
                Email = x.Email,
                Address = x.Address,
                UpdatedDate = x.DateTime
            }).OrderBy(x => x.Phone).ToList();
        }

        //Sorts by Email
        public List<vwCreateView> SortByEmail()
        {
            return _context.AgencyInfo.Select(x => new vwCreateView()
            {
                Id = x.Id,
                Name = x.Name,
                Phone = x.PhoneNumber,
                Email = x.Email,
                Address = x.Address,
                UpdatedDate = x.DateTime
            }).OrderBy(x => x.Email).ToList();
        }

        //Sorts by Date
        public List<vwCreateView> SortByDate()
        {
            return _context.AgencyInfo.Select(x => new vwCreateView()
            {
                Id = x.Id,
                Name = x.Name,
                Phone = x.PhoneNumber,
                Email = x.Email,
                Address = x.Address,
                UpdatedDate = x.DateTime
            }).OrderBy(x => x.UpdatedDate).ToList();
        }
    }
}
