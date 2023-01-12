using System.Linq.Expressions;
using System.Reflection;
using System;

namespace Codescovery.Library.Commons.Services
{
    public class FluentBuilder<T, TMember>
    {
        private readonly T _source;
        private readonly Expression<Func<T, TMember>> _field;

        public FluentBuilder(T source, Expression<Func<T, TMember>> field)
        {
            _source = source;
            _field = field;
        }

        public T Set(TMember value)
        {
            var memberInfo = GetMemberInfo(_field);
            SetMemberValue(memberInfo, _source, value);
            return _source;
        }

        private static MemberInfo GetMemberInfo(Expression<Func<T, TMember>> expression)
        {
            if (expression.Body is MemberExpression member)
                return member.Member;

            throw new ArgumentException("Expression is not a member access", nameof(expression));
        }

        private static void SetMemberValue(MemberInfo member, T target, object value)
        {
            switch (member.MemberType)
            {
                case MemberTypes.Field:
                    ((FieldInfo)member).SetValue(target, value);
                    break;
                case MemberTypes.Property:
                    ((PropertyInfo)member).SetValue(target, value, null);
                    break;
                case MemberTypes.All:
                case MemberTypes.Constructor:
                case MemberTypes.Custom:
                case MemberTypes.Event:
                case MemberTypes.Method:
                case MemberTypes.NestedType:
                case MemberTypes.TypeInfo:
                default:
                    throw new ArgumentException("MemberInfo must be if type FieldInfo or PropertyInfo", nameof(member));
            }
        }
    }
}