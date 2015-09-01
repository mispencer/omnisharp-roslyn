namespace OmniSharp.Options
{
    public class PathOptions
    {
        public string ClientMode
        {
            get
            {
                return Client.ToString();
            }
            set
            {
                Client = (PathMode)System.Enum.Parse(typeof(PathMode), value);
            }
        }

        public string ServerMode
        {
            get
            {
                return Server.ToString();
            }
            set
            {
                Server = (PathMode)System.Enum.Parse(typeof(PathMode), value);
            }
        }

        public PathMode Client { get; set; }
        public PathMode Server { get; set; }
    }

    public enum PathMode {
        Windows,
        Unix,
        Cygwin,
    }
}
