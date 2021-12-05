using CF.ProjectService.Application.Common.Bases;
using CF.ProjectService.Application.Common.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CF.ProjectService.Application.Common.Bases
{
    public class BasePaginationQuery<T> : IRequest<PaginatedList<T>>
    {
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string? SortColumn { get; set; } = string.Empty;
        public string? SortDirection { get; set; } = string.Empty;

    }

    public class ResponsePaginationQuery<T> : IRequest<CustomResponse<PaginatedNotificationList<T>>>
    {
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string? SortColumn { get; set; } = string.Empty;
        public string? SortDirection { get; set; } = string.Empty;

    }
}
