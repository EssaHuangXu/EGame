using System;

namespace CC.Core
{
    public sealed class CCApplication
    {
        private static readonly Lazy<CCApplication> _instanceHolder = new Lazy<CCApplication>(() => new CCApplication());

        public static CCApplication Instance => _instanceHolder.Value;

        private readonly CCLogic _logic;

        private CCWorldModule _world;
        
        private CCApplication()
        {
            _logic = new CCLogic();
            _world = new CCWorldModule();
        }

        public void Update(float deltaTime)
        {
            _logic?.Update(deltaTime);
        }
    }
}