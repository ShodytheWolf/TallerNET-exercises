using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Mvc;
using SignalRLoginExercise.Models;
namespace SignalRLoginExercise.Hubs
{
    public class UserHub : Hub{

        private readonly ILogger<UserHub> _logger;
        private readonly IUserRepository _users;


        public UserHub(ILogger<UserHub> logger, IUserRepository users){
            this._logger = logger;
            this._users = users;
        }


        public void LogUser(string email, string hashedPassword)
        {
            //string stringPassword = hashedPassword.ToString();

            _logger.LogInformation("Estoy dentro de LogUser con creedenciales: " + email + " | " + hashedPassword);

            if (string.IsNullOrEmpty(hashedPassword) || string.IsNullOrEmpty(email)){
                throw new Exception("credenciales no pueden estár null");
            }

            User userToLog = _users.Get(hashedPassword);

            if(userToLog.IsValid(email)){

                string userId = Context.ConnectionId;

                _logger.LogInformation("curl https://localhost:7777/Authenticate/" + userId);
            }
            else
            {
                throw new Exception("Las creedenciales están incorrectas.");
            }

            /* Por como tengo hecho el código, ahora mismo no tiene sentido este if, porqué no estoy cacheando
             * correctamente la posible exepción de que no se encuentre el usuario en el repositorio
            if (userToLog.Equals(null))
            {
                throw new Exception("el usuario no está registrado");
            }
            */

        }
    }
}
