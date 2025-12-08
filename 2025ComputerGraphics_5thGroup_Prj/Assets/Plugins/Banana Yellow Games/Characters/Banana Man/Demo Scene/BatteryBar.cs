using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryBar : MonoBehaviour
{
    public Battery battery;
    public Image fill;

    private void LateUpdate()
    {
        if (!battery || !fill)
        {
            return;
        }

        float b = Mathf.Clamp01(battery.battery);
        fill.fillAmount = b;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
