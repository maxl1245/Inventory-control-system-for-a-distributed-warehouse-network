using System;
using DAL.EF;
using DAL.Repositories.Interfaces;
using DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Impl
{
    public class ShopRepository
        : BaseRepository<Shop>, IShopRepository
    {
        internal ShopRepository(SysteamContext context)
            : base(context)
        {
        }
    }
}
