using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce.Application.DTO;
using E_Commerce.Domain.Models;

namespace E_Commerce.Application.IService
{
    public interface IStoreService
    {
        void AddStore(StoreDto storeDto);
        void RemoveStore(int storeId);
        Store GetStoreById(int storeId);
    }
}
