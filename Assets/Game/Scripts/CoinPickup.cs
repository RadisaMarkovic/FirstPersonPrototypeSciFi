using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    private Player _player;
    [SerializeField]
    private AudioClip _coinAudioClip;

    private UIManager _uiManager;

    public void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    private void OnTriggerStay(Collider other)
    {
       
        if (other.CompareTag("Player"))
        {
            //Show prompt for pick up coin
             _uiManager.EnablePickupCoinText();
            if (Input.GetKeyDown(KeyCode.E))
            {
                

                _player = other.gameObject.GetComponent<Player>();

                _player.hasCoin = true;
                _uiManager.EnableCoin();
                AudioSource.PlayClipAtPoint(_coinAudioClip, transform.position);
                //when player picked up the coin disable the prompt
                _uiManager.DisablePickupCoinText();
                Destroy(this.gameObject);
              
            }
            

           
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            //hide prompt for pick up coin
            _uiManager.DisablePickupCoinText();
        }
    }
}
