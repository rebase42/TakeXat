using System;
using System.Linq;
using System.Linq.Expressions;

namespace Dreamtec.TakeXat
{
	internal static class MemberExtensions
	{
		internal static object[] GetParameterValues(this MethodCallExpression methodCallExpression)
		{
			return (from arg in methodCallExpression.Arguments
				let argAsObj = Expression.Convert(arg, typeof (object))
				select Expression.Lambda<Func<object>>(argAsObj, null)
					.Compile()())
				.ToArray();
		}

		internal static Type[] GetParameterTypes(this MethodCallExpression methodCallExpression)
		{
			var types = (from arg in methodCallExpression.Arguments
				select arg.Type)
				.ToArray();

			return types;
		}
	}
}