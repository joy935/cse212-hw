using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Create a queue with the following people and priorities:
    // Sue, 2; Bob, 16; Tim, 5.
    // Expected Result: Bob, Tim, Sue, 
    // Defect(s) Found: Dequeue didn't have a function that would remove the item from the queue. 
    // Added _queue.RemoveAt(highPriorityIndex) to remove the item from the queue.
    public void TestPriorityQueue_EnqueueDequeue()
    {
        var sue = new PriorityItem("Sue", 2);
        var bob = new PriorityItem("Bob", 16);
        var tim = new PriorityItem("Tim", 5);

        PriorityItem[] expectedResult = { bob, tim, sue };

        var pq = new PriorityQueue();
        pq.Enqueue(bob.Value, bob.Priority);
        pq.Enqueue(tim.Value, tim.Priority);
        pq.Enqueue(sue.Value, sue.Priority);

        int i = 0;
        while (i < expectedResult.Length)
        {
            var expectedValue = expectedResult[i];
            var actualValue = pq.Dequeue(); 

            Assert.AreEqual(expectedValue.Value, actualValue);
            i++;
        }
    }

    [TestMethod]
    // Scenario: Create a queue with the following people and priorities:
    // Lui, 1; Sue, 2; Bob, 16; Tim, 2.
    // Expected Result: Bob, Sue, Tim
    // Defect(s) Found: 
    public void TestPriorityQueue_SamePriority()
    {
        var lui = new PriorityItem("Lui", 1);
        var sue = new PriorityItem("Sue", 2);
        var bob = new PriorityItem("Bob", 16);
        var tim = new PriorityItem("Tim", 2);

        PriorityItem[] expectedResult = { bob, sue, tim, lui }; 

        var pq = new PriorityQueue();
        pq.Enqueue("Lui", 1);
        pq.Enqueue("Sue", 2);
        pq.Enqueue("Bob", 16);
        pq.Enqueue("Tim", 2);

        int i = 0;
        while (i < expectedResult.Length) {
            Console.WriteLine(pq.ToString());
            var expectedValue = expectedResult[i];
            Console.WriteLine("Expected: " +expectedValue);
            var actualValue = pq.Dequeue();
            Console.WriteLine("Actual: " +actualValue);

            Assert.AreEqual(expectedValue.Value, actualValue);
            i++;
        }
    }

    [TestMethod]
    // Scenario: Create a queue with similar priorities and dequeue until the queue is empty:
    // Tim, 10; Sue, 2; Bob, 16; Lui, 2; Leo, 16;
    // Expected Result: Bob, Leo, Tim, Sue, Lui
    // Defect(s) Found: None
    public void TestPriorityQueue_SamePriorities()
    {
        var tim = new PriorityItem("Tim", 10);
        var sue = new PriorityItem("Sue", 2);
        var bob = new PriorityItem("Bob", 16);
        var lui = new PriorityItem("Lui", 2);
        var leo = new PriorityItem("Leo", 16);

        PriorityItem[] expectedResult = { bob, leo, tim, sue, lui };

        var pq = new PriorityQueue();
        pq.Enqueue("Tim", 10);
        pq.Enqueue("Sue", 2);
        pq.Enqueue("Bob", 16);
        pq.Enqueue("Lui", 2);
        pq.Enqueue("Leo", 16);

        int i = 0;
        while (i < expectedResult.Length) {
            var expectedValue = expectedResult[i];
            var actualValue = pq.Dequeue();

            Assert.AreEqual(expectedValue.Value, actualValue);
            i++;
        }
    }

    [TestMethod]
    // Scenario: Try to dequeue from an empty queue.
    // Expected Result: Exception thrown with message "The queue is empty."
    // Defect(s) Found: None
    public void TestPriorityQueue_EmptyQueue()
    {
        var pq = new PriorityQueue();
        
        try {
            pq.Dequeue();
            Assert.Fail("Exception not thrown.");

        } catch (InvalidOperationException e) {
            Assert.AreEqual("The queue is empty.", e.Message);
        } catch (AssertFailedException) {
            throw;
        } catch (Exception e) {
            Assert.Fail("Wrong exception thrown.", e.GetType(), e.Message);
        }
    }
}