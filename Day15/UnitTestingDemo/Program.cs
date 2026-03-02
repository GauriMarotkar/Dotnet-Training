// Falsifiable


AddFunctionShouldReturn30ForInputs10And20();
AddFunctionShouldReturn40ForInputs20And20();
AddFunctionShouldReturn50ForInputs25And25();

void AddFunctionShouldReturn30ForInputs10And20()
{
    // Arrange
    var x = 10;
    var y = 20;
    var expctedResult = 30;

    // Act
    var actualRestul = Add(x, y);

    // Assert
    Console.WriteLine($"Actual Result: {actualRestul}, Expected Result: {expctedResult}");

    if (actualRestul == expctedResult)
    {
        Console.WriteLine("Test Passed");
    }
    else
    {
        Console.WriteLine("Test Failed");
    }
}

void AddFunctionShouldReturn40ForInputs20And20()
{
    var actualRestul = Add(20, 20);

    var expctedResult = 40;

    Console.WriteLine($"Actual Result: {actualRestul}, Expected Result: {expctedResult}");

    if (actualRestul == expctedResult)
    {
        Console.WriteLine("Test Passed");
    }
    else
    {
        Console.WriteLine("Test Failed");
    }
}

void AddFunctionShouldReturn50ForInputs25And25()
{
    var actualRestul = Add(25,25);

    var expctedResult = 50;

    Console.WriteLine($"Actual Result: {actualRestul}, Expected Result: {expctedResult}");

    if (actualRestul == expctedResult)
    {
        Console.WriteLine("Test Passed");
    }
    else
    {
        Console.WriteLine("Test Failed");
    }
}


int Add(int a, int b)
{
    return a + b;
}