using Microsoft.VisualStudio.TestTools.UnitTesting;
using PET.FunctionsLayer;
using PET;
using System;

namespace Tests
{
    [TestClass]
    public class UnitTests
    {
        public Function func = new Function();

        // Testing to see if method that deletes in the functionlayer works by catching the error
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestAgentDeletionFail()
        {
            // making an agent and initiliazing it
            Agents agent = new Agents();

            // giving the agent a value of null to test the catch of the method
            agent = null;

            // Should give an error
            func.DeleteAgent(agent);
        }

        [TestMethod]
        public void TestAddAgent()
        {
            // Arrange 
            int count = func.PersonsList.Count;
            Persons agentPerson = new Persons
            {
                FirstName = "Test",
                LastName = "Tester",
                Height = 184,
                EyeColor = "Green",
                HairColor = "Black",
                Nationalities = new Nationalities
                {
                    // Converting the TextBoxes string input to Integers
                    CountryCode = 268,
                    CprNr = 123,
                    ZipCode = 6464,
                    StreetAdress = "Høje"
                }
            };

            Agents agent = new Agents
            {
                Persons = agentPerson
            };

            // Act 
            func.AddAgent(agent);

            // Assert
            Assert.AreEqual(count + 1, func.PersonsList.Count);
        }
    }
}
