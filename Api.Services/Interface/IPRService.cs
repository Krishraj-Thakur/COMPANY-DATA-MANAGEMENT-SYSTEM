using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.core.DTO_s;
using API.core.DbModels;
using API.core;

namespace Api.Services.Interface
{
    public interface IPRService
    {
        IEnumerable<PurchaseRequest> GetAll();
        void Create(PurchaseRequest prDto);
        void Delete(int id);

        IEnumerable<PritemDetail> GetAllTr();
        void CreateTransaction(PritemDetail tr);
        void DeleteTransaction(int id);
    }
}
