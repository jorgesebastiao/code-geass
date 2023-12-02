﻿
using CodeGeass.Application.Common;

namespace CodeGeass.KnightmareFrames.Application.Features.KnightmareFrames.Commands.UpdateKnightmareFrame
{
    public class UpdateKnightmareFrameInput: BaseCommandInput
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Generation { get; set; }
    }
}
