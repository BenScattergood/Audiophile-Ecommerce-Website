using FluentValidation;

namespace AudiophileEcommerceWebsite.Validators
{
	public class OrderViewModelValidator :AbstractValidator<OrderViewModel>
	{
		public OrderViewModelValidator()
		{
			RuleFor(o => o.Name).NotEmpty()
								.MinimumLength(3)
								.MaximumLength(50);

			RuleFor(o => o.EmailAddress).NotEmpty().WithMessage("Required")
										.EmailAddress().WithMessage("Wrong format");

			RuleFor(o => o.PhoneNumber).NotEmpty().WithMessage("Required")
										.Matches(@"^[\d]+$").WithMessage("Must be a number");
            RuleFor(o => o.Address).NotEmpty().WithMessage("Required");
			RuleFor(o => o.ZIPCode).NotEmpty().WithMessage("Required");
			RuleFor(o => o.City).NotEmpty().WithMessage("Required");
			RuleFor(o => o.Country).NotEmpty().WithMessage("Required");

			When(o => o.PaymentMethod == PaymentMethod.eMoney, 
				() =>
				{
					RuleFor(o => o.eMoneyNumber).NotEmpty().WithMessage("Required")
                                                .Length(9)
                                                .Matches(@"^[\d]+$").WithMessage("Must be a number"); ;
					RuleFor(o => o.eMoneyPIN).NotEmpty().WithMessage("Required")
                                             .Length(4)
                                             .Matches(@"^[\d]+$").WithMessage("Must be a number"); ;
                });

        }
	}

	public class CategoryValidator : AbstractValidator<String>
	{
		public CategoryValidator()
		{

		}
	}
}
