using CodeGeass.Application.Common;

namespace CodeGeass.KnightmareFrames.Application.Features.KnightmareFrames.Commands.CreateKnightmareFrame
{
    public class CreateKnightmareFrameInput : BaseCommandInput
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Generation { get; set; }
    }
}
