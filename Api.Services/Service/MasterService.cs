using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.Services.Interface;
using API.core.DbModels;
using API.core;

namespace Api.Services.Service
{
    public class MasterService : IMasterService
    {
        private readonly Db1Context _context;

        public MasterService(Db1Context context)
        {
            _context = context;
        }

        public IEnumerable<MaterialMaster> GetAllMaterialDescp()
        {
            return _context.MaterialMasters.ToList();
        }

        public void CreateMaterial(MaterialMaster material)
        {
            _context.MaterialMasters.Add(material);
            _context.SaveChanges();
        }

        public void DeleteMaterial(int id)
        {
            var material = _context.MaterialMasters.Find(id);
            if (material != null)
            {
                _context.MaterialMasters.Remove(material);
                _context.SaveChanges();
            }
        }

        public IEnumerable<PurchaseType> GetAllPurchaseTypes()
        {
            return _context.PurchaseTypes.ToList();
        }

       
    }
}
