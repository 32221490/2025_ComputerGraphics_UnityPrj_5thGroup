using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    public FlashlightController controller;
    public Light spot;
    public PlayerSafetyState safetyState;

    public float battery = 1f;
    public float drainPerSec = 0.02f;
    public float drainPerSecZoom = 0.05f;

    public float rechargePerSec = 0.12f;
    public float rechargeDelay = 0f;

    public float minIntensity = 1f;
    public float minRange = 8f;

    float inZoneTimer = 0f;

    private void Awake()
    {
        if (!controller)
        {
            controller = GetComponent<FlashlightController>();
        }

        if (!spot)
        {
            spot = controller ? controller.spotlight : GetComponent<Light>();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        ;
    }

    // Update is called once per frame
    void Update()
    {
        if (!controller || !spot)
        {
            return;
        }

        float dt = Time.deltaTime;
        bool inSafety = safetyState && safetyState.isInSafetyZone;

        if (inSafety)
        {
            inZoneTimer += dt;
            if (inZoneTimer >= rechargeDelay)
            {
                battery = Mathf.Clamp01(battery + rechargePerSec * dt);
            }
        }
        else
        {
            inZoneTimer = 0f;
            if (controller.isON)
            {
                float drain = drainPerSec + (controller.isZooming ? drainPerSecZoom : 0f);
                battery = Mathf.Clamp01(battery - drain * Time.deltaTime);
            }
        }
    }

    private void LateUpdate()
    {
        if (!controller || !spot)
        {
            return;
        }

        if (!controller.isON)
        {
            spot.intensity = 0f;
            spot.range = 0f;
            return;
        }

        float baseIntensity = spot.intensity;
        float baseRange = spot.range;

        spot.intensity = Mathf.Lerp(minIntensity, baseIntensity, battery);
        spot.range = Mathf.Lerp(minRange, baseRange, battery);
    }
}
