using API.core.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.core;

namespace Api.Services.Interface
{
    public interface IMasterService
    {
        IEnumerable<MaterialMaster> GetAllMaterialDescp();
        void CreateMaterial(MaterialMaster material);
        void DeleteMaterial(int id);

        IEnumerable<PurchaseType> GetAllPurchaseTypes();
        
    }
}
