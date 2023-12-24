﻿using BusinessLogic.Models;
using FluentValidation;

namespace BusinessLogic.Validation
{
    public class StaffValidator : AbstractValidator<StaffModel>
    {
        public StaffValidator()
        {
            //RuleFor(s => s.Id).NotEmpty();

            //RuleFor(s => s.PositionId).NotNull().NotEmpty();

            RuleFor(s => s.Name).NotNull().NotEmpty().Matches(@"^[A-Za-z.,'\s\-]+$");

            RuleFor(s => s.Surname).NotNull().NotEmpty().Matches(@"^[A-Za-z.,'\s\-]+$");

            RuleFor(s => s.PhoneNumber).NotNull().NotEmpty().Matches(@"^\+380\d{9}$");

            RuleFor(s => s.Role).NotNull().IsInEnum();
        }
    }
}
