namespace OmniSharp.Services
{
    public interface IPathRewriter
    {
        string ToClientPath(string path);
        string ToServerPath(string path);
    }
}
