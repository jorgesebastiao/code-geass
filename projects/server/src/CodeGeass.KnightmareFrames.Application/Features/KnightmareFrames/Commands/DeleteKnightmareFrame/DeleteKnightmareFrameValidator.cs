using FluentValidation;

namespace CodeGeass.KnightmareFrames.Application.Features.KnightmareFrames.Commands.DeleteKnightmareFrame
{
    public class DeleteKnightmareFrameValidator : AbstractValidator<DeleteKnightmareFrameInput>
    {
        public DeleteKnightmareFrameValidator()
        {
            RuleFor(x => x.KnightmareFrameId).NotEmpty().NotNull();
        }
    }
}
