using AutoMapper;
using CodeGeass.KnightmareFrames.Domain.Features.KnightmareFrames;

namespace CodeGeass.KnightmareFrames.Application.Features.KnightmareFrames.Commands.CreateKnightmareFrame
{
    public class CreateKnightmareFrameProfile: Profile
    {
        public CreateKnightmareFrameProfile()
        {
            CreateMap<CreateKnightmareFrameInput,KnightmareFrame>()
                 .ForMember(dest => dest.Id, opt => opt.Ignore())
                 .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                 .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore());
        }
    }
}
 