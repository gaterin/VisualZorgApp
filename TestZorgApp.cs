using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VisualZorgApp
{
    /* 
     Naming convention for Test Methods

     [PascalCase]

        ClassName_MethodName_StateUnderTest_ExpectedBehavior

        Dots used in StateUnderTest are translated to 'dot'
        see example for clear usage


     Example:

        Profile_SetName_SetName_SetNameToPatrick_True
        Profile_SetWeight_SetWeightTo45dot82136_True
         
    */
    [TestClass]
    public class TestZorgApp
    {
        
        [TestMethod]
        public void MyProfile_SetId_SetIdTo25_True()
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
        public void MyProfile_SetName_SetNameToJohn_True()
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
        public void MyProfile_SetSurname_SetSurnameToLewis_True()
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
        public void MyProfile_SetAge_SetAgeTo59_True()
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
        public void MyProfile_SetWeight_SetWeightTo5dot32456_True()
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
        public void MyProfile_SetLength_SetLengthTo1dot72_True()
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
        public void MyProfile_SetRoleId_SetRoleIdTo2_True()
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
        public void MyProfile_SetRoleName_SetRoleNameToZorgverlener_True()
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
        public void MyProfile_GetBmi_ReturnBmi_True()
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
