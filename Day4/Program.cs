using System;

// Static class demo
Console.WriteLine(StaticClassDemo.StaticClassConstant);
StaticClassDemo.Display();

Console.WriteLine();

// Class vs Object
var x = new ClassVsObject();
Console.WriteLine(x.MyProperty);

Console.WriteLine();

// Properties demo
PropertiesDemo demo = new PropertiesDemo();
Console.WriteLine(demo.MyProperty);
Console.WriteLine($"Age before modification: {demo.MyAge}");
demo.ModifyName();
Console.WriteLine($"Age after modification: {demo.MyAge}");

Console.WriteLine();

// Interface demo
ElectricityOnlySupplier supplier = new ElectricityOnlySupplier();
supplier.SupplyService();

Console.WriteLine();

// Abstract / base / new keyword demo
Fruit discount = new Apple();
discount.ApplyDiscount();
