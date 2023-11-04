using CodeGeass.Application.Common;

namespace CodeGeass.KnightmareFrames.Application.Features.KnightmareFrames.Commands.DeleteKnightmareFrame
{
    public class DeleteKnightmareFrameInput: BaseCommandInput
    {
        public Guid KnightmareFrameId { get; set; }
    }
}
