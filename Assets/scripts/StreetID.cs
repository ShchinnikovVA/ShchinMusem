using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetID : MonoBehaviour
{
    public int streetID = 0;
    public GameObject doneButton;
    
    private void Start()
    {
        HideDoneButton();
        this.GetComponent<Collider2D>().enabled = true;
    }
    public void HideDoneButton()
    {
        doneButton.SetActive(false);
    }
}
