namespace EasyFeedback.Core
{
    public static class Constants
    {
        public static class Web
        {
            public static class RequestMethod
            {
                public const string POST = "POST";
                public const string GET = "GET";
                public const string PUT = "PUT";
            }

            public static class Header
            {
                public const string ContentType = "Content-Type";
            }
        }

        /// <summary>
        /// Forward slash (/) as unicode sequence. 
        /// Used as a workaround for forward slashes in Trello board names
        /// causing popups to erronously display submenus.
        /// </summary>
        public const string UNICODE_FORWARD_SLASH = "\u2215";
    }
}