﻿using AutoMapper;
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
    public class ContactUsRepo: BaseRepo
    {
        public ContactUsRepo(ApplicationDbContext _dBContext, IMapper _mapper) : base(_dBContext, _mapper)
        {
        }
        public async Task<ContactUsModel> AddAsync(ContactUsModel model)
        {
            ContactUs detail = mapper.Map<ContactUs>(model);
            var addedEntity = dBContext.ContactUs.Add(detail);
            try
            {
                await dBContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
            return addedEntity.Entity.ToModel<ContactUsModel>(mapper);
        }
    }
}
