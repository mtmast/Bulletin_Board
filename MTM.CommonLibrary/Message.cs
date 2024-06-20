﻿namespace MTM.CommonLibrary
{
    public enum AlertType
    {
        Success,
        Error,
        Warning,
        Danger
    }

    public static class Message
    {
        public const int SUCCESS = 1;
        public const int FAILURE = 2;
        public const int EXIST = 3;

        #region Message
        public const string SAVE_SUCCESS = "{0} is successfully {1}.";
        public const string ALREADY_EXIST = "{0} is already created.";
        public const string NOT_EXIST = "{0} does not exist.";
        public const string PASSWORD_FORMAT_ERROR = "Password must be at least one lowercase letter, one uppercase letter, one digit, and one special character";
        #endregion
    }
}
