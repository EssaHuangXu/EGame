using System;

namespace CC.Core
{
    public sealed class CCApplication
    {
        private static readonly Lazy<CCApplication> _instanceHolder = new Lazy<CCApplication>(() => new CCApplication());

        public static CCApplication Instance => _instanceHolder.Value;

        private CCLogic _logic;
        
        private CCApplication()
        {
            _logic = new CCLogic();
        }

        public void Update(float deltaTime)
        {
            _logic?.Update(deltaTime);
        }
    }
}