# C-sharp-class-static-members
## Introduction to Static

At this point, you may recall:

- A custom data type is defined by a **class**.

- An instance of a class is called an **object**. Multiple, unique objects can be instantiated from one class.

- This process of bundling related data and methods into a type is called encapsulation, and it makes code easier to organize and reuse.

What if we needed to do something related to the type itself, not instances of that type? For example, where do we store the count of all `Forest` objects, or an explanation of forests in general?

To keep with the rules of encapsulation, these shouldn’t be associated with one instance (because this information is related to the `Forest` class, not a single `Forest` instance).

These facts and behaviors should be associated with the class itself! We call these types of members static.

---
## Static Fields and Properties

create a field and property, like:

```
class Forest
{
  private string definition;
  public string Definition
  {
     get { return definition; }
     set { definition = value; }
   }
}
```

The definition of what a forest is applies to all `Forest` objects, not just one — there should only be one value for the whole class. This is a good use case for a static field/property.

To make a static field and property, just add `static` after the access modifier (`public` or `private`).


```
class Forest
{
  private static string definition;
  public static string Definition
  { 
    get { return definition; }
    set { definition = value; }
  }
}
```

Remember that static means “associated with the class, not an instance”. Thus any static member is accessed from the class, not an instance:

```
static void Main(string[] args)
{
  Console.WriteLine(Forest.Definition);
}
```
If you tried to access a static member from an instance (like f.Definition) you would get an error like:

```
error CS0176: Static member 'Forest.Definition' cannot be accessed with an instance reference, qualify it with a type name instead
```
---
## Static Methods
create an instance method, like:

```
class Forest
{
  private string definition;
  public void Define()    
  {
    Console.WriteLine(definition);
  }
}
```

This behavior (printing a general definition) isn’t specific to any one instance — it applies to the class itself, so it should be made `static`.
To make a static method, just add `static` after the access modifier (`public` or `private`).
Notice that we added `static` to both the `field definition` and `method Define()`.

```
class Forest
{
  private static string definition;
  public static void Define()
  { 
    Console.WriteLine(definition); 
  }
}
```

This is because a static method can only access other static members. It cannot access instance members:

```
class Forest
{
  private string definition;
  public static void Define()
  { 
    // Throws error because definition is not static
    Console.WriteLine(definition); 
  }
}
```

---
## Static Constructors
An instance constructor is run before an instance is used, and a static constructor is run once before a class is used:
```
class Forest 
{
  static Forest()
  { /* ... */ }
}
```

This constructor is run when either one of these events occurs:

 - Before an object is made from the type.
 - Before a static member is accessed.

Typically we use static constructors to set values to static fields and properties.

A static constructor does not accept an access modifier.
---
## Static Classes
We covered a few static members: field, property, method, and constructor. What if we made the whole class static?
`static class Forest {}`

A static class cannot be instantiated, so you only want to do this if you are making a utility or library, like `Math` or `Console`.

These two common classes are static because they are just tools — they don’t need specific instances and they don’t store new information.

Now when you see something like:
```
Math.Min(34, 54);
Console.WriteLine("yeehaw!");

// these are two static classes calling two static methods.
```

---
## Common Static Errors
This error usually means you labeled a static constructor as public or private, which is not allowed:
`error CS0515: 'Forest.Forest()': static constructor cannot have an access modifier`

This usually means you tried to reference a non-static member from a class, instead of from an instance:

`error CS0120: An object reference is required to access non-static field, method, or property 'Forest.Grow()'`

This usually means that you tried to reference a static member from an instance, instead of from the class:
`error CS0176: Member 'Forest.TreeFacts' cannot be accessed with an instance reference; qualify it with a type name instead`

---
## Main()
The `Main()` method, the entry point for any program. You’ve seen it many times, but now you can explain every part!

```
class Program
{
  public static void Main (string[] args) 
  {
  }
}
```

- `Main()` is a method of the `Program` class.
- `public` — The method can be called outside the `Program `class.
- `static` — The method is called from the class name: `Program.Main()`.
- `void` — The method means returns nothing.
- `string[] args` — The method has one parameter named args, which is an array of strings.

`Main()` is like any other method you’ve encountered. It has a special use for C#, but that doesn’t mean you can’t treat it like a plain old method!


```
using System;

namespace ApplyingClasses
{
  class Program
  {
    static void Main(string[] args)
    {
      if (args.Length > 0)
      {
        string mainPhrase = String.Join(" and ", args);
        Console.WriteLine($"My favorite fruits are {mainPhrase}!");
      }

      
    }
  }
}

```

Each time we run dotnet run, the `Main()` method is called. We can include arguments on the command line, like `dotnet run arg1 arg2 arg3` that will be converted into an array as the `args` parameter.

---
## Review
- In general, static means “associated with the class, not an instance”.
- A static member is always accessed by the class name, rather than the instance name, like `Forest.Area`.
- A static method cannot access non-static members.
- A static constructor is run once per type, not per instance. It is invoked before the type is instantiated or a static member is accessed.
- Either of these would trigger the static constructor of `Forest`:

```
public static void Main() {
  Forest f  = new Forest(); 
}
```

or 

```
public static void Main() {
  Forest.Define(); 
}
```

- A static class cannot be instantiated. Its members are accessed by the class name, like Math.PI.





