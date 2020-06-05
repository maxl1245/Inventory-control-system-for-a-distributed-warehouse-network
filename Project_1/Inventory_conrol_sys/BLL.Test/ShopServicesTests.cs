using System;
using System.Collections.Generic;
using System.Text;
using BLL.Services.Impl;
using BLL.Services.Interfaces;
using DAL.EF;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using DAL.Unit_of_work;
using Microsoft.EntityFrameworkCore;
using Moq;
using CCL.Security;
using CCL.Security.Identity;
using Xunit;
using System.Linq;


namespace BLL.Test
{
   public class ShopServicesTests
    {
        [Fact]
        public void Ctor_InputNull_ThrowArgumentNullException()
        {
            // Arrange
            IUnitOfWork nullUnitOfWork = null;

            // Act
            // Assert
            Assert.Throws<ArgumentNullException>(() => new ShopService(nullUnitOfWork));
        }

        [Fact]
        public void GetShops_UserIsAdmin_ThrowMethodAccessException()
        {
            // Arrange
            User user = new Admin(1, "test", 1);
            SecurityContext.SetUser(user);
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            IShopService shopService = new ShopService(mockUnitOfWork.Object);

            // Act
            // Assert
            Assert.Throws<MethodAccessException>(() => shopService.GetShops(0));
        }

        [Fact]
        public void GetShops_StreetFromDAL_CorrectMappingToStreetDTO()
        {
            // Arrange
            User user = new Director(1, "test", 1);
            SecurityContext.SetUser(user);
            var shopService = GetShopService();

            // Act
            var actualShopDto = shopService.GetShops(0).First();

            // Assert
            Assert.True(
                actualShopDto.ShopId == 1
                && actualShopDto.Address == "testN"
                && actualShopDto.item_name == "testD"
                );
        }

        IShopService GetShopService()
        {
            var mockContext = new Mock<IUnitOfWork>();
            var expectedShop = new Shop() { shop_id = 1, shop_address = "testN", item_name = "testD", SYSTEAMID = 2 };
            var mockDbSet = new Mock<IShopRepository>();
            mockDbSet.Setup(z =>
                z.Find(
                    It.IsAny<Func<Shop, bool>>(),
                    It.IsAny<int>(),
                    It.IsAny<int>()))
                  .Returns(
                    new List<Shop>() { expectedShop }
                    );
            mockContext
                .Setup(context =>
                    context.Shops)
                .Returns(mockDbSet.Object);

            IShopService shopService = new ShopService(mockContext.Object);

            return shopService;
        }
    }
}
