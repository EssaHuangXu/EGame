using System;

namespace EFramework.Core.Ecs
{
    public struct EntityKey : IEquatable<EntityKey>
    {
        private const int GenrationOffset = 24;

        private const int IDMask = 0xFF_FFFF;
        
        public uint Key { get; private set; }
    
        /// <summary>
        ///High 8 bit is Generation, it means entity reuse count
        /// </summary>
        public byte Generation => (byte)((Key >> GenrationOffset) & 0xFF);
        
        /// <summary>
        ///Low 24 bit is Entity Id
        /// </summary>
        public uint Id => (uint)(Key & IDMask) - 1;

        public bool Valid => Key != 0;

        /// <summary>
        /// Entity key make with type and generation
        /// storing a uint key, it height 8 byte is generation and others 24 byte is type.
        /// </summary>
        /// <param name="id">range [0, 2^24 -1]</param>
        /// <param name="generation">range [0, 2^8 - 1]</param>
        private EntityKey(uint id, byte generation)
        {
            Key = (uint)generation << GenrationOffset;
            //plus 1 ,make data is not same with default 0
            Key |= (uint)((id + 1) & IDMask);
        }

        public void Resign()
        {
            Key += (uint)(1 << GenrationOffset);
        }

        public bool Equals(EntityKey other)
        {
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

        public override string ToString()
        {
            return $"Entity Key : {Key}, Id : {Id}, Generation : {Generation}";
        }

        public static EntityKey Create(uint id)
        {
            return new EntityKey(id, 1);
        }
    }
}