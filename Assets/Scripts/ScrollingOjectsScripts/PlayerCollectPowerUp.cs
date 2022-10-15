using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollectPowerUp : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            GameController.Instance.IncreasePowerUpPoints();
            AudioController.Instance.PlayPickUpSoundEffect();
            this.transform.position = GameController.Instance.outOfBoundsBarrier.transform.position;
        }
    }
}
