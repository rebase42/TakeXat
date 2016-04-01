using System;
using System.Linq;
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

		private ITestObjectFactory testObjectFactory;
		public FluentTestObject<T> AsFluentTestObject<T>(T instance)
		{
			/*var factory = this.testObjectFactory 
				?? (this.testObjectFactory = (ITestObjectFactory)new TestObjectFactory(
					this.NakedObjectsFramework.MetamodelManager, 
					this.NakedObjectsFramework.Session, 
					this.NakedObjectsFramework.LifecycleManager, 
					this.NakedObjectsFramework.Persistor, 
					this.NakedObjectsFramework.NakedObjectManager, 
					this.NakedObjectsFramework.TransactionManager, 
					this.NakedObjectsFramework.ServicesManager, 
					this.NakedObjectsFramework.MessageBroker));
*/

			var testObject = this.TestObjectFactoryClass.CreateTestObject(
				this.NakedObjectsFramework.NakedObjectManager.CreateAdapter(
					instance,
					null,
					null));

			return new FluentTestObject<T>(testObject, instance);
		}

	}
}
