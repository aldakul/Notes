using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Notes.Application.Common.Behaviors;

namespace Notes.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection service)
    {
        service.AddMediatR(Assembly.GetExecutingAssembly());
        service.AddValidatorsFromAssemblies(new[] {Assembly.GetExecutingAssembly()});
        service.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        return service;
    }
}