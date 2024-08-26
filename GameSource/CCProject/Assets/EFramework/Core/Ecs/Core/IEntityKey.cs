using System;

namespace EFramework.Core.Ecs
{
    public interface IEntityKey
    {
        uint Key { get; }
        
        byte Generation { get; }
        
        uint Type { get; }
        
        bool Valid { get; }
    }
}