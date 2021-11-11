namespace ResidentBookmark.Services
{
    public class FindArgumentNullException : ArgumentNullException
    {
        public FindArgumentNullException (string message = "Could not FIND this item. Verify that the item still exist and try again.") : base (message)
        {

        }
    }

    public class FindInvalidOperationException : InvalidOperationException
    {
        public FindInvalidOperationException (string message = "Could not FIND this item. Verify that the item still exist and try again.") : base (message)
        {

        }
    }

    public class DeleteArgumentNullException : ArgumentNullException
    {
        public DeleteArgumentNullException (string message = "Could not DELETE this item. Verify that the item still exist and try again.") : base (message)
        {

        }
    }

    public class DeleteInvalidOperationException : InvalidOperationException
    {
        public DeleteInvalidOperationException (string message = "Could not DELETE this item. Verify that the item still exist and try again.") : base (message)
        {

        }
    }

    public class EditArgumentNullException : ArgumentNullException
    {
        public EditArgumentNullException (string message = "Could not EDIT this item. Verify that the item still exist and try again.") : base (message)
        {

        }
    }

    public class EditNullReferenceException : NullReferenceException
    {
        public EditNullReferenceException (string message = "Could not EDIT this item. Verify that the item still exist and try again.") : base (message)
        {

        }
    }

    public class ConfigurationNullReferenceException : NullReferenceException
    {
        public ConfigurationNullReferenceException (string message = "Could not READ settings in configuration file. Verify the configuration and try again.") : base (message)
        {

        }
    }
}