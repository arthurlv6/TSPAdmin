using AutoMapper;
using TSP.Server.Data;
using TSP.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace TSP.Server.Repos
{
    public class BaseRepo
    {
        protected readonly ApplicationDbContext dBContext;
        protected readonly IMapper mapper;
        public BaseRepo(ApplicationDbContext _dBContext, IMapper _mapper)
        {
            dBContext = _dBContext;
            mapper = _mapper;
        }
        public virtual IEnumerable<M> GetAll<T, M>(int page=1,int size=20,string keyword = "") where T : BaseEntity where M : BaseModel
        {
            return dBContext.Set<T>()
                .Where(d=>d.Name.Contains(keyword))
                .OrderBy(d=>d.Id)
                .Skip((page -1)*size)
                .Take(size)
                .Select(d => d.ToModel<M>(mapper));
        }
        public async Task<M> GetOneAsync<T,M>(int id) where T : BaseEntity where M : BaseModel
        {
            var requirement = await dBContext.Set<T>()
            .AsNoTracking()
            .FirstOrDefaultAsync(d => d.Id == id);
            if (requirement != null)
                return requirement.ToModel<M>(mapper);
            else
                return null;
        }
        public async Task UpdateAsync<T, M>(M m) where T : BaseEntity where M : BaseModel
        {
            try
            {
                var entity = dBContext.Set<T>().First(d => d.Id == m.Id);
                mapper.Map(m, entity);
                await dBContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
