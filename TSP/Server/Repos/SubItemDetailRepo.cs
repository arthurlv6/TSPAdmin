using AutoMapper;
using TSP.Server.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TSP.Server.Repos
{
    public class SubItemDetailRepo : BaseRepo
    {
        public SubItemDetailRepo(ApplicationDbContext _dBContext, IMapper _mapper) : base(_dBContext, _mapper)
        {
        }
    }
}
