using CodeGeass.Application.Common;

namespace CodeGeass.KnightmareFrames.Application.Features.KnightmareFrames.Queries.GetByIdKnightmareFrame
{
    public class GetByIdKnightmareFrameInput : BaseQueryInput
    {
        public Guid KnightmareFrameId { get; set; }

    }
}
