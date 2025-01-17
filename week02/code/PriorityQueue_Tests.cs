using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: The goal is to test whether an item placed in the queue goes to the end of it.
    //To do this, we will place two items with the same priority.
    // Expected Result: The system will put the item in the queue's end.
    // Defect(s) Found: 
    /*
        The system removed the first element from the stack correctly, apparently. But when it tried to remove the second and last element, it brought back not the second element, but the first element again.
        Apparently it did not remove the first element from the queue.
    */
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        
        priorityQueue.Enqueue("Tim",0);
        priorityQueue.Enqueue("Sue",0);

        var person = priorityQueue.Dequeue();

        Assert.AreEqual("Tim", person);

        person = priorityQueue.Dequeue();

        Assert.AreEqual("Sue", person);
    }

    [TestMethod]
    // Scenario: Removing the item with the highest priority and return its value.
    // Expected Result: Remove exactly the highest priority item.
    // Defect(s) Found: None
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Tim",0);
        priorityQueue.Enqueue("Sue",2);
        priorityQueue.Enqueue("Bob",3);
        priorityQueue.Enqueue("Norman",1);
        var person = priorityQueue.Dequeue();

        Assert.AreEqual("Bob", person);

    }

    // Add more test cases as needed below.

    [TestMethod]
    // Scenario: Removing the first item with the highest priority and return its value.
    // Expected Result: Remove exactly the first highest priority item.
    // Defect(s) Found: None
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Tim",0);
        priorityQueue.Enqueue("Sue",2);
        priorityQueue.Enqueue("Bob",3);
        priorityQueue.Enqueue("Norman",1);
        priorityQueue.Enqueue("Chris",3);

        Debug.WriteLine(priorityQueue.ToString());
        var person = priorityQueue.Dequeue();
        Debug.WriteLine(priorityQueue.ToString());
        Assert.AreEqual("Bob", person);

    }

    [TestMethod]
    // Scenario: Testing if removing a item in a empty queue will throw an exception.
    // Expected Result: The system must throw an exception
    // Defect(s) Found: System throw an exception, but the test code stoped and registered an test failure.
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();
        //var person = priorityQueue.Dequeue();
        var ex = Assert.ThrowsException<InvalidOperationException>(
            () => priorityQueue.Dequeue()); 
            Assert.AreEqual(ex.Message, "The queue is empty.");

    }
}