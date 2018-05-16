﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShooterGame
{
    class Attackcontroller : IComponent
    {
        private Entity _entity;
        private int _damage;

        /// <summary>
        /// Get or set parent entity.
        /// </summary>
        public Entity Entity
        {
            get => _entity;
            set
            {
                if (_entity != value)
                {
                    if (_entity != null) _entity.Attack = null;
                    _entity = value;
                    if (_entity != null) _entity.Attack = this;
                }
            }
        }
        /// <summary>
        /// get or set damage value
        /// </summary>
        public int Damage
        {
            get => _damage;
            set { _damage = value; }
        }


        /// <summary>
        /// check the health is greater than damage
        /// </summary>
        /// <param name="health">initial healthcomponent</param>
        public void Attack(HealthComponet health)
        {
            if (health.Health > _damage)

                health.Health -= _damage;
            else
                health.Entity?.Destroy();
        }

        /// <summary>
        ///  Clear all component data and attempt to unlink from any external data.
        /// </summary
        public void Destroy()
        {
            //empty
        }

    }
}