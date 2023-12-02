using AutoMapper;
using CodeGeass.KnightmareFrames.Domain.Features.KnightmareFrames;

namespace CodeGeass.KnightmareFrames.Application.Features.KnightmareFrames.Commands.UpdateKnightmareFrame
{
    public class UpdateKnightmareFrameProfile: Profile
    {
        public UpdateKnightmareFrameProfile()
        {
            CreateMap<UpdateKnightmareFrameInput, KnightmareFrame>()
                .ForMember(dest => dest.Code, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore());
        }
    }
}
