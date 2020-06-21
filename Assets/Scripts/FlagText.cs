using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlagText : MonoBehaviour
{
    public FlagHandler flag;
    private Text message;
    // Start is called before the first frame update
    void Start()
    {
        message = transform.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(flag.flagModel);
        if (flag.flagModel == true)
        {
            message.text = "ON";
        }
        else
        {
            message.text = "OFF";
        }
    }
}
