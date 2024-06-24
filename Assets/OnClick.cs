using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClick : MonoBehaviour
{
    public GameObject onClickPopup;


    // Start is called before the first frame update
    void Start()
    {
     
    }

    public void Click()
    {
        onClickPopup.SetActive(true);


    }

   

}
