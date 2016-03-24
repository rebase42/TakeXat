using NakedObjects.Xat;

namespace Dreamtec.TakeXat
{
	public class FluentTestCollection<T>
	{
		public FluentTestCollection(ITestCollection collection, T o)
		{
			Collection = collection;
			Object = o;
		}

		public ITestCollection Collection { get; set; }
		public T Object { get; set; }
	}
}