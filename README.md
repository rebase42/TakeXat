# TakeXat
A strongly typed, refactor-safe, fluent extension library for NakedObjects XAT

Package is available on nuget.org
```
Install-Package Dreamtec.TakeXat
```

## Usage
### TestClass
Inherit from `FluentAcceptanceTestCase` instead of `AcceptanceTestCase`
```
[TestClass]
public class MyTestClass : FluentAcceptanceTestCase
{
}
```
##### Single entity
Setup a method that returns a single entity
```
[TestMethod]
public void ShouldGetUserById()
{
  var service = GetService<IUserService>();
  var action = service.Setup(o => o.GetUserById(1));
  action.TestAction.AssertIsVisible();
  var value = action.InvokeAndGetValue();
  var user = value.Object;
  Assert.AreEqual(user.Id,1);
}
```

##### Collection
Setup a method that returns a collection
```
[TestMethod]
public void ShouldGetUsersByName()
{
  var service = GetService<IUserService>();
  var action = service.Setup(o => o.GetUsersByName("Eric"));
  action.TestAction.AssertIsVisible();
  var value = action.InvokeAndGetCollection();
  var users = value.Object;
  
  // test against users collection
}

```
