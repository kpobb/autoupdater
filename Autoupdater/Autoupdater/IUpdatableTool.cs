using System;

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
