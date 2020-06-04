using System;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Unit_of_work
{
    public interface IUnitOfWork : IDisposable
    {
        ISysteamRepository Systeams { get; }
        IShopRepository Shops { get; }
        void Save();
    }
}
