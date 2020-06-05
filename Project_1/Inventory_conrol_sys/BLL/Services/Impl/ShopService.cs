using System;
using System.Collections.Generic;
using System.Text;
using BLL.Services.Interfaces;
using BLL.DTO;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using DAL.Unit_of_work;
using CCL.Security;
using CCL.Security.Identity;
using AutoMapper;

namespace BLL.Services.Impl
{
    public class ShopService
        : IShopService
    {
        private readonly IUnitOfWork _database;
        private int pageSize = 10;

        public ShopService(
            IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException(
                    nameof(unitOfWork));
            }
            _database = unitOfWork;
        }

        /// <exception cref="MethodAccessException"></exception>
        public IEnumerable<ShopDTO> GetShops(int pageNumber)
        {
            var user = SecurityContext.GetUser();
            var userType = user.GetType();
            if (userType != typeof(Director)
                && userType != typeof(Accountant))
            {
                throw new MethodAccessException();
            }
            var systeamId = user.SysteamID;
            var shopsEntities =
                _database
                    .Shops
                    .Find(z => z.SYSTEAMID == systeamId, pageNumber, pageSize);
            var mapper =
                new MapperConfiguration(
                    cfg => cfg.CreateMap<Shop, ShopDTO>()
                    ).CreateMapper();
            var shopsDto =
                mapper
                    .Map<IEnumerable<Shop>, List<ShopDTO>>(
                        shopsEntities);
            return shopsDto;
        }

        public void AddShop(ShopDTO shop)
        {
            var user = SecurityContext.GetUser();
            var userType = user.GetType();
            if (userType != typeof(Director)
                || userType != typeof(Accountant))
            {
                throw new MethodAccessException();
            }
            if (shop == null)
            {
                throw new ArgumentNullException(nameof(shop));
            }

            validate(shop);

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ShopDTO, Shop>()).CreateMapper();
            var shopEntity = mapper.Map<ShopDTO, Shop>(shop);
            _database.Shops.Create(shopEntity);
        }

        private void validate(ShopDTO shop)
        {
            if (string.IsNullOrEmpty(shop.Address))
            {
                throw new ArgumentException("Address повинне містити значення!");
            }
        }
    }
}
