using Microsoft.VisualStudio.TestTools.UnitTesting;
using VisualZorgApp.ListHandlers;

namespace VisualZorgApp.TestClasses
{
    /* 
     Naming convention for Test Methods

     [PascalCase]

        MethodName_StateUnderTest_ExpectedBehavior

        Dots used in StateUnderTest are translated to 'dot'
        see example for clear usage


     Example:

        SetName_SetName_SetNameToPatrick_True
        SetWeight_SetWeightTo45dot82136_True
         
    */
    [TestClass]
    public class TestMyProfile
    {
        
        [TestMethod]
        public void SetId_SetIdTo25_True()
        {
            //Arrange
            MyProfile myProfile = new MyProfile(1);
            int testInput = 25;

            //Act
            myProfile.SetId(testInput);

            //Assert
            int testOutput = myProfile.GetId();
            Assert.AreEqual(testInput, testOutput);

        }

        [TestMethod]
        public void SetName_SetNameToJohn_True()
        {
            //Arrange
            MyProfile myProfile = new MyProfile(1);
            string testInput = "John";

            //Act
            myProfile.SetName(testInput);

            //Assert
            string testOutput = myProfile.GetName();
            Assert.AreEqual(testInput, testOutput);

        }

        [TestMethod]
        public void SetSurname_SetSurnameToLewis_True()
        {
            //Arrange
            MyProfile myProfile = new MyProfile(1);
            string testInput = "Lewis";

            //Act
            myProfile.SetSurname(testInput);

            //Assert
            string testOutput = myProfile.GetSurname();
            Assert.AreEqual(testInput, testOutput);

        }

        [TestMethod]
        public void SetAge_SetAgeTo59_True()
        {
            //Arrange
            MyProfile myProfile = new MyProfile(1);
            int testInput = 59;

            //Act
            myProfile.SetAge(testInput);

            //Assert
            int testOutput = myProfile.GetAge();
            Assert.AreEqual(testInput, testOutput);

        }

        [TestMethod]
        public void SetWeight_SetWeightTo5dot32456_True()
        {
            //Arrange
            MyProfile myProfile = new MyProfile(1);
            double testInput = 5.32456;

            //Act
            myProfile.SetWeight(testInput);

            //Assert
            double testOutput = myProfile.GetWeight();
            Assert.AreEqual(testInput, testOutput);

        }

        [TestMethod]
        public void SetLength_SetLengthTo1dot72_True()
        {
            //Arrange
            MyProfile myProfile = new MyProfile(1);
            double testInput = 1.72;

            //Act
            myProfile.SetLength(testInput);

            //Assert
            double testOutput = myProfile.GetLength();
            Assert.AreEqual(testInput, testOutput);

        }

        [TestMethod]
        public void SetRoleId_SetRoleIdTo2_True()
        {
            //Arrange
            MyProfile myProfile = new MyProfile(1);
            int testInput = 2;

            //Act
            myProfile.SetRoleId(testInput);

            //Assert
            int testOutput = myProfile.GetRoleId();
            Assert.AreEqual(testInput, testOutput);

        }

        [TestMethod]
        public void SetRoleName_SetRoleNameToZorgverlener_True()
        {
            //Arrange
            MyProfile myProfile = new MyProfile(1);
            string testInput = "Zorgverlener";

            //Act
            myProfile.SetRoleName(testInput);

            //Assert
            string testOutput = myProfile.GetRoleName();
            Assert.AreEqual(testInput, testOutput);

        }

        [TestMethod]
        public void GetBmi_ReturnBmi_True()
        {
            //Arrange
            MyProfile myProfile = new MyProfile(1);
            myProfile.SetLength(1.78);
            myProfile.SetWeight(80.52);

            //Act
           double testOutput = myProfile.GetBmi();

            //Assert
            Assert.AreEqual(25.41, testOutput);

        }





    }
}
