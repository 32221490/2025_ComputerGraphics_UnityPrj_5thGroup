using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemCounter : MonoBehaviour
{
    public ItemCollector collector;
    public TextMeshProUGUI label;

    public string format = "{0} / {1}";

    private void LateUpdate()
    {
        if (!collector || !label) return;

        int c = Mathf.Max(0, collector.collected);
        int t = Mathf.Max(1, collector.requiredCount);
       
        label.SetText(format, c, t);
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
