using CF.ConceptBrainService.Application.Features.UserFeatures.Dto;
using System;
using System.Collections.Generic;
using System.Text;


namespace CF.ConceptBrainService.Application.Common.Interfaces
{
    public interface ILoggedInUserService
    {
        Guid Id { get; }

        string Email { get; }

        AppUserDto User { get; }
    }
}
