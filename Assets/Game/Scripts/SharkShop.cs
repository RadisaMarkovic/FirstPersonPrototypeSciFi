using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkShop : MonoBehaviour
{
    private Player _player;
    private UIManager _uiManager;
    [SerializeField]
    private AudioClip _audioClip;

    private void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
            _uiManager.EnableWeaponText();


        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E)) 
        {
            _player = other.gameObject.GetComponent<Player>();

            if (_player != null && _player.hasCoin == true)
            {
                _player.hasCoin = false;
                _uiManager.DisableCoin();
                AudioSource.PlayClipAtPoint(_audioClip, transform.position);
                _player.EnableWeapon();
            }

        }
    }

     void OnTriggerExit(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            _uiManager.DisableWeaponText();
        }
    }



}
