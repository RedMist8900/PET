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
        public void TestAgenDeletionFail()
        {
            // making an agent and initiliazing it
            Agents agent = new Agents();

            // giving the agent a value of null to test the catch of the method
            agent = null;

            // Should give an error
            func.DeleteAgent(agent);
        }
    }
}
