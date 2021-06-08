using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car : MonoBehaviour
{
    Path path;
    int index;
    Vector3 targetPosition;
    public float moveSpeed = 5;
    public bool isLooping;
    // Start is called before the first frame update
    void Start()
    {
        path = FindObjectOfType<Path>();

        //index başlangıçta 0 olduğu için ilk target 0. index 
        targetPosition = path.getPoint(index);
    }

    // Update is called once per frame
    void Update()
    {
        //var = local değişken
        //targetpos - arabanın pozisyonu bize mesafeyi verecek
        var diff = targetPosition - transform.position;
        float distance = diff.magnitude;
        //Vector3 dir = diff.normalized;
       


        //bir sonraki durağa çok yaklaşıldıysa
        if (distance <0.1f)
        {   
            //yeni bir hedef bul
            SetNewTargetPosition();
        }

        SetCarLookRotation(diff.normalized);

        GoToTarget(diff);
    }


    //arabanın bakma yönü
    private void SetCarLookRotation(Vector3 dir)
    {
        //game objenin hangi duruşa sahip olduğuna ayarlarız quaternion ile
        Quaternion lookRotation = Quaternion.LookRotation(dir);

        //lerp ile dönme hızı ayarlanabilir
        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime*10);
        //transform.rotation = lookRotation; bu da aynı işlem yani arabanın dönüşü ayalandı
    }


    private void SetNewTargetPosition()
    {
        if (isLooping)
        {

            if (index == path.Length -1)
            {
                index = -1;
                //çünkü indexi aşağıda bir kere arttırmıştık o yüzden sıfırladık
            }
        }

        path.SetLineLoop(isLooping);

        if (index < path.Length -1)
        {
            index++;
        }
        //yeni target ataması
        targetPosition = path.getPoint(index);
    }

    private void GoToTarget(Vector3 diff)
    {
        var dir = diff.normalized;
        if (diff.magnitude > 0.1f)
        {
            transform.position += dir*moveSpeed*Time.deltaTime;
        }
        
    }
}
