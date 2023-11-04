using FluentValidation;

namespace CodeGeass.KnightmareFrames.Application.Features.KnightmareFrames.Commands.CreateKnightmareFrame
{
    public class CreateKnightmareFrameValidator : AbstractValidator<CreateKnightmareFrameInput>
    {
        public CreateKnightmareFrameValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull();
            RuleFor(x => x.Code).NotEmpty().NotNull();
            RuleFor(x => x.Generation).NotEmpty().NotNull();
        }
    }
}
