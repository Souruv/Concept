
using System;
using AutoMapper;
using System.Collections.Generic;
using System.Text;
using CF.AuthService.Application.Entities;
using CF.AuthService.Application.Common.Mappings;

namespace CF.AuthService.Application.Features.UserFeatures.Dto
{
    public class FelStageDto : IMapFrom<FelStage>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
       


    }
}
