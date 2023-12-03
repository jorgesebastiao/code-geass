using AutoMapper;
using CodeGeass.KnightmareFrames.Domain.Features.KnightmareFrames;

namespace CodeGeass.KnightmareFrames.Application.Features.KnightmareFrames.Queries.GetByIdKnightmareFrame
{
    public class GetByIdKnightmareFrameProfile : Profile
    {
        public GetByIdKnightmareFrameProfile()
        {
            CreateMap<KnightmareFrame, GetByIdKnightmareFrameOutPut>();
        }
    }
}
