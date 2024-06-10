using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFunc : MonoBehaviour
{
    public GameObject prefab;
    public Transform pos;

    public GameObject prefab2; // Второй префаб
    public Transform pos2; // Вторая позиция

    public GameObject prefab3; // Третий префаб
    public Transform pos3; // Третья позиция

    private List<GameObject> objects = new List<GameObject>();

    public void CreateObject()
    {
        GameObject newObj = Instantiate (prefab, pos.position, pos.rotation);
        objects.Add(newObj);
    }


     public void CreateObject2()
    {
        GameObject newObj2 = Instantiate(prefab2, pos2.position, pos2.rotation);
        objects.Add(newObj2);
    }

    public void CreateObject3()
    {
        GameObject newObj3 = Instantiate(prefab3, pos3.position, pos3.rotation);
        objects.Add(newObj3);
    }

    public void DeleteObject()
    {
        foreach(GameObject obj in objects)
        {
            Destroy(obj);
        }

        objects.Clear();
    }

    
}
