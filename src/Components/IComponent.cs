﻿
namespace ShooterGame
{
    interface IComponent
    {

        /// <summary>
        /// Get or set parent entity.
        /// </summary>
        Entity Entity { get; set; }

        /// <summary>
        /// Clear all component data and attempt to unlink from any external data.
        /// </summary>
        void Destroy();
    }
}
