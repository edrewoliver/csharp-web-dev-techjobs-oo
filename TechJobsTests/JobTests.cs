using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechJobsOO;

namespace TechJobsTests
{
    [TestClass]
    public class JobTests
    {
        [TestMethod]
        public void TestSettingJobId()
        {
            Job testObject1 = new Job();
            Job testObject2 = new Job();

            bool testCondition = testObject1.Id - testObject2.Id == -1;

            Assert.IsTrue(testCondition);
        }

        [TestMethod]
        public void TestJobConstructorSetsAllFields()
        {

            Job fieldsCompleted = new Job()

            {
                Name = "Product Tester",
                EmployerName = new Employer("ACME"),
                EmployerLocation = new Location("Desert"),
                JobType = new PositionType("Quality Control"),
                JobCoreCompetency = new CoreCompetency("Persistence")
            };

            Assert.AreEqual("Product Tester", fieldsCompleted.Name);
            Assert.AreEqual("ACME", fieldsCompleted.EmployerName.Value);
            Assert.AreEqual("Desert", fieldsCompleted.EmployerLocation.Value);
            Assert.AreEqual("Quality Control", fieldsCompleted.JobType.Value);
            Assert.AreEqual("Persistence", fieldsCompleted.JobCoreCompetency.Value);

        }

        [TestMethod]
        public void TestsJobsForEquality()
        {
            Job testObject1 = new Job("Product tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality control"), new CoreCompetency("Persistence"));
            Job testObject2 = new Job("Product tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality control"), new CoreCompetency("Persistence"));

            Assert.IsFalse(testObject1.Equals(testObject2));
        }

        [TestMethod]
        public void TestsforBlankLines()
        {
            Job testObject = new Job("Product tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality control"), new CoreCompetency("Persistence"));
            string newObject = testObject.ToString();

            Assert.IsTrue(newObject.StartsWith("\n"));
            Assert.IsTrue(newObject.EndsWith("\n"));
        }

        [TestMethod]
        public void TestforFieldLabel()
        {
            Job testObject = new Job("Product tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality control"), new CoreCompetency("Persistence"));
            string newObject = testObject.ToString();

            Assert.AreEqual("\nID:5 \nName:Product tester\nEmployer:ACME\nLocation:Desert\nPosition Type:Quality control\nCore Competency:Persistence\n",newObject);
        }
        [TestMethod]
        public void TestErrorMessage()
        {
            Job testObject = new Job("", new Employer("LaunchCode"), new Location("St. Louis"), new PositionType("Front-end developer"), new CoreCompetency("JavaScript"));
            string newObject = testObject.ToString();

            Assert.AreEqual("\nID:1 \nName:Data not available\nEmployer:LaunchCode\nLocation:St. Louis\nPosition Type:Front-end developer\nCore Competency:JavaScript\n", newObject);
        }
    }
}
