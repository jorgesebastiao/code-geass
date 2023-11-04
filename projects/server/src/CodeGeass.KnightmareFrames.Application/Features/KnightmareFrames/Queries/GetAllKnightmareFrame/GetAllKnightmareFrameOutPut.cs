using CodeGeass.Application.Common;

namespace CodeGeass.KnightmareFrames.Application.Features.KnightmareFrames.Queries.GetAllKnightmareFrame
{
    public class GetAllKnightmareFrameOutPut: IOutput
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Generation { get; set; }
    }
}
