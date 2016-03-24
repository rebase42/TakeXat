using NakedObjects.Xat;

namespace Dreamtec.TakeXat
{
	public class FluentAcceptanceTestCase : AcceptanceTestCase
	{
		public FluentTestService<T> GetService<T>()
		{
			var service = GetTestService(typeof (T));
			return new FluentTestService<T>(service, (T) service.NakedObject.Object);
		}
	}
}
