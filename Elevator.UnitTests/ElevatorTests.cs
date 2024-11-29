namespace ElevatorProject.UnitTests
{
    [TestClass]
    public class ElevatorTests
    {
        [TestMethod]
        public void IsMaxWeightAllowedReached_EmptyElevator_ReturnFalse()
        {
            // Arrange
            var myElevator = new Elevator(100);

            // Act
            var result = myElevator.IsMaxWeightAllowedReached();

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsMaxWeightAllowedReached_80MaxWeightWith80WeightUser_ReturnTrue()
        {
            // Arrange
            var myElevator = new Elevator(80);
            // user 1
            var Programmer = new User();
            Programmer.Weight = 80;
            
            // Act
            //adding users to the elevator
            myElevator.AddUser(Programmer);          
            var result = myElevator.IsMaxWeightAllowedReached();

            // Assert            
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsMaxWeightAllowedReached_100MaxWeightWithSeveralUsers_ReturnTrue()
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
            myElevator.AddUser(director);
            myElevator.AddUser(producer);
            var result = myElevator.IsMaxWeightAllowedReached();

            // Assert            
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsMaxWeightAllowedReached_100MaxWeightWithSeveralUsersButSubtractingOne_ReturnFalse()
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
            elevator.AddUser(director);
            elevator.AddUser(producer);
            // removing one
            elevator.RemoveUser(producer);
            var result = elevator.IsMaxWeightAllowedReached();

            // Assert            
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void RemoveUser_RemovingSeveralUsersWhoAreNotInTheElevator_CurrentWeightIs0()
        {
            // Arrange
            var elevator = new Elevator(100);
            // user 1
            var artist = new User();
            artist.Weight = 75;            
            // user 2
            var gameDesigner = new User();
            gameDesigner.Weight = 85;

            // Act
            // removing users who aren't inside the elevator
            elevator.RemoveUser(artist);
            elevator.RemoveUser(gameDesigner);
          
            // Assert            
            Assert.AreEqual(elevator.CurrentWeight, 0);
        }

        [TestMethod]
        public void CanGoToVipSection_UserWithVipPass_ReturnTrue()
        {
            // Arrange
            var myElevator = new Elevator(100);
            // user 
            var ceo = new User();
            ceo.Weight = 90;
            ceo.IsExecutive = true;

            // Act
            // adding user inside the elevator, and go to vip section
            myElevator.AddUser(ceo);
            var result = myElevator.CanGoToVipSection(ceo);            

            // Assert            
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CanGoToVipSection_UserWithoutVipPass_ReturnFalse()
        {
            // Arrange
            var elevator = new Elevator(100);
            // user 
            var guard = new User();
            guard.Weight = 90;            

            // Act
            // adding user inside the elevator, and go to vip section
            elevator.AddUser(guard);
            var result = elevator.CanGoToVipSection(guard);

            // Assert            
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CanGoToVipSection_NoUsersInElevator_ReturnFalse()
        {
            // Arrange
            var myElevator = new Elevator(100);
           
            // Act
            // go to vip section            
            var result = myElevator.CanGoToVipSection(new User());

            // Assert            
            Assert.IsFalse(result);
        }

    }
}
