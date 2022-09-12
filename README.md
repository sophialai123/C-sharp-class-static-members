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


