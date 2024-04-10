using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gun
{
    [Serializable]
    public class GunStats : MonoBehaviour
    {
        public enum ShootingType
        {
            Raycast, Projectile
        }

        public enum ActionType
        {
            Manual, Automatic
        }

        [Header("Hover over variables for tooltips")]
        public Animator animator;
        [Header("Gun Info")]
        [Tooltip("The name of the gun")]public string gunName;
        [Tooltip("What type of weapon is it")] public string gunType;
        [Tooltip("The name of the ammo youre firering")]public string ammoName;
        [Tooltip("Toggle between hold and toggle for aiming")]public bool AimToggle;
        [Tooltip("How fast the gun fires olny necessary if you dont use animation events")]public float fireRate;
        [Tooltip("Turn on if you want to use a projectile insted of a raycast")]public ShootingType shootingType;
        [Tooltip("ActionType of the weapon (in the way that bolt action is manual)")]public ActionType actionType;
        [Tooltip("If the gun is an open or closed bold")]public bool openBolt;
        [Tooltip("The point from wich the raycast or projectile spawns")]public Transform firePoint;
        [Tooltip("If the gun has animation event for calling functions like fire")]public bool hasAnimevents;

        [Header("Gun Ammo and Mags info")]
        [Tooltip("if true weapon will shoot more than one bullet(Most shotguns will be manual and multishot)")]public bool multiShot;
        [Tooltip("The prefab of the bullet you want to shoot")]public GameObject bullet;
        [Tooltip("Turn on if you want to spawn a cassing after fireing")]public bool spawnCassing;
        [ConditionalHide("spawnCassing")][Tooltip("The point from wich the casing spawns")]public Transform casingyEjectPoint;
        [ConditionalHide("spawnCassing")][Tooltip("the prefab of the cassing you want to eject")]public GameObject cassing;
        [Tooltip("Set the ammo you have with you in a total bullet amount")]public bool ammoPoolInBullets;
        [ConditionalHide("ammoPoolInBullets")][Tooltip("The amount of bullets the player has at the start")] public int startBulletPool;
        [Tooltip("Set the ammo you have in total mags will waste bullets if you reload whit a not empty mag")]public bool ammoPoolInMags;
        [ConditionalHide("ammoPoolInMags")][Tooltip("The amount of magazines the player has at the start")]public int startMagPool;
        [Tooltip("The amount of bullets that fit in to a magazine")]public int magSize;
        [Tooltip("Turn on if the gun does not have a detachable magazine")]public bool hasInternalMag;
        [ConditionalHide("hasInternalMag")][Tooltip("The size of the internal magazine of the gun")]public int internalMagSize;
        [Tooltip("Allows the gun to go full auto (turn this of if you want it to be single fire)")]public bool fullAuto;
        bool _useBullet;
        bool _useCassing;
        [SerializeField]bool _doubleActionReload;

        [Header("Keybinds")]
        public KeyCode shootingKey;
        public KeyCode reloadKey;
        public KeyCode aimingKey;

        //Setters\\

        public void SetToggleAim(bool aim)
        {
            AimToggle = aim;
        }

        public void SetDoubleActionReload(bool doubleActionReloadBool)
        {
            _doubleActionReload = doubleActionReloadBool;
            animator.SetBool("DoubleActionReload", doubleActionReloadBool);
        }

        public void SetAmmoPoolInBullets(bool ammoPoolInBulletsBool)
        {
            ammoPoolInBullets = ammoPoolInBulletsBool;
        }

        public void SetAmmoPoolInMags(bool ammoPoolInMagsBool)
        {
            ammoPoolInMags = ammoPoolInMagsBool;
        }

        //Getters\\

        public bool GetDoublleActionReload()
        {
            return _doubleActionReload;
        }
    }

    [System.Serializable]
    class GunManager : GunStats
    {
        [Header("Manager")]
        public int currentMagAmmo;
        public float fastReloadDelayTime;
        public List<int> _magList;
        public GameObject magOBJ;
        //[Header("Privates only shown for debug")]
        int _currentMags;
        int _currentBullets;
        [SerializeField]int _bulletsInChamber;
        float _currentFireCooldown;
        bool _aiming;
        bool _canShoot;
        float _currentFastReloadDelay;


        void Start()
        {
            _canShoot = true;
            _currentBullets = startBulletPool;
            _currentMags = startMagPool;
        }

        void Update()
        {
            AimUpdate();
            InputUpadte();
        }

        public void InputUpadte()
        {
            if (Input.GetKey(shootingKey) && fullAuto)
            {
                if(!hasAnimevents && _currentFireCooldown <= 0)
                {
                    Fire();
                    animator.SetBool("Fire" , true);
                }
                else
                {
                    animator.SetBool("Fire", true);
                }
            }
            else if( Input.GetKeyDown(shootingKey))
            {
                if(!hasAnimevents)
                {
                    Fire();
                    animator.SetBool("Fire", true);
                }
                else
                {
                    animator.SetBool("Fire", true);
                }
            }
            else if (Input.GetKeyUp(shootingKey) && currentMagAmmo > 0) 
            {
                _canShoot = true;
                animator.SetBool("Fire", false);
            }

            if (Input.GetKeyDown(reloadKey))
            {
                _currentFastReloadDelay = fastReloadDelayTime;
                animator.SetTrigger("Reload");
            }

            if (Input.GetKeyDown(reloadKey) && _currentFastReloadDelay > 0)
            {
                //call fast reload here
            }

            if (_currentFireCooldown > 0)
            {
                _currentFireCooldown -= Time.deltaTime;
            }

            if(currentMagAmmo == 0 && _bulletsInChamber == 0)
            {
                animator.SetBool("Fire", false);
            }

            if(_bulletsInChamber >= 0)
            {
                animator.SetBool("BulletInChamber", true);
            }
            else
            {
                animator.SetBool("BulletInChamber", false);
            }
        }

        public void Fire()
        {
            switch (shootingType)
            {
                case ShootingType.Raycast:
                    RaycastHit hit;

                    if (_canShoot && currentMagAmmo > 0 || _canShoot && _bulletsInChamber != 0)
                    {
                        if(currentMagAmmo <= magSize && _bulletsInChamber == 0)
                        {
                            _bulletsInChamber++;
                        }

                        if(Physics.Raycast(firePoint.position, firePoint.forward, out hit, Mathf.Infinity))
                        {
                            currentMagAmmo--;

                            if (!fullAuto)
                            {
                                _canShoot = false;
                            }
                            else
                            {
                                _currentFireCooldown = fireRate;
                            }
                        }
                        else if(_bulletsInChamber != 0 && !openBolt)
                        {
                            currentMagAmmo--;
                        }
                        
                        if(currentMagAmmo == 0)
                        {
                            _bulletsInChamber--;
                        }
                    }


                    break;

                case ShootingType.Projectile: 
                    


                    break;
            }
        }

        public void SingleActionReload()
        {
            SavePartialMag();
            _canShoot = false;
            if(ammoPoolInBullets && _currentBullets >= magSize)
            {
                _currentBullets -= magSize;
                currentMagAmmo = magSize;
                if (_bulletsInChamber > 0 && !openBolt)
                {
                    currentMagAmmo += _bulletsInChamber; 
                }
                _canShoot = true;
            }
            else if(ammoPoolInMags && _currentMags > 0)
            {
                _currentMags--;
                currentMagAmmo = magSize;
                if (_bulletsInChamber > 0 && !openBolt)
                {
                    currentMagAmmo += _bulletsInChamber;
                }
                _canShoot = true;
            }
            else
            {
                Debug.LogError("not enough ammo");
            }
        }

        public void DoubleActionReloadOut()
        {
            if (GetDoublleActionReload())
            {
                if(_bulletsInChamber != 0 && !openBolt)
                {
                    currentMagAmmo = 0;
                    currentMagAmmo += _bulletsInChamber;
                }
                else if(_bulletsInChamber == 0)
                {
                    currentMagAmmo = 0;
                    animator.SetBool("GunEmpty", true);
                }
                animator.SetBool("MagIn", false);
            }
        }

        public void DoubleActionReloadIn()
        {
            if (GetDoublleActionReload())
            {
                if (ammoPoolInBullets && _currentBullets >= magSize)
                {
                    _currentBullets -= magSize;
                    currentMagAmmo = magSize;
                    if (_bulletsInChamber > 0 && !openBolt)
                    {
                        currentMagAmmo += _bulletsInChamber;
                    }
                    _canShoot = true;
                }
                else if (ammoPoolInMags && _currentMags > 0)
                {
                    _currentMags--;
                    currentMagAmmo = magSize;
                    if (_bulletsInChamber > 0 && !openBolt)
                    {
                        currentMagAmmo += _bulletsInChamber;
                    }
                    _canShoot = true;
                }
                else
                {
                    Debug.LogError("not enough ammo");
                }

                animator.SetBool("MagIn", true);
                animator.SetBool("GunEmpty", false);
            }
        }

        public void SavePartialMag()
        {
            int bulletsLeft = currentMagAmmo;
            if(_bulletsInChamber != 0 && !openBolt)
            {
                bulletsLeft -= _bulletsInChamber;
            }
            
            _magList.Add(bulletsLeft);
        }

        public void CasingEject()
        {

        }

        public void AimUpdate()
        {
            if(AimToggle)
            {
                if (Input.GetKeyDown(aimingKey))
                {
                    if (_aiming)
                    {
                        _aiming = false;
                    }
                    else
                    {
                        _aiming = true;
                    }
                }
            }
            else
            {
                if (Input.GetKey(aimingKey))
                {
                    _aiming = true;
                }
                else
                {
                    _aiming = false;
                }
            }
        }
        public void MagActiveSwitch()
        {
            if(magOBJ.activeSelf)
            {
                magOBJ.SetActive(false);
            }
            else
            {
                magOBJ.SetActive(true);
            }
        }
    }

}