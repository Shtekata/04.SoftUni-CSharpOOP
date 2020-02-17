using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Models.Guns
{
    public class Rifle : Gun
    {
        private const int InitialBulletsPerBarrel = 50;
        private const int InitialTotalBullets = 500;
        private const int InitialRifleDamage = 5;
        public Rifle(string name)
            : base(name, InitialBulletsPerBarrel, InitialTotalBullets)
        {
        }

        public override int Fire()
        {
            if (BulletsPerBarrel - InitialRifleDamage <= 0 && TotalBullets > 0)
            {
                BulletsPerBarrel = InitialBulletsPerBarrel;
                TotalBullets -= InitialBulletsPerBarrel;
                return InitialRifleDamage;
            }

            else
            {
                BulletsPerBarrel -= InitialRifleDamage;
                return InitialRifleDamage;
            }
        }
    }
}
