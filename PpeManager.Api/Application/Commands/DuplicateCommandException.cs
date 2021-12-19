﻿namespace PpeManager.Api.Application.Commands
{
    public class DuplicateCommandException: Exception
    {
        public DuplicateCommandException() { }
        public DuplicateCommandException(string message) : base(message) { }
        public DuplicateCommandException(string message, Exception innerException):base(message, innerException) { }
    }
}