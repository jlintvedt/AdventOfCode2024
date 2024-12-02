using AdventOfCodeTests.InputHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static AdventOfCode.Day02.RednoseReports;

namespace AdventOfCodeTests
{
    [TestClass]
    public class Day02Tests
    {
        private string input_puzzle;
        private readonly int day = 02;

        [TestInitialize]
        public void LoadInput()
        {
            // Load input
            input_puzzle = InputProvider.GetInput(AdventOfCode.Const.Year, day);
        }

        [TestMethod]
        public void Example_Puzzle1()
        {
            // Act
            var result = AdventOfCode.Day02.Puzzle1(InputProvider.GetExample(AdventOfCode.Const.Year, day, exampleNum: 1));

            // Assert
            Assert.AreEqual($"2", result);
        }

        [TestMethod]
        public void Puzzle1()
        {
            // Act
            var result = AdventOfCode.Day02.Puzzle1(input_puzzle);

            // Assert
            Assert.AreEqual($"510", result);
        }

        [TestMethod]
        public void Example_Puzzle2()
        {
            // Act
            var result = AdventOfCode.Day02.Puzzle2(InputProvider.GetExample(AdventOfCode.Const.Year, day, exampleNum: 1));

            // Assert
            Assert.AreEqual($"4", result);
        }

        [TestMethod]
        public void Puzzle2()
        {
            // Act
            var result = AdventOfCode.Day02.Puzzle2(input_puzzle);

            // Assert
            Assert.AreEqual($"553", result);
        }

        [TestMethod]
        public void Report_IsSafe()
        {
            // Arrange & Assert
            var usePD = false;
            Assert.IsTrue((new Report("7 6 4 2 1", usePD)).IsSafe);
            Assert.IsTrue((new Report("1 3 6 7 9", usePD)).IsSafe);
        }

        [TestMethod]
        public void Report_IsUnsafe()
        {
            // Arrange & Assert
            var usePD = false;
            Assert.IsFalse((new Report("1 2 7 8 9", usePD)).IsSafe);
            Assert.IsFalse((new Report("9 7 6 2 1", usePD)).IsSafe);
            Assert.IsFalse((new Report("1 3 2 4 5", usePD)).IsSafe);
            Assert.IsFalse((new Report("8 6 4 4 1", usePD)).IsSafe);

        }

        [TestMethod]
        public void Report_UseProblemDampener_IsSafe()
        {
            // Arrange & Assert
            var usePD = true;
            Assert.IsTrue((new Report("7 6 4 2 1", usePD)).IsSafe);
            Assert.IsTrue((new Report("1 3 2 4 5", usePD)).IsSafe);
            Assert.IsTrue((new Report("8 6 4 4 1", usePD)).IsSafe);
            Assert.IsTrue((new Report("1 3 6 7 9", usePD)).IsSafe);

            Assert.IsTrue((new Report("10 2 3 4 5", usePD)).IsSafe);
            Assert.IsTrue((new Report("1 10 3 4 5", usePD)).IsSafe);
            Assert.IsTrue((new Report("1 2 10 4 5", usePD)).IsSafe);
            Assert.IsTrue((new Report("1 2 3 10 5", usePD)).IsSafe);
            Assert.IsTrue((new Report("1 2 3 4 10", usePD)).IsSafe);

            Assert.IsTrue((new Report("3 2 3 4 5", usePD)).IsSafe);
            Assert.IsTrue((new Report("5 2 6 7 8", usePD)).IsSafe);
            Assert.IsTrue((new Report("5 6 4 3 2", usePD)).IsSafe);
            Assert.IsTrue((new Report("1 2 1 4 5", usePD)).IsSafe);

            Assert.IsTrue((new Report("5 6 4 8 9", usePD)).IsSafe);
            Assert.IsTrue((new Report("5 6 7 4 9", usePD)).IsSafe);
            Assert.IsTrue((new Report("5 6 3 2 1", usePD)).IsSafe);
        }

        [TestMethod]
        public void Report_UseProblemDampener_IsUnsafe()
        {
            // Arrange
            var usePD = true;
            Assert.IsFalse((new Report("1 2 7 8 9", usePD)).IsSafe);
            Assert.IsFalse((new Report("9 7 6 2 1", usePD)).IsSafe);

            Assert.IsFalse((new Report("10 2 7 4 5", usePD)).IsSafe);
            Assert.IsFalse((new Report("10 20 30 40 50", usePD)).IsSafe);
            Assert.IsFalse((new Report("1 2 1 2 1", usePD)).IsSafe);

            Assert.IsFalse((new Report("1 2 3 7 8", usePD)).IsSafe);
            Assert.IsFalse((new Report("7 8 3 2 1", usePD)).IsSafe);
            Assert.IsFalse((new Report("1 2 3 2 1", usePD)).IsSafe);
            Assert.IsFalse((new Report("10 2 3 4 3", usePD)).IsSafe);
            Assert.IsFalse((new Report("10 5 4 6 2", usePD)).IsSafe);
        }
    }
}
