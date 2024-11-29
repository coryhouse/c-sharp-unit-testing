namespace ElevatorProject
{
    public class Elevator
    {
        public int MaxWeightAllowed;
        public int CurrentWeight;        

        /// <summary>
        /// Constructor: Initializes the elevator with the max weight allowed
        /// </summary>
        public Elevator(int maxWeight)
        {
            MaxWeightAllowed = maxWeight;
            CurrentWeight = 0;            
        }

        /// <summary>
        /// Add the weight of the user has entered to the elevator
        /// </summary>
        /// <param name="user"></param>
        public void AddUser(User user)
        {
            CurrentWeight += user.Weight;            
        }

        /// <summary>
        /// Subtract the weight of the user from total current weight
        /// </summary>
        /// <param name="user"></param>
        public void RemoveUser(User user)
        {
            CurrentWeight -= user.Weight;            
            if (CurrentWeight < 0) CurrentWeight = 0;
        }

        /// <summary>
        /// Checks if the max weight allowed in the elevator is reached
        /// </summary>
        /// <returns>true if the elevator has reach the max weight allowed, false instead</returns>
        public bool CheckMaxWeightAllowedReached()
        {
            return CurrentWeight >= MaxWeightAllowed;
        }

        /// <summary>
        /// Check if the user has permission to vip section and there is
        /// someone inside the elevator (Only for one user)
        /// </summary>
        /// <param name="user">User who wants to go to vip section</param>
        /// <returns>true if can go to vip section</returns>
        public bool CanGoToVipSection(User user)
        {
            return CurrentWeight > 0 && user.IsExecutive;
        }
    }

    public class User
    {
        public bool IsExecutive { get; set; }
        public int Weight { get; set; }
    }
}
