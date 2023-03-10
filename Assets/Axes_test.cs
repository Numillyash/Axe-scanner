using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axes_test : MonoBehaviour
{
    [Serializable]
    public class SaveData
    {
        public string axe_name;
        public float axe_zero;
        public float axe_max = -5;
        public float axe_min = 5;
        public float axe_pos_min = 5;
        public float axe_neg_min = -5;
    }

    public string axeName = "Axe";
    private float x_pos = 0;
    public SaveData data = new SaveData();
    // Start is called before the first frame update
    void Start()
    {
        x_pos = this.gameObject.transform.position.x;
        data.axe_name = axeName;
    }

    // Update is called once per frame
    void Update()
    {
        var inp = Input.GetAxis(axeName);
        if (inp > data.axe_max)
            data.axe_max = inp;
        if (inp < data.axe_min)
            data.axe_min = inp;
        if (inp > data.axe_neg_min && inp < 0)
            data.axe_neg_min = inp;
        if (inp < data.axe_pos_min && inp > 0)
            data.axe_pos_min = inp;
        inp *= 5;
        this.gameObject.transform.position = new Vector3(x_pos, inp/2, 0);
        this.gameObject.transform.localScale = new Vector3((18f/21), inp>0?inp:(inp == 0 ? 0.1f:inp), 1);
        //Debug.Log(inp);
        
    }

    public void SetZero()
    {
        data.axe_zero = Input.GetAxis(axeName);
    }    
}
