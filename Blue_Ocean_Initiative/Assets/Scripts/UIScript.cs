using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public Transform player;
    public Text currencyText;
    public Image gaugeImage;
    public GameObject collectPopup;

    private int currency = 0;
    private float gaugeTime = 10f;
    private float maxGaugeTime = 10f;
    public bool isNearCollectible = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdateCurrencyDisplay();
        UpdateGauge();
        CheckForCollectibles();
    }
    void UpdateCurrencyDisplay()
    {
        currencyText.text = "Currency: " + currency;
    }
    void UpdateGauge()
    {
        if (player.position.y < 74.5)
        {
            gaugeTime -= Time.deltaTime;
            gaugeTime = Mathf.Clamp(gaugeTime, 0, maxGaugeTime);
        }
        else
        {
            gaugeTime = maxGaugeTime;
        }

        gaugeImage.fillAmount = gaugeTime / maxGaugeTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("trash"))
        {
            isNearCollectible = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("trash"))
        {
            isNearCollectible = false;
        }
    }
    void CheckForCollectibles()
    {
        if (isNearCollectible)
        {
            collectPopup.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F))
            {
                currency += 10;
                isNearCollectible = false;
                collectPopup.SetActive(false);
            }
        }
        else
        {
            collectPopup.SetActive(false);
        }
    }
}