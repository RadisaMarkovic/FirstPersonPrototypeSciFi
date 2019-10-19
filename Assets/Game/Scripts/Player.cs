using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {


    private CharacterController _characterController;
    private Vector3 _moveDirection;
    private Vector3 _velocity;
    [SerializeField]
    private float _speed = 5f;
    private float _gravity = 9.81f;

    [SerializeField]
    private GameObject _muzzleFlash;

    [SerializeField]
    private GameObject _hitMarker;

    [SerializeField]
    private GameObject _weapon;

    [SerializeField]
    private AudioSource _weaponSoundSource;

    [SerializeField]
    private int _currentAmmo;
    private int _maxAmmo = 50;
    private bool _isReloading = false;
    private bool _weaponEnabled = false;
    private UIManager _uiManager;

    public bool hasCoin = false;


    void Start ()
    {
        //Hide the mouse cursor visibility in game
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    
        _characterController = GetComponent<CharacterController>();
        _muzzleFlash.SetActive(false);
        _currentAmmo = _maxAmmo;

        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        
    }
    
    
    void Update ()
    {
        // Check if player have enough ammo and is not reloading and that weapon is picked
        if (Input.GetMouseButton(0) && _currentAmmo > 0 && _isReloading == false && _weaponEnabled == true)
        {
            Shoot();
        }

        else
        {
            _weaponSoundSource.Stop();
            _muzzleFlash.SetActive(false);  
        }

        if (Input.GetKeyDown(KeyCode.R) && _isReloading == false)
        {
            _isReloading = true;
            StartCoroutine(ReloadRoutine());
        }

        if (Input.GetKeyDown(KeyCode.Escape) == true)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        CalculateMovement();

    }

    void Shoot()
    {
       
        _currentAmmo--;
        _uiManager.UpdateAmmoCount(_currentAmmo);

        // cast the ray from camera in middle of screen, range is set to infinity but it can be change to represent the range of how long can bullet travel
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            Instantiate(_hitMarker, hit.point, Quaternion.LookRotation(hit.normal));
            Debug.Log("Hit: " + hit.transform.name);

            if (hit.transform.gameObject.CompareTag("WoodenCrate"))
            {
                DestructableCrate dc = hit.transform.gameObject.GetComponent<DestructableCrate>();

                if (dc != null)
                {
                    dc.DestroyCrate();
                }
            }
        }

        if (_weaponSoundSource.isPlaying == false)
        {
            _weaponSoundSource.Play();
        }
        _muzzleFlash.SetActive(true);
    }

    void CalculateMovement()
    {
        _moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        
        _velocity = _moveDirection * _speed;
        _velocity.y -= _gravity;
        _velocity = transform.transform.TransformDirection(_velocity);
        _characterController.Move(_velocity * Time.deltaTime);
    }

    IEnumerator ReloadRoutine()
    {
        
        yield return new WaitForSeconds(1.5f);
        _currentAmmo = _maxAmmo;
        _uiManager.UpdateAmmoCount(_currentAmmo);
        _isReloading = false;
    }

    public void EnableWeapon()
    {
        _weaponEnabled = true;
        _weapon.SetActive(true);
    }
  
    
}
