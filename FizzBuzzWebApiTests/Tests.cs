using Microsoft.VisualStudio.TestTools.UnitTesting;
using FizzBuzzWebApi.Controllers;
using FizzBuzzWebApi.Models;
using System.Collections.Generic;
using FizzBuzzWebApi;

namespace FizzBuzzWebApiTests
{
    [TestClass]
    public class Tests
    {
        
        [TestMethod]
        public void InputEmptyStringReturnsEmplyList()
        {
            FizzBuzzController fizzBuzzController = new FizzBuzzController();
            List<FizzBuzz> output = fizzBuzzController.Process("");
            Assert.IsTrue(output.Count == 0);
        }

        [TestMethod]
        public void InputInvalidDataInStringReturnsInvalidItemInOutput()
        {
            FizzBuzzController fizzBuzzController = new FizzBuzzController();
            List<FizzBuzz> output = fizzBuzzController.Process("Test");
            Assert.IsTrue(output.Count == 1);
            Assert.IsTrue(output[0].ProcessedInput == Constants.InvalidItem);
        }

        [TestMethod]
        public void InputMultipleOfThreeReturnsFizzOutput()
        {
            FizzBuzzController fizzBuzzController = new FizzBuzzController();
            List<FizzBuzz> output = fizzBuzzController.Process("3");
            Assert.IsTrue(output.Count == 1);
            Assert.IsTrue(output[0].ProcessedInput == Constants.MultipleOfThree);
        }

        [TestMethod]
        public void InputMultipleOfFiveReturnsBuzzOutput()
        {
            FizzBuzzController fizzBuzzController = new FizzBuzzController();
            List<FizzBuzz> output = fizzBuzzController.Process("50");
            Assert.IsTrue(output.Count == 1);
            Assert.IsTrue(output[0].ProcessedInput == Constants.MultipleOfFive);
        }

        [TestMethod]
        public void InputMultipleOfThreeAndFiveReturnsBuzzFizzOutput()
        {
            FizzBuzzController fizzBuzzController = new FizzBuzzController();
            List<FizzBuzz> output = fizzBuzzController.Process("15");
            Assert.IsTrue(output.Count == 1);
            Assert.IsTrue(output[0].ProcessedInput == Constants.MultipleOfThreeAndFive);
        }

        [TestMethod]
        public void InputNullValueReturnsEmptyListInOutput()
        {
            FizzBuzzController fizzBuzzController = new FizzBuzzController();
            List<FizzBuzz> output = fizzBuzzController.Process(null);
            Assert.IsTrue(output.Count == 0);            
        }

        [TestMethod]
        public void InputMultipleValuesReturnsListWithEvaluatedValues()
        {
            FizzBuzzController fizzBuzzController = new FizzBuzzController();
            List<FizzBuzz> output = fizzBuzzController.Process("1,3,5,,15,A,23");
            Assert.IsTrue(output.Count == 7);
            Assert.IsTrue(output[0].ProcessedInput == $"Divided 1 by 3, Divided 1 by 5");
            Assert.IsTrue(output[1].ProcessedInput == Constants.MultipleOfThree);
            Assert.IsTrue(output[2].ProcessedInput == Constants.MultipleOfFive);
            Assert.IsTrue(output[3].ProcessedInput == Constants.InvalidItem);
            Assert.IsTrue(output[4].ProcessedInput == Constants.MultipleOfThreeAndFive);
            Assert.IsTrue(output[5].ProcessedInput == Constants.InvalidItem);
            Assert.IsTrue(output[6].ProcessedInput == $"Divided 23 by 3, Divided 23 by 5");

        }
    }
}
