// Demonstration of Garbage Collection

void DoSomeBigOperation()
{
    byte[] myArray = new byte[1000000];

    Console.WriteLine($"Allocated memory is: {GC.GetTotalMemory(false)}");
    Console.ReadLine();
}

// Retrieve and print the total memory allocated
Console.WriteLine($"Allocated memory is: {GC.GetTotalMemory(false)}");
Console.ReadLine();

// Call the function that allocates a large memory chunck
DoSomeBigOperation();

// After the function completes, force a Garbage Collection
GC.Collect();

// Retrieve and print the updated total memory amount
Console.WriteLine($"Allocated memory is: {GC.GetTotalMemory(false)}");
Console.ReadLine();
