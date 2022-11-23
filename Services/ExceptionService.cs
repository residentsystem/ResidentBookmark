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

    public class SettingFileNullReferenceException : NullReferenceException
    {
        public SettingFileNullReferenceException (string message = "Configuration file was not found!!") : base (message)
        {

        }
    }

    public class TitleNullReferenceException : NullReferenceException
    {
        public TitleNullReferenceException (string message = "Title setting set as null. Verify the settings and try again.") : base (message)
        {

        }
    }

    public class ShowLimitNullReferenceException : NullReferenceException
    {
        public ShowLimitNullReferenceException (string message = "ShowLimit setting set as null or value set to 0. Verify the settings and try again.") : base (message)
        {

        }
    }

    public class SortWebsiteNullReferenceException : NullReferenceException
    {
        public SortWebsiteNullReferenceException (string message = "SortWebsite setting set as null or contain a typo. Verify the settings and try again.") : base (message)
        {

        }
    }
}