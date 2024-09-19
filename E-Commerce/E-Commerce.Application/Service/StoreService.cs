using E_Commerce.Application.DTO;
using E_Commerce.Application.IService;
using E_Commerce.Domain.Models;
using E_Commerce.Infrastrcture.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Service
{
    public class StoreService: IStoreService
    {
        private readonly ApplicationDbContext _context;

        public StoreService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddStore(StoreDto storeDto)
        {

            var store = new Store
            {
                Name = storeDto.Name,
                OwnerId = storeDto.OwnerId

            };
            _context.Stores.Add(store);
            _context.SaveChanges();
        }

        public void RemoveStore(int storeId)
        {
            var store = _context.Stores.Find(storeId);
            if (store == null)
            {
                throw new KeyNotFoundException($"Store with Id {storeId} does not exist.");
            }
  
                _context.Stores.Remove(store);
                _context.SaveChanges();
            
        }

        public Store GetStoreById(int storeId)
        {
            return _context.Stores
                .Include(s => s.Products)
                .FirstOrDefault(s => s.Id == storeId);
        }
    }
}
