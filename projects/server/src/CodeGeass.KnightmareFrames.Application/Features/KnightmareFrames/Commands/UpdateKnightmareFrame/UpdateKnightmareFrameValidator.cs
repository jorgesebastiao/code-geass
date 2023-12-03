using FluentValidation;


namespace CodeGeass.KnightmareFrames.Application.Features.KnightmareFrames.Commands.UpdateKnightmareFrame
{
    public class UpdateKnightmareFrameValidator : AbstractValidator<UpdateKnightmareFrameInput>
    {
        public UpdateKnightmareFrameValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
            RuleFor(x => x.Name).NotEmpty().NotNull();
            RuleFor(x => x.Generation).NotEmpty().NotNull();
        }
    }
}
