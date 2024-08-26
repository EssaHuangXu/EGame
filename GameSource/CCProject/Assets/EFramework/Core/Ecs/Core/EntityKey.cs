using System;

namespace EFramework.Core.Ecs
{
    public class EntityKey : IEntityKey, IEquatable<EntityKey>
    {
        private const int GenrationOffset = 24;

        private const int TypeMask = 0xFF_FFFF;
        public uint Key { get; }

        public byte Generation => (byte)((Key >> GenrationOffset) & 0xFF);

        public uint Type => (uint)(Key & TypeMask) - 1;

        public bool Valid => Key != 0;

        /// <summary>
        /// Entity key make with type and generation
        /// storing a uint key, it height 8 byte is generation and others 24 byte is type.
        /// </summary>
        /// <param name="type">range [0, 2^24 -1]</param>
        /// <param name="generation">range [0, 2^8 - 1]</param>
        public EntityKey(uint type, byte generation)
        {
            Key = (uint)generation << GenrationOffset;
            //plus 1 ,make data is not same with default 0
            Key |= (uint)((type + 1) & TypeMask);
        }

        public bool Equals(EntityKey other)
        {
            if (other == null)
            {
                return false;
            }

            return Key == other.Key;
        }

        public override bool Equals(object o)
        {
            return o is EntityKey entityKey && Key == entityKey.Key;
        }

        public override int GetHashCode()
        {
            return (int)Key;
        }

        public static bool operator ==(EntityKey lhs, EntityKey rhs)
        {
            return lhs!.Equals(rhs);
        }

        public static bool operator !=(EntityKey lhs, EntityKey rhs)
        {
            return !(lhs!.Equals(rhs));
        }
    }
}