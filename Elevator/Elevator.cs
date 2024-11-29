namespace ElevatorProject
{
    public class Elevator
    {
        public int MaxWeightAllowed;
        public int CurrentWeight;        

        /// <summary>
        /// Constructor: Initializes maxweight and current weight
        /// </summary>
        public Elevator(int MaxHeight)
        {
            MaxWeightAllowed = MaxHeight;
            CurrentWeight = 0;            
        }

        /// <summary>
        /// Add the weight of the user has entered to the elevator
        /// </summary>
        /// <param name="User"></param>
        public void InUser(Employee User)
        {
            CurrentWeight += User.Weight;            
        }

        /// <summary>
        /// Subtract the weight of the user from total current weight
        /// </summary>
        /// <param name="User"></param>
        public void OutUser(Employee User)
        {
            CurrentWeight -= User.Weight;            
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
        /// Check if the employee has permission to vip section and there is
        /// someone inside the elevator (Only for one employee)
        /// </summary>
        /// <param name="User">Employee who wants to go to vip section</param>
        /// <returns>true if can go to vip section, false instead</returns>
        public bool GoToVipSection(Employee User)
        {
            return  CurrentWeight > 0 && User.IsExecutive;
        }
    }

    public class Employee
    {
        public bool IsExecutive { get; set; }
        public int Weight { get; set; }
    }
}
