export interface Directory {
    path: string;
    followingFolders: Directory[];
    previousFolder: string;
}