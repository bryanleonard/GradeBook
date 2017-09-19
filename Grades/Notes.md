# Reference Types

* Variable store a reference to an object
  * Multiple variables can point to the same object. Can have multiple variables 
  * pointing to the same object. Can have multiple versions of the same object.
    ````
    g1 --> GradeBook
    g2 --> GradeBook
    ````
  
# Value Types

* Variables hold the value
  * No pointers, no references
* ex. Int and Float are value types
* VTs exist bc they are faster to allocate than a reference type
* usually smaller file size, too.
* Typically they are immutable, you can't change the value of '4.'

### How do you know which one you're working with?
* I don't know

### Creating Value Types

* struct definitions create value types
  * should represent a single value
  * should be small
* by default, you'll probablay want to create a class before a struct

**Enumerations**
* An **enum** creates a value type
* underlying data type is int by default
````c#
public enum PayrollType
{
    Contractor = 1,
    Salaried, 
    Executive,
    Hourly
}
// so instead of "if (emp.Role == 2) {...}"
// you can say "if (emp.Role = PayrollType.Hourly) {...}"
// more descriptive and easier to understand
````


### Method Parameters
* Parameters pass "by value"
  * Reference types pass a copy of the reference
  * Value types pass a copy of the value

### Immutability
* Value types are usually immutable
* Can not change the value of 4
* Can not change the value of Aug 9th 2012

### Arrays
* Manage a collection of variables
* Must declare length of the array
* That's why **Lists** are more gooder.


## Methods
- Defined behavior
- every method has a return type
  - void equals no return
- has zero or more params
  - use "params" keyword to accept a variable number of parameters
- every method has a signature
  - name of method + params


## Fields 
- are variables of a class
````c#
public class Animal
{
    private readonly string _name; // this is a field

    public Animal(string name)_
    {
        _name = name;
    }
}
// readonly prevents field val from being changed once assigned
````


## Properties
- A property can define a get and/or set accessor
  - often used to expose and control fields
````c#
private string _name;

public string Name // this a property, so capitalize it (like methods)
{
    get { return _name;_}
    set {
        if(!String.IsNullOrEmpty(value) 
        {
            _name = value;_
        }
    }
}
````

## Events
- allows a class to send notifications to other classes or objects
- one or more subscribers process the event

## Delegates
- i need a variable hat references a method
- a delegate is a type that references methods
````c#
public delegate void Writer(string message);
````