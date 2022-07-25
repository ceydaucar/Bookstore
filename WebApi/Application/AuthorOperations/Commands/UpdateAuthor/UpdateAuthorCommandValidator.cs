using AutoMapper;
using System;
using System.Linq;
using WebApi.DBOperations;
using WebApi.Entities;
using FluentValidation;

namespace WebApi.Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorCommandValidator()
        {
            RuleFor(command=>command.Model.Name).NotEmpty().When(x=> x.Model.Name != string.Empty);
            RuleFor(command=>command.Model.Surname).NotEmpty().When(x=> x.Model.Surname != string.Empty);            
            RuleFor(command=>command.Model.DateOfBirth.Date).NotEmpty().LessThan(DateTime.Now.Date).When(x => x.Model.DateOfBirth.ToString() != string.Empty);            
        }
    }
}