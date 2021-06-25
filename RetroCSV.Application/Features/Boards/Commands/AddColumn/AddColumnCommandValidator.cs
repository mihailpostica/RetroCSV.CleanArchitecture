using FluentValidation;

namespace RetroCSV.Core.Features.Boards.Commands.AddColumn
{
    public class AddColumnCommandValidator:AbstractValidator<AddColumnCommand>
    {
        public AddColumnCommandValidator()
        {
            RuleFor(c => c.BoardId).NotNull().WithMessage("BoardId can not be null").NotEmpty().WithMessage("Can not be empty");
            
            RuleFor(c => c.Description)
                .MaximumLength(100).WithMessage("Can not exceed 100 characters")
                .NotEmpty().WithMessage("Can not be empty");
        }
        
    }
}