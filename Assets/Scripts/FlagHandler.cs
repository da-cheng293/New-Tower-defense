using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlagHandler : MonoBehaviour
{
    public bool flagModel = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setFlagModel(string inStr) {
        flagModel = !flagModel;
        Debug.Log(flagModel);
    }
}
    