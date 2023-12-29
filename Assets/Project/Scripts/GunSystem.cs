using InputManager;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.XInput;

public class GunSystem : MonoBehaviour
{
    //Gun stats
    public int damage;
    public float timeBetweenShooting, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold;
    private InputManager.InputController inputController;
    int bulletsLeft, bulletsShot;
    private Shooter shooter;

    //bools 
    bool shooting, readyToShoot, reloading;

    //Reference
    public Camera tpsCam;
    public Transform attackPoint;
    public RaycastHit rayHit;
    public LayerMask whatIsEnemy;
    [SerializeField] private Transform bulletprojectile;
    [SerializeField] private Transform spawnbullet;
    //Graphics
    // public GameObject muzzleFlash, bulletHoleGraphic;
    //public CamShake camShake;
    // public float camShakeMagnitude, camShakeDuration;
    // public TextMeshProUGUI text;


    private void Awake()
    {
        bulletsLeft = magazineSize;
        readyToShoot = true;
        inputController = GetComponent<InputManager.InputController>();
        shooter = GetComponent<Shooter>();
    }
    private void Update()
    {
        MyInput();
        Vector3 mouseWorldPosition = Vector3.zero;

        //SetText
        //text.SetText(bulletsLeft + " / " + magazineSize);
    }
    private void MyInput()
    {
        if (inputController.shoot)
        {
            Shoot();
        }
        void Shoot()
        {
            readyToShoot = false;
            Vector3 mouseWorldPosition = Vector3.zero;
            Vector3 aimDir = (mouseWorldPosition - spawnbullet.position).normalized;
            Instantiate(bulletprojectile, spawnbullet.position, Quaternion.LookRotation(aimDir, Vector3.up));
            bulletsLeft--;
            bulletsShot--;

            Invoke("ResetShot", timeBetweenShooting);

            if (bulletsShot > 0 && bulletsLeft > 0)
            {
                Invoke("Shoot", timeBetweenShots);
            }
            // inputController.shoot = false;
        }
        //  if (allowButtonHold) shooting = inputController.shoot;
        //  else shooting = Input.GetKeyDown(KeyCode.Mouse0);
        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading)
        {
            Reload();
        }
        //Shoot
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            bulletsShot = bulletsPerTap;
            Shoot();
        }
    }
    /*private void Shoot()
    {
        readyToShoot = false;
       /* //Spread
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        //Calculate Direction with Spread
        Vector3 direction = fpsCam.transform.forward + new Vector3(x, y, 0);

        //RayCast
        if (Physics.Raycast(fpsCam.transform.position, direction, out rayHit, range, whatIsEnemy))
        {
            Debug.Log(rayHit.collider.name);

            if (rayHit.collider.CompareTag("Enemy"))
                rayHit.collider.GetComponent<ShootingAi>().TakeDamage(damage);
        }

        //ShakeCamera
        camShake.Shake(camShakeDuration, camShakeMagnitude);

        //Graphics
        Instantiate(bulletHoleGraphic, rayHit.point, Quaternion.Euler(0, 180, 0));
        Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);*/

    // bulletsLeft--;
    //  bulletsShot--;

    //   Invoke("ResetShot", timeBetweenShooting);

    //  if (bulletsShot > 0 && bulletsLeft > 0) Invoke("Shoot", timeBetweenShots);
    // }
    private void ResetShot()
    {
        readyToShoot = true;
    }
    private void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
    }
    private void ReloadFinished()
    {
        bulletsLeft = magazineSize;
        reloading = false;
    }

    private class ShootingAi
    {
        internal void TakeDamage(int damage)
        {
            throw new System.NotImplementedException();
        }
    }


    public class CamShake
    {
        internal void Shake(float camShakeDuration, float camShakeMagnitude)
        {
            throw new System.NotImplementedException();
        }
    }
}