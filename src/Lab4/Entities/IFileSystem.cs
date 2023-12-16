using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities;

public interface IFileSystem
{
    string GetFileText(string source);
    void MoveFile(string source, string destination);
    void CopyFile(string source, string destination);
    void DeleteFile(string source);
    void RenameFile(string source, string name);
    IEnumerable<IAbstraction> GetAbstractions(string source);
    string GetNameFromPath(string path);
    string GetAbsolutePath(string root, string source);
}