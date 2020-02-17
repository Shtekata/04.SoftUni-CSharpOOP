using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Models.Guns
{
    public class Pistol : Gun
    {
        private const int InitialBulletsPerBarrel = 10;
        private const int InitialTotalBullets = 100;
        private const int InitialPistolDamage = 1;
        public Pistol(string name) 
            : base(name, InitialBulletsPerBarrel, InitialTotalBullets)
        {
        }

        public override int Fire()
        {
            if (BulletsPerBarrel - InitialPistolDamage <= 0 && TotalBullets > 0)
            {
                BulletsPerBarrel = InitialBulletsPerBarrel;
                TotalBullets -= InitialBulletsPerBarrel;
                return InitialPistolDamage;
            }

            else
            {
                BulletsPerBarrel--;
                return InitialPistolDamage;
            }
        }
    }
}
