﻿using Convience.Model.Models.GroupManage;

using FluentValidation;

namespace Convience.Model.Validators.GroupManage
{
    public class EmployeeQueryModelValidator : AbstractValidator<EmployeeQueryModel>
    {
        public EmployeeQueryModelValidator()
        {
            RuleFor(viewmodel => viewmodel.Size).Must(size => size == 10 || size == 20 || size == 30 || size == 40).WithMessage("错误的长度！");

            RuleFor(viewmodel => viewmodel.Name).MaximumLength(10).WithMessage("检索内容过长！");
            RuleFor(viewmodel => viewmodel.PhoneNumber).MaximumLength(11).WithMessage("检索内容过长！");
        }
    }
}
