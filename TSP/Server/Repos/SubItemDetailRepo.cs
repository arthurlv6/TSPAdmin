using AutoMapper;
using TSP.Server.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TSP.Shared;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace TSP.Server.Repos
{
    public class SubItemDetailRepo : BaseRepo
    {
        public SubItemDetailRepo(ApplicationDbContext _dBContext, IMapper _mapper) : base(_dBContext, _mapper)
        {
        }
        public async Task<Tuple<IEnumerable<M>, double>> GetPageData<M>(int SubMenuItemId = 0,int page = 1, int size = 20, string keyword = "") where M : BaseModel
        {
            var queryable = dBContext.Set<SubItemDetail>().AsQueryable();
            Expression<Func<SubItemDetail, bool>> nameExpected = d => true;
            if (!string.IsNullOrEmpty(keyword))
            {
                nameExpected = d => d.Name.Contains(keyword);
            }

            Expression<Func<SubItemDetail, bool>> categoryExpected = d => true;
            if (SubMenuItemId > 0)
                categoryExpected = d => d.SubMenuItemId == SubMenuItemId;

            double count = await queryable.Where(nameExpected).Where(categoryExpected).CountAsync();
            double pagesQuantity = Math.Ceiling(count / size);
            var pagination = new PaginationModel() { Page = page, QuantityPerPage = size };
            return new Tuple<IEnumerable<M>, double>(await queryable.Where(nameExpected).Where(categoryExpected).Paginate(pagination).Select(d => d.ToModel<M>(mapper)).ToListAsync(), pagesQuantity);
        }
    }
}
