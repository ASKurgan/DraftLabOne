using DraftLabOne.Application.Validators;
using DraftLabOne.Domain.Common;
using FluentValidation;

namespace DraftLabOne.API.Note.CreateNote
{
    public class CreateNoteRequestValidator : AbstractValidator<CreateNoteRequest>
    {
        public CreateNoteRequestValidator()
        {
            RuleFor(x => x.Title)
              .NotEmptyWithError()
              .MaximumLengthWithError(Constraints.SHORT_TITLE_LENGTH);

            RuleFor(x => x.Description)
               .NotEmptyWithError()
               .MaximumLengthWithError(Constraints.MEDIUM_TITLE_LENGTH);
                
        }
    }
}
