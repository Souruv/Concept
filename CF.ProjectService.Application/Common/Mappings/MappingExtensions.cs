using AutoMapper;
using AutoMapper.QueryableExtensions;
using CF.ProjectService.Application.Common.Bases;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CF.ProjectService.Application.Common.Mappings
{
    public static class MappingExtensions
    {
        public static Task<PaginatedList<TDestination>> PaginatedListAsync<TDestination>(this IQueryable<TDestination> queryable, int pageIndex, int pageSize)
            => PaginatedList<TDestination>.CreateAsync(queryable, pageIndex, pageSize);

        public static Task<PaginatedNotificationList<TDestination>> PaginatedNotificationListAsync<TDestination>(this IQueryable<TDestination> queryable, int pageIndex, int pageSize)
            => PaginatedNotificationList<TDestination>.CreateAsync(queryable, pageIndex, pageSize);

        public static Task<List<TDestination>> ProjectToListAsync<TDestination>(this IQueryable queryable, IConfigurationProvider configuration)
            => queryable.ProjectTo<TDestination>(configuration).ToListAsync();
    }
}
