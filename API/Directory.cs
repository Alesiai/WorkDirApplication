namespace API
{
    public class Directory
    {
        public string Path {get; set;}
        public string PreviousFolder {get; set;}
        public List<Directory> FollowingFolders {get; set;}
    }
}