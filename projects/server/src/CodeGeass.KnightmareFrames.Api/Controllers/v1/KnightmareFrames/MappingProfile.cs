using AutoMapper;
using CodeGeass.KnightmareFrames.Api.Controllers.v1.KnightmareFrames.Requests;
using CodeGeass.KnightmareFrames.Application.Features.KnightmareFrames.Commands.CreateKnightmareFrame;
using CodeGeass.KnightmareFrames.Application.Features.KnightmareFrames.Commands.UpdateKnightmareFrame;

namespace CodeGeass.KnightmareFrames.Api.Controllers.v1.KnightmareFrames
{
    /// <summary>
    /// Perfil de mapeamento do Aggreagate Armaduras 
    /// </summary>
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateKnightmareFrameRequest, CreateKnightmareFrameInput>();
            CreateMap<UpdateKnightmareFrameRequest, UpdateKnightmareFrameInput>();
        }
    }
}
