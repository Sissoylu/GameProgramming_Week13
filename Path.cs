using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    [SerializeField]
    private Transform[] waypoints;
    //waypointlerin konumu lazım
    Vector3[] waypointPositions;
    public int Length {get {return waypoints.Length; }}

    //linerenderer pathe bağlı olduğu için direkt alabiliriz.
    LineRenderer lineRenderer {get {return GetComponent<LineRenderer>(); }}

    public void SetLineLoop(bool state)
    {
        //true or false
        lineRenderer.loop = state;
    }




    //awake'ler startlardan önce çalışır
    void Awake()
    {

        //yol çizimi
        //Vect3[] waypointsposition ın memmoryde bir karşılığı yok
        //o yüzden manuel olarak o diziye atama yapmalıyız
        waypointPositions = new Vector3[waypoints.Length];

        //memory ayrımı
        lineRenderer.positionCount = waypointPositions.Length;

        for (int i = 0; i < waypoints.Length; i++)
        {
            waypointPositions[i] = waypoints[i].position;
        }

        //linerenderere konum ataması
        lineRenderer.SetPositions(waypointPositions);
    }

    

    //indexi verilen konumu bize döndür.
    //arabanın ilerlemesi için bu konum bilgisi gerekiyo
    public Vector3 getPoint(int index)
    {
        return waypointPositions[index];
    }
}
