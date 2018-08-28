namespace TurnManagement.CrossCutting.Strings
{
    public static class ValidationMessages
    {
        #region General Messages

        public const string ValidationOnlyLetters = "Este campo solo admite letras";
        public const string ValidationOnlyNumbres = "Este campo solo admite números (sin espacios)";
        public const string ValidationOnlyAphaNumeric = "Este campo solo admite letras y números";
        public const string AddItemNullIdValidation = "No se puede agregar un objeto con un Id definido";
        public const string UpdateItemIdValidation = "No se puede modificar un objeto con un Id Nulo";
        public const string UnExistentItem = "No existe el ítem solicitado";
        public const string DuplicatedName = "Ya existe un registro con el nombre indicado";
        public const string EmptyCurrencies = "La entidad debe tener al menos una moneda";
        public const string EmptyCurrency = "La moneda no puede ser vacía";
        public const string InvalidDates = "Rango de fechas inválido";
        public const string InvalidOperation = "No se puede procesar la solicitud. Se está intentando realizar una operación inválida";
        
        #endregion

        #region Account Messages

        public const string EmptyUserId = "El Id de usuario no puede ser vacío";
        public const string EmptyName = "El nombre no puede ser vacío";
        public const string EmptyCode = "El código no puede ser vacío";
        public const string EmptyPass = "La contraseña no puede ser vacía";
        public const string EmptyOldPass = "La antigua contraseña no puede ser vacía";
        public const string EmptyNewPass = "La nueva contraseña no puede ser vacía";
        public const string EmptyEmail = "El email no puede ser vacío";
        public const string EmptySubject = "El asunto no puede ser vacío";
        public const string EmptyBody = "El cuerpo del mensaje no puede ser vacío";

        #endregion
    }
}
