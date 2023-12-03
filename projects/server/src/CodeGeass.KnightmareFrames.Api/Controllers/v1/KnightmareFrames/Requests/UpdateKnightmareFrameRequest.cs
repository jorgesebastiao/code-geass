﻿namespace CodeGeass.KnightmareFrames.Api.Controllers.v1.KnightmareFrames.Requests
{
    public record UpdateKnightmareFrameRequest
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string Generation { get; init; }
    }
}
