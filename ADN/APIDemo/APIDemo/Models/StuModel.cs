using FluentValidation;

namespace APIDemo.Models
{
    public class StuModel : AbstractValidator<StudentModel>
    {
      /*  public StuModel() {
            RuleFor(c => c.StudentName).NotEmpty().WithMessage("Student Name is Required");
        }*/

        public StuModel()
        {
            RuleFor(p => p.ProductName)
                .NotNull().WithMessage("Product name is required.")
                .NotEmpty().WithMessage("Product name cant't be empty.");


            RuleFor(p => p.ProductName)
                .NotNull().WithMessage("Password is required.")
                .NotEmpty().WithMessage("Password cant't be empty.")
                .Length(8, 25).WithMessage("Password must be between 8 to 25 characters.")
                .Matches("^(?=.[A-Za-z])(?=.\\d)(?=.[!@#$%^&()+])[A-Za-z\\d!@#$%^&*()+]{8,}$").WithMessage("Password contain at letters, digits, and special symbols.");


            RuleFor(p => p.ProductName)
               .NotNull().WithMessage("Confirm Password is required.")
               .NotEmpty().WithMessage("Confirm Password cant't be empty.")
               .DependentRules(() =>
               {
                   RuleFor(p => p.Password)
                   .NotEmpty().WithMessage("Password can't be empty when confirm password provided.");
               })
               .Equal(p => p.Password).WithMessage("Password can't matched.");


            RuleFor(p => p.Phone)
                .NotNull().WithMessage("Product name is required.")
                .NotEmpty().WithMessage("Product name cant't be empty.")
                .Length(10).WithMessage("Phone is must 10 Digit.");


            RuleFor(p => p.Email)
                .NotNull().WithMessage("Email is required.")
                .NotEmpty().WithMessage("Email cant't be empty.")
                .EmailAddress().WithName("Email Address");


            RuleFor(p => p.Price)
                .GreaterThan(0).WithMessage("Price is greater than 0.")
                .LessThan(1000).WithMessage("Price is less than 10000.");


            RuleFor(p => p.Discount)
                .InclusiveBetween(0, 100).WithMessage("Discount between 0% and 100%.");

            RuleFor(p => p.StockCount)
                .GreaterThanOrEqualTo(0).WithMessage("Not Negative")
                .LessThanOrEqualTo(500).WithMessage("Maximum 500.");
        }
    }
}
