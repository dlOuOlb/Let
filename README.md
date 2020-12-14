# Let

This library imitates readonly local variables abusing some language features.

## Demonstration

Source code:

```cs
namespace Demo
{
	using S = System;
	using OuO = dlOuOlb;
	public static class Program
	{
		private static readonly S.Random RNG = new S.Random();
		public static void Main()
		{
			// readonly var Bar = RNG.Next(); // No such thing in .NET 5.0 / C# 9.0 !

			// Creating a singleton with a random integer,
			// which cannot be determined in compile time:
			// using var Foo = new OuO.Let<S.Int32>(V: RNG.Next()); // Too verbose.
			// using var Foo = (OuO.Let<S.Int32>)RNG.Next(); // Less verbose.
			using var Foo = OuO.Let.New(V: RNG.Next());

			// Foo.V=7; // Error!
			// Foo=OuO.Let.New(V: 7); // Error!

			// Printing the value:
			S.Console.WriteLine(value: $"Foo = {Foo}");
			S.Console.WriteLine(value: $"Foo.V = {Foo.V}");

			// If you want to rip off the container:
			foreach(var Bar in Foo)
			{
				// Bar=7; // Error!
				S.Console.WriteLine(value: $"Bar = {Bar}");
			}

			return;
			// Foo.Dispose(), implemented as no-op, would be called behind the scene.
		}
	}
}
```

Console output: (Just assume that the value was 31 for example.)

```txt
Foo = (31)
Foo.V = 31
Bar = 31
```

## Gotcha!

A `Let<T>` instance holds an object of type `T` as a `readonly` field `V`, which seems pretty easy until it isn't. Please see this [documentation](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/readonly "readonly (C# Reference)"):

> A `readonly` field can't be assigned after the constructor exits. This rule has __different__ implications for value types and reference types:
> - Because value types directly contain their data, a field that is a `readonly` value type is immutable.
> - Because reference types contain a reference to their data, a field that is a `readonly` reference type must always refer to the same object. That object isn't immutable. The `readonly` modifier prevents the field from being replaced by a different instance of the reference type. __However__, the modifier doesn't prevent the instance data of the field from being modified through the `readonly` field.

## Release Notes

Version 0.1.0.0

- Date: 2020-12-12.
- The initial release.

Version 0.2.0.0

- Date: 2020-12-14.
- A bug fix for `IReadOnlySet` `SetEquals` implementation.
