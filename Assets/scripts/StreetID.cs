using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetID : MonoBehaviour
{
    public int streetID = 0;
    public GameObject doneButton;
    

    private void Start()
    {
        //print(doneButton.transform.rotation);
        //doneButton.transform.rotation = new Quaternion(0, 0, 0, 0);
        //print(doneButton.transform.rotation);
        doneButton.SetActive(false);
    }
}
