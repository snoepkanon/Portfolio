using System;
using UnityEngine;

namespace Gun
{
    [System.Serializable]
    public class GunStats : MonoBehaviour
    {
        [Header("Gun Info")]
        [Tooltip("The name of the gun")]public string gunName;
        [Tooltip("What type of weapon is it")] public string gunType;

        [Header("Gun Ammo and Mags info")]
        [Tooltip("The name of the ammo youre firering")]public string ammoName;
        [Tooltip("Turn on if you want to use a projectile insted of a raycast")]public bool shootProjectile;
        [ConditionalHide("shootProjectile")][Tooltip("The prefab of the bullet you want to shoot")]public GameObject bullet;
        [Tooltip("Turn on if you want to spawn a cassing after fireing")]public bool spawnCassing;
        [ConditionalHide("spawnCassing")][Tooltip("the prefab of the cassing you want to eject")]public GameObject cassing;
        [Tooltip("The amount of magazines the player has")]public int magAmmount;
        [Tooltip("The amount of bullets that fit in to a magazine")]public int magSize;
        [Tooltip("Turn on if the gun does not have a detachable magazine")]public bool hasInternalMag;
        [ConditionalHide("hasInternalMag")][Tooltip("The size of the internal magazine of the gun")]public int internalMagSize;
        [Tooltip("Allows the gun to go full auto (turn this of if you want it to be single fire)")]public bool fullAuto;
        private bool useBullet;
        private bool useCassing;
    }

    [Serializable]
    public class GunManager : MonoBehaviour
    {


        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void fire()
        {

        }

        public void reload()
        {

        }
    }

}
