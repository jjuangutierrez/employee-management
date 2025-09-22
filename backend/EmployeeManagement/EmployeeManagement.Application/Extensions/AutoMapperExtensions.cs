using AutoMapper;

namespace EmployeeManagement.Application.Extensions;

public static class AutoMapperExtensions
{
    public static IMappingExpression<TSource, TDestination> IgnoreAllNonExisting<TSource, TDestination>(
        this IMappingExpression<TSource, TDestination> expression)
    {
        expression.ForAllMembers(opt =>
            opt.Condition((src, dest, srcMember) => srcMember != null));
        return expression;
    }
}
