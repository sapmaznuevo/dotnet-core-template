﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ModuleAdmin.Generated.Entities;
using ModuleAdmin.Generated.Enums;
using ModuleAdmin.IRepositories;
using ModuleAdmin.Generated.Data;

using CoreCommon.Data.Domain.Entitites;
using CoreCommon.Data.Domain.Enums;
using CoreCommon.Data.EntityFrameworkBase.Base;
using CoreCommon.Data.ElasticSearch.Base;
using CoreCommon.Data.Domain.Business;

namespace ModuleAdmin.Repositories
{
    public partial class AdminUserRoleMapRepository : EntityFrameworkBaseRepository<AdminUserRoleMapEntity, MainConnectionDbContext>, IAdminUserRoleMapRepository
    {

        public int DeleteById(int id)
        {            
            return DeleteBy(x => x.Id == id);
        }

        public AdminUserRoleMapEntity GetById(int id)
        {
            return GetBy(x => x.Id == id);
        }

        public int DeleteByUserId(int userId)
        {            
            return DeleteBy(x => x.UserId == userId);
        }

        public List<AdminUserRoleMapEntity> ListByUserId(int userId)
        {
            return FindBy(x => x.UserId == userId).ToList();
        }

        public List<AdminUserRoleMapEntity> ListByUserId(int userId, int skip, int take)
        {
            return FindBy(x => x.UserId == userId).Skip(skip).Take(take).ToList();
        }

        public List<object> Search(int? userId,int? roleId, string orderBy, bool asc, int skip, int take, out long _total)
        {
            var result = GetDbSet().AsQueryable();
            if (userId.HasValue)
                result = result.Where(x => x.UserId.Equals(userId));
            if (roleId.HasValue)
                result = result.Where(x => x.RoleId.Equals(roleId));
            var dic = new Dictionary<string, Func<AdminUserRoleMapEntity, object>>
            {
                {"id", x => x.Id},{"userId", x => x.UserId}
            };

            Func<AdminUserRoleMapEntity, object> selectFunc = x => new {
                x.Id,
				x.UserId,
				x.RoleId
            };
            
            if (!string.IsNullOrEmpty(orderBy) && dic.ContainsKey(orderBy))
            {
                var result2 = asc ? result.OrderBy(dic[orderBy]) : result.OrderByDescending(dic[orderBy]);
                return SkipTake(result2.Select(selectFunc), skip, take, out _total);
            }
            return SkipTake(result.Select(selectFunc), skip, take, out _total);
        }
    }
}
