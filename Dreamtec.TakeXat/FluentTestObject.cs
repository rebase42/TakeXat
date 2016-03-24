using NakedObjects.Xat;

namespace Dreamtec.TakeXat
{
	public class FluentTestObject<T>
	{
		public FluentTestObject(ITestObject testObject, T o)
		{
			TestObject = testObject;
			Object = o;
		}

		public ITestObject TestObject { get; set; }
		public T Object { get; set; }
	}
}