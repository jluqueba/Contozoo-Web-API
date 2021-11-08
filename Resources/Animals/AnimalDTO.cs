using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contozoo.Resources.Animals
{
	public class AnimalDTO : AnimalBase
	{

	}

	public class AnimalDTOValidator : AbstractValidator<AnimalDTO>
	{
		public AnimalDTOValidator()
		{
			RuleFor(x => x.CAI)
				.GreaterThanOrEqualTo(1)
				.WithMessage("CAI can not be 0");
			RuleFor(x => x.Name)
				.NotEmpty()
				.WithMessage("Name can not be empty");
			RuleFor(x => x.ActiveHour)
				.InclusiveBetween(0, 23)
				.WithMessage("Active hour must be betwwen 0 and 23");
		}
	}
}
