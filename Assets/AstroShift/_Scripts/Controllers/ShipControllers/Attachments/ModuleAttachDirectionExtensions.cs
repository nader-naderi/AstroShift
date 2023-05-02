using System;

namespace AstroShift
{
    public static class ModuleAttachDirectionExtensions
    {
        public static EModuleAttachDirection Opposite(this EModuleAttachDirection direction)
        {
            switch (direction)
            {
                case EModuleAttachDirection.Left:
                    return EModuleAttachDirection.Right;
                case EModuleAttachDirection.Right:
                    return EModuleAttachDirection.Left;
                case EModuleAttachDirection.Up:
                    return EModuleAttachDirection.Down;
                case EModuleAttachDirection.Down:
                    return EModuleAttachDirection.Up;
                default:
                    throw new ArgumentException("Invalid direction: " + direction);
            }
        }
    }
}