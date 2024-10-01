# Shop Console Application

> .NET 8

## The principles of OOP used in the project

### Encapsulation

Classes such as 'Product` and `Store' contain their own fields and methods that control access to these fields.

`Id`, `Name`, and `Price` properties in the `Product` class can be encapsulated using `get` and `set`.

### Polymorphism

Using the `IProduct` interface to work with different products.

### Inheritance

Creating the `IProduct` interface, which is implemented by various product classes (for example, `Product`)

### Abstraction

Defining a `Product` interface that describes the basic methods and properties for all products, without detailing how they are implemented.
