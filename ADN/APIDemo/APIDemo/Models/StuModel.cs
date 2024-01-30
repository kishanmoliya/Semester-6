using FluentValidation;

namespace APIDemo.Models
{
    public class StuModel : AbstractValidator<StudentModel>
    {
        public StuModel() {
            RuleFor(c => c.StudentName).NotEmpty().WithMessage("Student Name is Required");
        }
    }
}
