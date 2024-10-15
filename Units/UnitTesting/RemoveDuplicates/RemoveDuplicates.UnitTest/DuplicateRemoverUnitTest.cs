using RemoveDuplicates.Logic;

namespace RemoveDuplicates.UnitTest
{
    [TestClass]
    public class DuplicateRemoverUnitTest
    {
        [TestMethod]
        public void ItShouldReturnAnEmptyArray_GivenAnEmptyArray()
        {
            int[] emptyArray = new int[0];
            int[] result = DuplicateRemover.RemoveFrom(emptyArray);
            CollectionAssert.AreEqual(emptyArray, result);
        }


        [TestMethod]
        public void ItShouldReturnAllElements_GivenAllElementsAreDistinct()
        {
            int[] inputArray = [1, 2, 3, 4, 5];
            int[] result = DuplicateRemover.RemoveFrom(inputArray);
            CollectionAssert.AreEqual(inputArray, result);
        }


        [TestMethod]
        public void ItShouldReturnOneElement_GivenTwoEqualElements()
        {
            int[] inputArray = [3, 3];
            int[] expectedResult = [3];
            var result = DuplicateRemover.RemoveFrom(inputArray);
            CollectionAssert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void ItShouldReturnAnArrayContainingOne_GivenAnArrayContainingOne()
        {
            int[] inputArray = new int[] { 1 };
            int[] expectedArray = new int[] { 1 };
            int[] actualArray = DuplicateRemover.RemoveFrom(inputArray);

            CollectionAssert.AreEqual(expectedArray, actualArray);
        }

        [TestMethod]
        public void ItShouldReturnAnArrayContainingOne_GivenAnArrayWithTwoDuplicates()
        {
            int[] inputArray = { 1, 1 };
            int[] expectedArray = [1];
            int[] actualArray = DuplicateRemover.RemoveFrom(inputArray);

            CollectionAssert.AreEqual(expectedArray, actualArray);
        }

        [TestMethod]
        public void ItShouldReturnAnArrayContainingOne_GivenAnArrayWithMultipleDuplicates()
        {
            int[] inputArray = { 1, 1, 1, 1, 1, 1 };
            int[] expectedArray = [1];
            int[] actualArray = DuplicateRemover.RemoveFrom(inputArray);

            CollectionAssert.AreEqual(expectedArray, actualArray);
        }


        [TestMethod]
        public void ItShouldReturnADistinctArray_GivenAnArrayWithDifferentDuplicates()
        {
            int[] inputArray = { 1, 2, 3, 4, 5, 2, 2, 3, 5, 3, 3, 2, 1 };
            int[] expectedArray = [1, 2, 3, 4, 5 ];
            var actualArray = DuplicateRemover.RemoveFrom(inputArray);

            CollectionAssert.AreEqual(expectedArray, actualArray);
        }


        [TestMethod]
        public void ItShouldReturnAreEqual_GivenAnArrayWithUniqueNumbers()
        {
            int[] inputArray = { 1, 2, 3, 4, 5, 6 };
            int[] expectedArray = [1, 2, 3, 4, 5, 6];
            int[] actualArray = DuplicateRemover.RemoveFrom(inputArray);

            CollectionAssert.AreEqual(expectedArray, actualArray);
        }

    }
}
