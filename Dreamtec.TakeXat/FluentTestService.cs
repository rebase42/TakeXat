using NakedObjects.Xat;

namespace Dreamtec.TakeXat
{
	public class FluentTestService<T>
	{
		public FluentTestService(ITestService service, T o)
		{
			Service = service;
			Object = o;
		}

		public ITestService Service { get; set; }
		public T Object { get; set; }
	}
}