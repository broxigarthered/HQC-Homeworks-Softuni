using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace _01.LinkedQueue
{
    [TestClass]
    public class TestLinkedQueue
    {
        [TestMethod]
        public void Enqueue_ShouldIncrementCount()
        {
           // Arrange
           var queue = new LinkedQueue<int>();
            // Act
            queue.Enqueue(5);
            // Assert
            Assert.AreEqual(1, queue.Count, "Enqueue is working not correctly.");
        }

        [TestMethod]
        public void Dequeue_ShouldDecrementCount()
        {
            var queue = new LinkedQueue<int>();
            queue.Enqueue(5);
            queue.Enqueue(7);
            queue.Dequeue();

            Assert.AreEqual(1, queue.Count, "Dequeue isn't working correctly.");
        }

        [TestMethod]
        public void Clear_ShouldRemove_AllElements()
        {
            var queue = new LinkedQueue<int>();
            int expectedLinkedQueueCount = 0;

            queue.Enqueue(3);
            queue.Enqueue(5);
            queue.Enqueue(7);

            queue.Clear();

            Assert.AreEqual(expectedLinkedQueueCount, queue.Count, "Clear isn't working correctly.");
        }
        
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Peek_ShouldReturnTheHead_Element()
        {
            var queue = new LinkedQueue<int>();
            queue.Peek();
        }
    }
}
