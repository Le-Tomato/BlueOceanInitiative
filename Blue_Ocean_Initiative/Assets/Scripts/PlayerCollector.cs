using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollector : MonoBehaviour
{
    public UIScript uiManager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("trash"))
        {
            uiManager.isNearCollectible = true;
            uiManager.collectPopup.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("trash"))
        {
            uiManager.isNearCollectible = false;
            uiManager.collectPopup.SetActive(false);
        }
    }
}
