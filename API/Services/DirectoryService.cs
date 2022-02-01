using API.Interfaces;

namespace API.Services
{
    public class DirectoryService : IDirectoryService
    {
        public Directory GetDirectoryStructure(string pathToDirectory)
        {
            var directory =  new Directory();

            if(string.IsNullOrEmpty(pathToDirectory)){
                directory.PreviousFolder = "root";
                directory.FollowingFolders = new List<Directory>(); 


                foreach (var logicalDriver in Environment.GetLogicalDrives()){
                directory.FollowingFolders.Add(
                    new Directory() 
                    {
                        PreviousFolder=directory.PreviousFolder, 
                        Path = logicalDriver
                    });
                }

                foreach(var following in directory.FollowingFolders){
                    DirectoryTreeCreator(following);
                }
            }
            else 
            {
                directory.Path = pathToDirectory;
                DirectoryTreeCreator(directory);
            }
            
            return directory;
        }

        void DirectoryTreeCreator(Directory directory, int depth = 0){
            if (depth > 0) return;

            var root = new DirectoryInfo(directory.Path);
            
            directory.FollowingFolders = new List<Directory>();
                ++depth;
                foreach (var dirInfo in root.GetDirectories()){
                    
                    var followingDir = new Directory() {
                        Path = dirInfo.FullName,
                        PreviousFolder = directory.Path
                    };
                    
                    DirectoryTreeCreator(followingDir, depth);
                    directory.FollowingFolders.Add(followingDir);
                }
        }
    }
}