namespace CodeGeass.KnightmareFrames.Api.Controllers.v1.KnightmareFrames.Requests
{
    public record CreateKnightmareFrameRequest
    {
        public string Name { get; init; }
        public string Code { get; init; }
        public string Generation { get; init; }
    }
}
