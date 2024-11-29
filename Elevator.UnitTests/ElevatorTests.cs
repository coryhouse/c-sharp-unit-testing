namespace ElevatorProject.UnitTests
{
    [TestClass]
    public class ElevatorTests
    {
        [TestMethod]
        public void CheckMaxWeightAllowedReached_EmptyElevator_ReturnFalse()
        {
            // Arrange
            var myElevator = new Elevator(100);

            // Act
            var result = myElevator.CheckMaxWeightAllowedReached();

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckMaxWeightAllowedReached_80MaxWeightWith80WeightUser_ReturnTrue()
        {
            // Arrange
            var myElevator = new Elevator(80);
            // user 1
            var Programmer = new User();
            Programmer.Weight = 80;
            
            // Act
            //adding users to the elevator
            myElevator.InUser(Programmer);          
            var result = myElevator.CheckMaxWeightAllowedReached();

            // Assert            
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckMaxWeightAllowedReached_100MaxWeightWithSeveralUsers_ReturnTrue()
        {
            // Arrange
            var myElevator = new Elevator(100);
            // user 1
            var director = new User();
            director.Weight = 75;
            director.IsExecutive = true;
            // user 2
            var producer = new User();
            producer.Weight = 85;

            // Act
            //adding users to the elevator
            myElevator.InUser(director);
            myElevator.InUser(producer);
            var result = myElevator.CheckMaxWeightAllowedReached();

            // Assert            
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckMaxWeightAllowedReached_100MaxWeightWithSeveralUsersButSubtractingOne_ReturnFalse()
        {
            // Arrange
            var elevator = new Elevator(100);
            // user 1
            var director = new User();
            director.Weight = 75;
            director.IsExecutive = true;
            // user 2
            var producer = new User();
            producer.Weight = 85;

            // Act
            //adding users to the elevator
            elevator.InUser(director);
            elevator.InUser(producer);
            // removing one
            elevator.OutUser(producer);
            var result = elevator.CheckMaxWeightAllowedReached();

            // Assert            
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void OutUser_SubtractingSeveralUsersWhoAreNotInTheElevator_CurrentWeightResult0()
        {
            // Arrange
            var myElevator = new Elevator(100);
            // user 1
            var Artist = new User();
            Artist.Weight = 75;            
            // user 2
            var GameDesigner = new User();
            GameDesigner.Weight = 85;

            // Act
            // removing users who aren't inside the elevator
            myElevator.OutUser(Artist);
            myElevator.OutUser(GameDesigner);
          
            // Assert            
            Assert.AreEqual(myElevator.CurrentWeight, 0);
        }

        [TestMethod]
        public void GoToVipSection_UserWithVipPass_ReturnTrue()
        {
            // Arrange
            var myElevator = new Elevator(100);
            // user 
            var ceo = new User();
            ceo.Weight = 90;
            ceo.IsExecutive = true;

            // Act
            // adding user inside the elevator, and go to vip section
            myElevator.InUser(ceo);
            var result = myElevator.GoToVipSection(ceo);            

            // Assert            
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GoToVipSection_UserWithoutVipPass_ReturnFalse()
        {
            // Arrange
            var myElevator = new Elevator(100);
            // user 
            var guard = new User();
            guard.Weight = 90;            

            // Act
            // adding user inside the elevator, and go to vip section
            myElevator.InUser(guard);
            var result = myElevator.GoToVipSection(guard);

            // Assert            
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GoToVipSection_ThereAreNotUserInTheElevator_ReturnFalse()
        {
            // Arrange
            var myElevator = new Elevator(100);
           
            // Act
            // go to vip section            
            var result = myElevator.GoToVipSection(new User());

            // Assert            
            Assert.IsFalse(result);
        }

    }
}
