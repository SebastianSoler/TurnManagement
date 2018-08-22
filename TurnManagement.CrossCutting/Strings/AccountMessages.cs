namespace TurnManagement.CrossCutting.Strings
{
    public static class AccountMessages
    {
        #region Turn Management Messages

        public const string Welcome = "Bienvenido";
        public const string ApplicationName = "Turn Management";
        public const string AdminInfo = "\n\nSoler Sebastian | (2257)-664064";

        #endregion

        #region Login Messages

        public const string ForgetPassMessage = "Para realizar el blanqueo de contraseña, contáctese con el Administrador del sistema.";
        public const string CorrectCredentials = "Ingreso exitoso!\n\nBienvenido!";
        public const string WrongCredentials = "El usuario o la contraseña son incorrectos";
        public const string LoginProblem = "Ocurrió un inconveniente al intentar loguearse";
        public const string ForgetPassContactInfo = "Confirme si desea que enviemos un mail para realizar blanqueo de Contraseña.";
        public const string ForgotUserPass = "Un link de recuperación de clave fue enviado a su casilla de correo";
        public const string ProblemToSendMail = "Ocurrió algún inconveniente al intentar enviar el mail, por favor intentelo nuevamente más tarde. Gracias!";
        public const string MailConfirmaed = "El mail fue enviado satisfactoriamente!";
        public const string UserPassChanged = "Su contraseña se cambió satisfactoriamente";

        #endregion
    }
}
