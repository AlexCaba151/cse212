using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add three items with different priorities.
    // Expected Result: The item with the highest priority is removed first.
    // Defect(s) Found: The original Dequeue method did not check the last item in the queue,
    // so a highest-priority item in the last position could be missed.
    public void TestPriorityQueue_HighestPriority()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("High", 5);
        priorityQueue.Enqueue("Medium", 3);

        Assert.AreEqual("High", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Add multiple items with the same highest priority.
    // Expected Result: The first item added with the highest priority is removed first.
    // Defect(s) Found: The original code used >= when comparing priorities,
    // which caused the later item with the same priority to be selected first.
    public void TestPriorityQueue_SamePriorityFIFO()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("First", 5);
        priorityQueue.Enqueue("Second", 5);
        priorityQueue.Enqueue("Third", 3);

        Assert.AreEqual("First", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Add three items with different priorities and dequeue them one at a time.
    // Expected Result: Items are removed according to highest priority and the removed
    // item is no longer in the queue.
    // Defect(s) Found: The original code returned the selected item without removing it
    // from the queue.
    public void TestPriorityQueue_RemovesItem()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("First", 1);
        priorityQueue.Enqueue("Second", 3);
        priorityQueue.Enqueue("Third", 2);

        Assert.AreEqual("Second", priorityQueue.Dequeue());
        Assert.AreEqual("Third", priorityQueue.Dequeue());
        Assert.AreEqual("First", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Attempt to dequeue from an empty queue.
    // Expected Result: An InvalidOperationException is thrown with the message
    // "The queue is empty."
    // Defect(s) Found: No defects found. The test passed.
    public void TestPriorityQueue_Empty()
    {
        var priorityQueue = new PriorityQueue();

        var exception = Assert.ThrowsException<InvalidOperationException>(
            () => priorityQueue.Dequeue());

        Assert.AreEqual("The queue is empty.", exception.Message);
    }
}