using DAL.Entities;
using DAL.EF;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Impl
{
    public class SysteamRepository
        : BaseRepository<Systeam>, ISysteamRepository
    {

        internal SysteamRepository(SysteamContext context)
            : base(context)
        {
        }
    }
}
