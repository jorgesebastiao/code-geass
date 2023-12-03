using AutoMapper;
using CodeGeass.KnightmareFrames.Domain.Features.KnightmareFrames;

namespace CodeGeass.KnightmareFrames.Application.Features.KnightmareFrames.Queries.GetAllKnightmareFrame
{
    public class GetAllKnightmareFrameProfile : Profile
    {

        public GetAllKnightmareFrameProfile()
        {
            CreateMap<KnightmareFrame, GetAllKnightmareFrameOutPut>();
        }
    }
}
