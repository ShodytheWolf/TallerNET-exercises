namespace SignalRLoginExercise.Models
{
    public class User{

        public string Email { get; set; }
        public string Password { get; set; }

        public User() { }

        public User(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public bool IsValid(string email){

            if (this.Email.Equals(email)){
                return true;
            }
            else{
                return false;
            }
        }
    }
}
