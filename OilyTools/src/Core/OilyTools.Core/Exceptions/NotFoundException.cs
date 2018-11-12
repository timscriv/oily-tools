﻿namespace OilyTools.Core.Exceptions
{
    public class NotFoundException : DomainException
    {
        public NotFoundException(string name, object key)
            : base($"\"{name}\" ({key}) was not found.")
        {
        }
    }
}
