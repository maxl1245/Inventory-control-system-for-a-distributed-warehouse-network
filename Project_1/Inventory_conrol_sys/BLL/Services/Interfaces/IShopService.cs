using System;
using System.Collections.Generic;
using System.Text;
using BLL.DTO;

namespace BLL.Services.Interfaces
{
    public interface IShopService
    {
        IEnumerable<ShopDTO> GetShops(int page);
    }
}
