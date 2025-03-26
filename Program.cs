// See https://aka.ms/new-console-template for more information
using Cleverence;
using Cleverence.Task3;
using System.Diagnostics;


#region Task1

void TestTask1()
{
    string[] input = new string[10]
    {
    "aaabbcccdde",
    "aattw",
    "r1s2",
    "",
    "ggggggg",
    "e",
    "oit",
    "wweerr",
    "aa",
    "gggggggg"
    };


    foreach (string s in input)
    {
        var compressed = Task1.Compress(s);
        var decompressed = Task1.Decompress(compressed);

        Console.WriteLine($"Input: {s}, Compressed: {compressed}, Decompressed: {decompressed}");
    }
}

//TestTask1();

#endregion


#region Task2

void TestTask2()
{

    Task2Server.InitServer();

    int threadsCount = 6;
    int testsCount = 5;
    Task[] tasks = new Task[threadsCount];

    Stopwatch stopwatch = Stopwatch.StartNew();

    for (int i = 0; i < threadsCount / 2; i++)
    {
        tasks[i] = Task.Run(() =>
        {
            for (int j = 0; j < testsCount; j++)
            {
                Thread.Sleep(10);
                Console.WriteLine($"Start READ: Thread {Thread.CurrentThread.ManagedThreadId}. Time: {stopwatch.ElapsedMilliseconds} ms, {stopwatch.ElapsedTicks} ticks");
                int count = Task2Server.GetCount();
                Console.WriteLine($"End READ: {count}. Thread {Thread.CurrentThread.ManagedThreadId}. Time: {stopwatch.ElapsedMilliseconds} ms, {stopwatch.ElapsedTicks} ticks");

            }
        });
    }

    for (int i = threadsCount / 2; i < threadsCount; i++)
    {
        tasks[i] = Task.Run(() =>
        {
            for (int j = 0; j < 3; j++)
            {
                Thread.Sleep(20);
                Console.WriteLine($"Start WRITE: Thread {Thread.CurrentThread.ManagedThreadId}. Time: {stopwatch.ElapsedMilliseconds} ms, {stopwatch.ElapsedTicks} ticks");
                Task2Server.AddToCount(1);
                Console.WriteLine($"End WRITE: +1. Thread {Thread.CurrentThread.ManagedThreadId}. Time: {stopwatch.ElapsedMilliseconds} ms,  {stopwatch.ElapsedTicks}  ticks");

            }
        });
    }

    Task.WaitAll(tasks);
    stopwatch.Stop();
    Console.WriteLine($"Result count: {Task2Server.GetCount()}, Time: {stopwatch.ElapsedMilliseconds} ms, {stopwatch.ElapsedTicks} ticks");

    Task2Server.DisposeServer();
}

//TestTask2();

#endregion


#region Task3

//string inputFilePath1 = "E:\\Sobesedovaniya\\Cleverence\\Cleverence\\Task3\\Resources\\input1.txt";
//string inputFilePath2 = "E:\\Sobesedovaniya\\Cleverence\\Cleverence\\Task3\\Resources\\input2.txt";
//string inputFilePath3 = "E:\\Sobesedovaniya\\Cleverence\\Cleverence\\Task3\\Resources\\input3Problems.txt";
string inputFilePath4 = "E:\\Sobesedovaniya\\Cleverence\\Cleverence\\Task3\\Resources\\input4.txt";

var converter = new LogsConverter(outputFilePath: "E:\\Sobesedovaniya\\Cleverence\\Cleverence\\Task3\\Resources\\output.txt",
                                  outProblemsFilePath: "E:\\Sobesedovaniya\\Cleverence\\Cleverence\\Task3\\Resources\\problems.txt");

//converter.ProcessConvertation(inputFilePath1);
//converter.ProcessConvertation(inputFilePath2);
//converter.ProcessConvertation(inputFilePath3);
converter.ProcessConvertation(inputFilePath4);

#endregion