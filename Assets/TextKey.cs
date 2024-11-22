using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextKey : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI VarText;
    public int NowTimes=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            string Times = IgaguriController.hittimes.ToString();
            VarText.text = "HIT:" + Times;
    }
}
