using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Xunit;
using Microsoft.EntityFrameworkCore;
using Moq;
using DAL.Tests;
using DAL.EF;
using DAL.Entities;
using DAL.Repositories.Impl;
using DAL.Repositories.Interfaces;


namespace DAL.Tests
{
    class TestShopRepository
        : BaseRepository<Shop>
    {
        public TestShopRepository(DbContext context)
            : base(context)
        {
        }
    }
    public class BaseRepositoryUnitTests
    {
        [Fact]
        public void Create_InputShopInstance_CalledAddMethodOfDBSetWithShopInstance()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<SysteamContext>()
                .Options;
            var mockContext = new Mock<SysteamContext>(opt);
            var mockDbSet = new Mock<DbSet<Shop>>();
            mockContext
                .Setup(context =>
                    context.Set<Shop>(
                        ))
                .Returns(mockDbSet.Object);
            //EFUnitOfWork uow = new EFUnitOfWork(mockContext.Object);
            var repository = new TestShopRepository(mockContext.Object);

            Shop expectedShop = new Mock<Shop>().Object;

            //Act
            repository.Create(expectedShop);

            // Assert
            mockDbSet.Verify(
                dbSet => dbSet.Add(
                    expectedShop
                    ), Times.Once());

        }
        [Fact]
        public void Delete_InputId_CalledFindAndRemoveMethodsOfDBSetWithCorrectArg()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<SysteamContext>()
                .Options;
            var mockContext = new Mock<SysteamContext>(opt);
            var mockDbSet = new Mock<DbSet<Shop>>();
            mockContext
                .Setup(context =>
                    context.Set<Shop>(
                        ))
                .Returns(mockDbSet.Object);
            //EFUnitOfWork uow = new EFUnitOfWork(mockContext.Object);
            //IShopRepository repository = uow.Shops;
            var repository = new TestShopRepository(mockContext.Object);

            Shop expectedShop = new Shop() { shop_id = 1 };
            mockDbSet.Setup(mock => mock.Find(expectedShop.shop_id)).Returns(expectedShop);

            //Act
            repository.Delete(expectedShop.shop_id);

            // Assert
            mockDbSet.Verify(
                dbSet => dbSet.Find(
                    expectedShop.shop_id
                    ), Times.Once());
            mockDbSet.Verify(
                dbSet => dbSet.Remove(
                    expectedShop
                    ), Times.Once());
        }
        [Fact]
        public void Get_InputId_CalledFindMethodOfDBSetWithCorrectId()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<SysteamContext>()
                .Options;
            var mockContext = new Mock<SysteamContext>(opt);
            var mockDbSet = new Mock<DbSet<Shop>>();
            mockContext
                .Setup(context =>
                    context.Set<Shop>(
                        ))
                .Returns(mockDbSet.Object);

            Shop expectedShop = new Shop() { shop_id = 1 };
            mockDbSet.Setup(mock => mock.Find(expectedShop.shop_id))
                    .Returns(expectedShop);
            var repository = new TestShopRepository(mockContext.Object);

            //Act
            var actualShop = repository.Get(expectedShop.shop_id);

            // Assert
            mockDbSet.Verify(
                dbSet => dbSet.Find(
                    expectedShop.shop_id
                    ), Times.Once());
            Assert.Equal(expectedShop, actualShop);
        }

    }
}
