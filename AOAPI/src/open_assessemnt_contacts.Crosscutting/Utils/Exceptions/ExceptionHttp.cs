using System;

namespace Open.Assessement.Contacts.Crosscutting.Utils.Exceptions
{
    public class ExceptionHttp : Exception
    {
        public Object Object { get; set; }
        public TypeException Type { get; set; }

        public ExceptionHttp(string message) : base(message)
        {
            this.Type = TypeException.Danger;
        }

        public ExceptionHttp(string message, TypeException type) : base(message)
        {
            this.Type = type;
        }

        public ExceptionHttp(string message, TypeException type, object obj) : base(message)
        {
            this.Type = type;
            this.Object = obj;
        }

        public enum TypeException
        {
            Warning,
            Danger,
            Question
        }
    }
}