using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{

    [SerializeField] private Image Barprogression;
    private float lastvalue;

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.singleton.GameStarted) return;

        float traveledDistance = GameManager.singleton.TotalDistance - GameManager.singleton.distanceRemain;
        float value = traveledDistance / GameManager.singleton.TotalDistance;

        if (GameManager.singleton.gameObject && value < lastvalue) return;

        Barprogression.fillAmount = Mathf.Lerp(Barprogression.fillAmount, value, 5 * Time.deltaTime);

        lastvalue = value;


    }
}
