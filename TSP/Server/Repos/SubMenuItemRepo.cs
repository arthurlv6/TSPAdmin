using AutoMapper;
using TSP.Server.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TSP.Shared;
using Microsoft.EntityFrameworkCore;

namespace TSP.Server.Repos
{
    public class SubMenuItemRepo : BaseRepo
    {
        public SubMenuItemRepo(ApplicationDbContext _dBContext, IMapper _mapper) : base(_dBContext, _mapper)
        {


        }
        public virtual async Task<IEnumerable<M>> GetAll< M>(int subSystemId) where M : BaseModel
        {
            return await dBContext.Set<SubMenuItem>()
                .Where(d => d.SubSystemId==subSystemId)
                .OrderBy(d=>d.Order)
                .Select(d => d.ToModel<M>(mapper))
                .ToListAsync();
        }
    }
}
