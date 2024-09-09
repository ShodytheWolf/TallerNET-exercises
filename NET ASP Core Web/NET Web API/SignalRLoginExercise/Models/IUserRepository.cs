namespace SignalRLoginExercise.Models
{
    public interface IUserRepository
    {
        public void Add(User userToAdd);

        public User Get(string hashedPassword);
    }
}
