using FluentValidation;

namespace CodeGeass.KnightmareFrames.Application.Features.KnightmareFrames.Queries.GetByIdKnightmareFrame
{
    public class GetByIdKnightmareFrameValidator : AbstractValidator<GetByIdKnightmareFrameInput>
    {
        public GetByIdKnightmareFrameValidator()
        {
            RuleFor(x => x.KnightmareFrameId).NotEmpty().NotNull();
        }
    }
}
