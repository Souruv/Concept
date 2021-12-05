
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CF.AuthService.Application.Features.UserFeatures.Dto;
using Microsoft.Extensions.Configuration;
using CF.AuthService.Application.Common.Interfaces;


namespace CF.AuthService.Application.Features.UserFeatures.Queries
{
    public class GetFilteredGraphUsersQuery : IRequest<List<AppUserDto>>
    {
        public string  SearchText { get; set; }

        public class GetFilteredGraphUsersQueryHandler : IRequestHandler<GetFilteredGraphUsersQuery, List<AppUserDto>>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;
            private readonly IGraphService _graphService;
            private readonly IConfiguration _iConfig;
            public GetFilteredGraphUsersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IGraphService graphService, IConfiguration iConfig)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
                _graphService = graphService;
                _iConfig = iConfig;
            }
            public async Task<List<AppUserDto>> Handle(GetFilteredGraphUsersQuery query, CancellationToken cancellationToken)
            {
                _graphService.Configure(_iConfig.GetValue<string>("AzureActiveDirectory:ClientIdGraph")
                    , _iConfig.GetValue<string>("AzureActiveDirectory:ClientSecret")
                    , _iConfig.GetValue<string>("AzureActiveDirectory:TenantId")
                    , _iConfig.GetValue<string>("AzureActiveDirectory:GraphApiUrl")
                    );
                return await _graphService.Search(query.SearchText);
                //var list = _graphService.Search(SearchText);
                //var user = await _unitOfWork.UserRepository.GetSingleAsync(a => a.Id == query.Id);//.ProjectTo<UserDto>(_mapper.ConfigurationProvider).FirstOrDefault();
                //if (user == null) return null;

                //return _mapper.Map<AppUser, AppUserDto>(user);

                //return new AppUserDto();
            }
        }
    }
}
