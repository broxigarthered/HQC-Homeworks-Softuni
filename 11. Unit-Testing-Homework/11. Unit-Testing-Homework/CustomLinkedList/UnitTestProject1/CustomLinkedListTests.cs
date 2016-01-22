using System;
using CustomLinkedList;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class CustomLinkedListTests
    {
        private DynamicList<int> testList;

        [TestInitialize]
        public void SetUp()
        {
            testList = new DynamicList<int>();
        }

        [TestMethod]
        public void Add_ShouldAddAnElementToTheList()
        {
            var myLinkedList = new DynamicList<int>();
            myLinkedList.Add(15);
            Assert.AreEqual(15,myLinkedList[0], "The Add method is not working correctly.");
        }

        [TestMethod]
        public void Add_ShouldIncrementTheCount()
        {
            var linkedList = new DynamicList<int>();

            linkedList.Add(5);
            linkedList.Add(4);
            linkedList.Add(3);

            Assert.AreEqual(3, linkedList.Count, "The count is not being incremented within the Dynamic List.");
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentOutOfRangeException))]
        public void RemoveAt_ShouldThrowAnException_WhenTheIndex_IsOutOfRange()
        {
            var dynamicList = new DynamicList<string>();
            dynamicList.Add("Kori");
            dynamicList.Add("Moti4kata");
            dynamicList.Add("allahuakbar");

            dynamicList.RemoveAt(4);
        }

        [TestMethod]
        public void RemoveAt_ShouldRemoveAnElementAt_GivenPosition_AndTheCount_ShouldBeReduced_By_One()
        {
            var dynamicList = new DynamicList<string>();
            var expectedLength = 2;

            dynamicList.Add("Kori");
            dynamicList.Add("Moti4kata");
            dynamicList.Add("allahuakbar");

            dynamicList.RemoveAt(2);

            Assert.AreEqual(expectedLength, dynamicList.Count, "The method .RemoveAt isn't decrementing the list length correctly. The dynamicList count is {0}", dynamicList.Count);
        }

        [TestMethod]
        public void RemoveAt_ShouldReturnTheRemovenElement()
        {
            var dynamicList = new DynamicList<string>();

            dynamicList.Add("Kori");
            dynamicList.Add("Moti4kata");
            dynamicList.Add("allahuakbar");

            var removedElement = dynamicList.RemoveAt(2);

            Assert.AreEqual(removedElement, "allahuakbar", "The method .RemoveAt isn't removing the element properly");
        }

        [TestMethod]
        public void Remove_ShouldReturnMinusOneWhenTheElementIsNotFound()
        {
            var dynamicList = new DynamicList<string>();
            dynamicList.Add("Kori");
            dynamicList.Add("Moti4kata");
            dynamicList.Add("allahuakbar");

            var returnedValue = dynamicList.Remove("Kiro");
            Assert.AreEqual(-1,returnedValue, "The method .Remove isn't removing the element properly.");
        }

        [TestMethod]
        public void Remove_ShouldRemoveTheElement_WhenCalled()
        {
            var dynamicList = new DynamicList<int>();
            dynamicList.Add(1);
            dynamicList.Add(5);

            dynamicList.Remove(5);

            Assert.AreEqual(dynamicList.Count, 1, "The method .Remove isn't removing the element properly.");
        }

        [TestMethod]
        public void IndexOf_ShouldReturnMinusOneWhenTheElementIs_NotFound()
        {
            var dynamicList = new DynamicList<int>();
            dynamicList.Add(5);
            dynamicList.Add(6);

            var returnedValue = dynamicList.IndexOf(3);
            Assert.AreEqual(-1, returnedValue, "The method .IndexOf isn't working correctly.");
        }

        [TestMethod]
        public void Contains_ShouldReturn_True_WhenItemExists()
        {
            var dynamicList = new DynamicList<int>();
            dynamicList.Add(5);
            dynamicList.Add(6);
            dynamicList.Add(12);

            var doesContain = dynamicList.Contains(6);
            Assert.AreEqual(true, doesContain, "The method .Contains isn't working correctly.");
        }
    }
}
