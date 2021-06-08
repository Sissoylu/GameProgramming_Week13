using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrier : MonoBehaviour
{

    //bomba bariyere değdiğinde yok edilmeli
    private void OnTriggerEnter(Collider other)
    {
        //bombprefabin tagini ayarlamıştık ve tagi bomb olan obje çarptığında bunu yok et
        if(other.tag.Equals("bomb"))
        {
            other.gameObject.SetActive(false);
        }

    }
}
