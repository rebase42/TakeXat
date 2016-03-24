# TakeXat
A strongly typed, refactor-safe, fluent extension library for NakedObjects XAT

## Usage
##### Single entity
Setup a method that returns a single entity
```
var service = GetService<IUserService>();
var action = service.Setup(o => o.GetUserById(1));
action.TestAction.AssertIsVisible();
var value = action.InvokeAndGetValue();
var user = value.Object;
Assert.AreEqual(user.Id,1);
```

##### Collection
Setup a method that returns a collection
```
var service = GetService<IUserService>();
var action = service.Setup(o => o.GetUsersByName("Eric"));
action.TestAction.AssertIsVisible();
var value = action.InvokeAndGetCollection();
var users = value.Object;

// test against users collection

```
