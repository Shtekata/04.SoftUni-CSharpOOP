using System;
using System.Collections.Generic;
using System.Text;
using ViceCity.Messages;
using ViceCity.Models.Guns.Contracts;

namespace ViceCity.Models.Guns
{
    public abstract class Gun : IGun
    {
        private string name;
        private int bulletsPerBarrel;
        private int totalBullets;

        protected Gun(string name, int bulletsPerBarrel, int totalBullets)
        {
            Name = name;
            BulletsPerBarrel = bulletsPerBarrel;
            TotalBullets = totalBullets;
        }
        public string Name
        {
            get => name;

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGunName);
                }

                name = value;
            }
        }

        public int BulletsPerBarrel
        {
            get => bulletsPerBarrel;

            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCountOfBullets);
                }

                bulletsPerBarrel = value;
            }
        }

        public int TotalBullets
        {
            get => totalBullets;

            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTotalBullets);
                }

                totalBullets = value;
            }
        }

        public bool CanFire => BulletsPerBarrel > 0;

        public abstract int Fire();
    }
}
