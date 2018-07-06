namespace TurnManagement.CrossCutting.Strings
{
    public static class AccountMessages
    {
        #region Propago Messages

        public const string Welcome = "Bienvenido";
        public const string ApplicationName = "Propago";
        public const string PropagoRegister = "Registro Propago";

        #endregion

        #region Login Messages

        public const string InvalidMail = "Email Invalido";
        public const string WrongCredentials = "El usuario o la contraseña son incorrectos";
        public const string InvalidUserPass = "Contraseña inválida";
        public const string LoginProblem = "Ocurrió un inconveniente al intentar loguearse";

        #endregion

        #region User Messages

        public const string ExistingUser = "El usuario '{0}' ya se encuentra registrado";
        public const string ConfirmationMailLink = "Por favor confirme su cuenta Propago haciendo click <a href=\"{0}\">Aquí</a>";
        public const string RegistrationRegards = "Un link de confirmación fue enviado a su casilla de correo. Muchas gracias!";
        public const string UserNotExist = "El usuario no existe. Gracias!";
        public const string UserAlreadyExists = "El usuario ya se encuentra registrado";
        public const string UserAlredyConfirmed = "El usuario ya se encuentra confirmado. Gracias!";
        public const string NonExistentUser = "Este usuario no existe o su email está pendiente de confirmación";
        public const string UserPendingValidation = "La cuenta está pendiente de validación";
        public const string MailRegistrationError = "Error al intentar registrar nuevo usuario | mail: {0}";
        
        #endregion

        #region  Registration Messages

        public const string RegistationProblem = "Ocurrió algún inconveniente durante el registro, por favor intentelo nuevamente más tarde. Gracias!";
        public const string ProblemToSendMail = "Ocurrió algún inconveniente al intentar enviar el mail, por favor intentelo nuevamente más tarde. Gracias!";
        public const string ErrorSendingConfirmationMail = "Error al intentar enviar mail de confirmación: {0}";
        public const string ErrorSendingUserPassChangeMail = "Error al intentar enviar mail de cambio de contraseña a: {0}";
        public const string RegistrationConfirmed = "Su registro Propago ha sido confirmado";
        public const string MailConfirmaed = "Su mail fue confirmado satidfactoriamente";
        public const string InvalidLink = "Link de confirmación inválido";
        public const string InvalidEmail = "Mail Invalido";
        public const string AvailableEmail = "Mail Disponible";

        #endregion

        #region  Change UserPass Messages

        public const string ChangeUserPass = "Recuperación de Contraseña";
        public const string LinkToChangeUserPass = "Por favor cambie su contraseña Propago haciendo click <a href=\"{0}\">Aquí</a>";
        public const string ForgotUserPass = "Un link de recuperación de clave fue enviado a su casilla de correo";
        public const string PassLengthError = "La contraseña debe tener al menos 8 caracteres de longitud";
        public const string NameLengthError = "El nombre debe tener al menos 4 caracteres de longitud";
        public const string UserPassCahnged = "Su contraseña se cambió satisfactoriamente";
        public const string UserPassCantCahnge = "Ocurrió algún inconveniente al intentar cambiar la contraseña";

        #endregion
    }
}
