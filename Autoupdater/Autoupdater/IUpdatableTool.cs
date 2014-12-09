using System;
using System.Windows.Forms;

namespace Autoupdater
{
    public interface IUpdatableTool
    {
        string Id { get; }
        string Name { get; }
        string Path { get; }
        Version Version { get; }
    }
}