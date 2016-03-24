using NakedObjects.Xat;

namespace Dreamtec.TakeXat
{
	public class FluentTestAction<T>
	{
		public FluentTestAction(ITestAction testAction, object[] parameterValues)
		{
			TestAction = testAction;
			ParameterValues = parameterValues;
		}

		public ITestAction TestAction { get; set; }
		public object[] ParameterValues { get; set; }
	}
}