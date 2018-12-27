namespace OilyTools.Core.Exceptions
{
    public class NotFoundException : DomainException
    {
        public NotFoundException(string name, object key)
            : base($"The \"{name}\" ({key}) was not found.")
        {
        }

        private NotFoundException(string businessMessage) : base(businessMessage)
        {
        }
    }
}
