namespace task1
{
    public class FileManager
    {
        public static void CreateFile(string path, string content)
        {
            File.WriteAllText(path, content);
        }

        public static bool DeleteFile(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
                return true;
            }
            return false;
        }

        public static void CopyFile(string path, string desPath)
        {
            File.Copy(path, desPath);
        }

        public static void MoveFile(string sourcePath, string destPath)
        {
            File.Move(sourcePath, destPath);
        }

        public static void RenameFile(string path, string newName)
        {
            string directory = Path.GetDirectoryName(path);
            string newPath = Path.Combine(directory, newName);
            File.Move(path, newPath);
        }

        public static string[] GetFilesInDirectory(string directory)
        {
            return Directory.GetFiles(directory);
        }

        public static void SetFileReadOnly(string path, bool isReadOnly)
        {
            FileAttributes attributes = File.GetAttributes(path);
            if (isReadOnly)
                attributes |= FileAttributes.ReadOnly;
            else
                attributes &= ~FileAttributes.ReadOnly;
            File.SetAttributes(path, attributes);
        }

        public static void DeleteFilesByPattern(string directory, string pattern)
        {
            foreach (string file in Directory.GetFiles(directory, pattern))
            {
                File.Delete(file);
            }
        }
    }
}
