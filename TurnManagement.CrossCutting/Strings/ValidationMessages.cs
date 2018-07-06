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

        #region Person Messages

        public const string EmptySocialReason = "La razón social no puede ser vacía";
        public const string DuplicatedDni = "Ya existe un registro con el DNI indicado";
        public const string DuplicatedPassport = "Ya existe un registro con el Pasaporte indicado";
        public const string DuplicatedSocialReason = "Ya existe un registro con la razón social indicada";
        public const string DuplicatedCuit = "Ya existe un registro con la CUIT indicada";
        public const string InvalidCuit = "Cuit Inválida";
        public const string EmptyPersonIds = "La persona debe tener al menos un campo Identificador (Dni/Pasaporte/Cuit)";
        public const string EmptyPersonType = "El tipo de persona no puede ser vacío";
        public const string EmptyCuit = "La Cuit no puede ser vacía";
        public const string EmptyDni = "El Dni no puede ser vacío";
        public const string EmptyFiscalCondition = "La condición fiscal no puede ser vacía";
        public const string EmptyPersonRol = "La entidad debe tener al menos un Rol";
        public const string InvalidPersonTypeVsCuit = "El tipo de persona no es consistente con el Cuit";
        public const string InvalidCantValue = "La variable cant debe tener un valor";

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

        #region Portfolio Messages

        public const string EmptyOwner = "El propietario no puede ser vacio";
        public const string InvalidPortfolioType = "Tipo de cartera inválido";
        public const string EmptyIcon = "El ícono no puede ser vacio";
        public const string EmptyBankAccountType = "El tipo de cuenta no puede ser vacía";
        public const string EmptyBank = "El banco no puese ser vacío";
        public const string EmptyAccountIds = "La cuenta debe tener al menos un identificador";
        public const string EmptyAccountNumber = "El número de cuenta no puede ser vacío";
        public const string EmptyCbu = "El CBU no puede ser vacío";
        public const string EmptyAlias = "El Alias no puede ser vacío";
        public const string DuplicatedOwner = "Al parecer ya existe alguien que está manejando fondos de esta persona";
        public const string InvalidCbu = "CBU inválido";
        public const string InvalidBankCodeInIds = "El banco no coincide con los identificadores de cuenta ingresados";
        public const string InvalidAlias = "Alias inválido";
        public const string InvalidAccountNumber = "Número de cuenta inválido";
        public const string InconsistentBankIds = "La cuenta no es consistente con el CBU";
        public const string InvalidBankOffice = "El código de sucursal es inválido";
        public const string DuplicatedCBU = "Ya existe un registro con el CBU indicado";
        public const string DuplicatedBankAccount = "Ya existe un registro con el númrero de cuenta indicado";
        public const string InvalidPerson = "Titular inválido";
        public const string InvalidOpenDate = "La fecha de apertura no puede ser posterior a la fecha actual";
        public const string ExistPorfolioByPersonInOtherAdminGroup = "No se puede crear la cartera porque hay otro grupo administrativo gestionando los recursos de {0}. Te contactaremos a la brevedad para ayudarte";
        public const string SubjectEmailCreacionPortfolio = "Creación de Cartera";
        public const string InconsistentZipCodePortfolioCheck = "El código postal indicado en la cartera no coincide con el del cheque";
        public const string InconsistentAccountantIdentifierPortfolioCheck = "El identificador de cuenta indicado en la cartera no coincide con el del cheque";
        public const string OwnerMustNotBeOrganization = "El titular de la cartera no debe ser de la organización";
        public const string PreExistentEmisorPortfolio = "Ya existe una cartera emisora para el número de ruta indicado";
        public const string BodyEmailCreacionPortfolio = "Intento de crear un portfolio en distintos grupos administrativos\n\n" +
                                                         "Titular en conflicto:\n\n Id: {0}\n Nombre: {1}\n Cuit: {2}\n\n" +
                                                         "Objeto Existente:\n\n Id de Grupo Administrativo: {3}\n Nombre de Grupo Administrativo : {4}\n EMail: {5}\n Id Portfolio: {6}\n Nombre Portfolio: {7}\n\n" +
                                                         "Objeto Solicitado:\n\n Id de Grupo Administrativo: {8}\n Nombre de Grupo Administrativo : {9}\n EMail: {10}\n Nombre Portfolio: {11}";
        #endregion

        #region Movement Messages

        public const string EmptyMovementType = "El tipo de movimiento es obligatorio";
        public const string EmptyPortfoio = "La cartera de origen es obligatoria";
        public const string EmptyConversionRate = "La tasa de conversión es obligatoria";
        public const string EmptySourcePerson = "La persona es obligatoria";
        public const string EmptyMovementDate = "La fecha del movimiento es obligatoria";
        public const string EmptyMovementComposition = "La composición del movimiento es obligatoria";
        public const string EmptyMovementCompositionAmmount = "Debe especificar un monto para la composición del movimiento";
        public const string MovementNotbalance = "El Movimineto no balancea";
        public const string MoneyTypeConflict = "Existen conflictos con la composición del movimiento y el/los tipos de dinero";
        public const string CheckAmmountConflict = "El total de cheques no coicide con la composición del movimiento";
        public const string InvalidPreviousAccountantDate = "La fecha del movimiento no puede ser posterior a la fecha actual";
        public const string CurrencyIsNotContainedInPortfolio = "La moneda seleccionada no esta asiganada al portfolio";
        public const string EmptyPortfoioId = "El Id de la cartera no puede ser vacío";
        public const string CheckCurrencyMustBePesos = "Los cheques solo pueden ser en la moneda pesos";
        public const string NotRecognizedBank = "No se reconoce el banco";
        public const string CantUpdateCheckRoutingNumberOrType = "El número de cheque y el tipo no se pueden modificar";
        public const string UnAvailableCheckForMovement = "Algunos de los cheques no están disponibles para el movimiento";
        public const string UnAvailableCompositionsCount = "Los items de la composición del movimiento no está permitida";
        public const string CheckEmissionMovement = "Cheque Emitido - Nro {0}";

        #endregion

        #region Check Messages

        public const string PreExistentCheck = "El cheque ya se encuentra registrado";
        public const string IssuedCheck = "El cheque ya se encuentra emitido";
        public const string PreExistentUsedCheck = "El cheque ya se encuentra registrado y utilizado en moviminetos";
        public const string EmptyEmisorPortfolio = "La cartera emisora no puede ser vacía";
        public const string EmisorPortfolioMustBeCurrentAccount = "La cartera emisora debe ser una cuenta corriente";
        public const string EmptyEmisor = "El cheque debe tener un titular emisor";
        public const string InvalidEmisorPortfolioData = "Los datos del cheque no son consistentes con el portfolio";
        public const string InvalidCheckRoutingNumber = "El número de cheque es inválido";
        public const string InvalidCheckSerialCode = "El número de serie es inválido";
        public const string InvalidCheckAmount = "El importe del cheque es inválido";
        public const string InvalidCheckEmissionDate = "La fecha de emisión del cheque es inválida";
        public const string InvalidCheckDueDate = "Parece que estás intentando cargar un cheque vencido";
        public const string InvalidCheckPresentationDate = "La fecha de presentación del cheque es inválida";
        public const string TryToAddOwnCheckInsteadOfThird = "Al parecer estás queriendo cargar un cheque prorio. Intentá desde \"Mis Carteras\"";
        public const string WrongCurrencyToCheck = "Se encontró una cartera asociada, pero no posee monedas compatibles con el cheque";
        public const string WrongCheckEmisor = "Se encontró una cartera asociada, pero los titulares no coinciden con el emisor del cheque";
        public const string WrongBankCheckEmisor = "Para el tipo de cheque indicado, el titular emisor debe ser el mismo banco";
        public const string ChecEmisorBankConflict = "Conflicto con el emisor del cheque. Los cheuqes financieros y/o cancelatorios son emitidos por la entidad bancaria";
        public const string InconsistentCheckBookNumbers = "Los números de inicio y fin de cheques ingresados para la chequera son inválidos";
        public const string InconsistentCheckBook = "La chequera es inválida";
        public const string OrganizationOnlyCantEmitOwnChecks = "Para emitir cheques propios, el tirular emisor debebe pertenecer a la organización";
        public const string OrganizationCantEmitThirdChecks = "Los cheques de terceros no pueden ser emitidios por titulares de la organización";
        public const string IntraExtraGroupConflicts = "Conflicto entre objetos intra y extra grupo";
        public const string EmisorAndMovementPortfolioNotMatchPerson = "Los titulares de la cartera emisora del cheque y la cartera destino del mismo no concuerdan";

        #endregion

        #region CheckBook Messages

        public const string EmptyCheckBook = "La chequera no puede ser vacía";
        public const string DuplicatedCheckBook = "Ya existe un registro de chequera para los datos ingresados";
        public const string InvalidCheckBooK = "La chequera es inválida";
        public const string InvalidCheckBooKData = "Los datos del cheque no son consistentes con la chequera";
        public const string InvalidFirstAndLastChecks = "Los datos del primer y último cheque no son consistentes";
        public const string InvalidEmisroPortfolioData = "Los datos de la cartera emisora no son consistentes con la chequera";
        public const string InvalidEmisorCheckBooK = "El misor de la chequera es inválido";
        public const string InvalidCheckBooKByEmisorPortfolio = "La chequera no se corresponde con la cartera emisora";
        public const string InvalidChekOrCheckBookType = "El tipo de cheque y/o el tipo de chequera es invalido o no coinciden";
        public const string OverlapCheckBook = "La chaquera ingresada se superpone con una ya existente";

        #endregion
    }
}
