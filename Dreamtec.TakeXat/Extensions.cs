using System;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using NakedObjects;
using NakedObjects.Util;
using NakedObjects.Xat;

namespace Dreamtec.TakeXat
{
	public static class Extensions
	{
		public static FluentTestAction<TResult> Setup<T, TResult>(this FluentTestService<T> obj, Expression<Func<T, TResult>> action)
		{
			return Setup(obj.Service, action);
		}

		public static FluentTestAction<T> Setup<T>(this FluentTestService<T> obj, Expression<Action<T>> action)
		{
			return Setup(obj.Service, action);
		}

		public static FluentTestAction<TResult> Setup<T, TResult>(this FluentTestObject<T> obj, Expression<Func<T, TResult>> action)
		{
			return Setup(obj.TestObject, action);
		}

		public static FluentTestAction<T> Setup<T>(this FluentTestObject<T> obj, Expression<Action<T>> action)
		{
			return Setup(obj.TestObject, action);
		}

		public static FluentTestAction<TResult> Setup<T, TResult>(this ITestHasActions obj, Expression<Func<T, TResult>> action)
		{
			return Setup<TResult>(obj, action.Body as MethodCallExpression);
		}

		public static FluentTestAction<T> Setup<T>(this ITestHasActions obj, Expression<Action<T>> action)
		{
			return Setup<T>(obj, action.Body as MethodCallExpression);
		}

		private static FluentTestAction<T> Setup<T>(this ITestHasActions obj, MethodCallExpression methodCallExpression)
		{
			if (methodCallExpression == null)
				throw new Exception($"{nameof(methodCallExpression)} is not a {typeof(MethodCallExpression)}");

			var expression = methodCallExpression;
			var methodName = expression.Method.Name;

			var paramTypes = expression.Method.GetParameters().Select(o => o.ParameterType).ToArray();
			//var paramTypes = expression.GetParameterTypes();
			var paramValues = expression.GetParameterValues();
			var nofName = NameUtils.MakeTitle(methodName);
			
			// check for a named attribute on the method
			var method = obj.NakedObject.Object.GetType().GetMethod(methodName, paramTypes);
			if (method.GetCustomAttribute<NamedAttribute>() != null)
			{
				var named = method.GetCustomAttribute<NamedAttribute>();
				nofName = named.Value;
			}
		    if (method.GetCustomAttribute<DisplayNameAttribute>() != null)
		    {
		        var named = method.GetCustomAttribute<DisplayNameAttribute>();
		        nofName = named.DisplayName;
		    }

            var nofAction = obj.GetAction(nofName, paramTypes);
			return new FluentTestAction<T>(nofAction, paramValues);
		}

		public static void Invoke<T>(this FluentTestAction<T> fluentTestAction)
		{
			var parameters = fluentTestAction.ParameterValues;
			fluentTestAction.TestAction.Invoke(parameters);
		}

		public static FluentTestObject<T> InvokeAndGetValue<T>(this FluentTestAction<T> fluentTestAction)
		{
			var parameters = fluentTestAction.ParameterValues;
			var obj = fluentTestAction.TestAction.InvokeReturnObject(parameters);

			return new FluentTestObject<T>(obj, (T) obj.NakedObject.Object);
		}

		public static FluentTestCollection<T> InvokeAndGetCollection<T>(this FluentTestAction<T> fluentTestAction)
		{
			var parameters = fluentTestAction.ParameterValues;
			var collection = fluentTestAction.TestAction.InvokeReturnCollection(parameters);

			return new FluentTestCollection<T>(collection, (T) collection.NakedObject.Object);
		}
		
	}
}