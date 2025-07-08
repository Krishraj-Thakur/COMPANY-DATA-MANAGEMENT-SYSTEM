using Api.Services.Interface;
using API.core.DTO_s;
using API.core.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using API.core;


namespace Api.Services.Service
{
    public class PRService : IPRService
    {
        private readonly Db1Context _context;

        public PRService(Db1Context context)
        {
            _context = context;
        }

        public IEnumerable<PurchaseRequest> GetAll()
        {
            return _context.PurchaseRequests
                .Include(itm=>itm.PritemDetails)
                .ToList();
        }

        public void Create(PurchaseRequest entity)
        {
            //debugger line below
            _context.PurchaseRequests.Add(entity);
            _context.SaveChanges();
            //var pritems=entity.PritemDetails.ToList();
           //foreach(var itm in pritems)
           // {
           //     //itm.PrId = entity.Id;
           //     var prItemdetails = new PritemDetail
           //     {
           //         PrId = entity.Id,
           //         AvailableQuantity = itm.AvailableQuantity,
           //         DeliveryDate = itm.DeliveryDate,
           //         CurrentStatus = itm.CurrentStatus,
           //         MatId = itm.MatId

           //     };
           //     _context.PritemDetails.AddRange(prItemdetails);
                
           // }
           // _context.SaveChanges();

        }
        public void Delete(int id)
        {
            var entity = _context.PurchaseRequests.Find(id);
            if (entity != null)
            {
                _context.PurchaseRequests.Remove(entity);
                _context.SaveChanges();
            }
        }

        public IEnumerable<PritemDetail> GetAllTr()
        {
            return _context.PritemDetails.ToList();
        }

        public void CreateTransaction(PritemDetail tr)
        {
            _context.PritemDetails.Add(tr);
            _context.SaveChanges();
        }

        public void DeleteTransaction(int id)
        {
            var entity = _context.PritemDetails.Find(id);
            if (entity != null)
            {
                _context.PritemDetails.Remove(entity);
                _context.SaveChanges();
            }
        }
    }
}