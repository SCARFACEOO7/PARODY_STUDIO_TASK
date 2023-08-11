using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityChanger : MonoBehaviour
{
    public Transform room;
    public float rotationSpeed = 100f;
    [SerializeField] private GameObject holoPrefabUp;
    [SerializeField] private GameObject holoPrefabFront;
    [SerializeField] private GameObject holoPrefabLeft;
    [SerializeField] private GameObject holoPrefabRight;

    Dictionary<int, GameObject> holos = new Dictionary<int, GameObject>();


    

    private void Start() 
    {
        holos.Add(0, holoPrefabUp);
        holos.Add(1, holoPrefabFront);
        holos.Add(2, holoPrefabLeft);
        holos.Add(3, holoPrefabRight);
        


    }

    void Update()
    {
        int holoID = -1;
        if(Input.GetKey(KeyCode.UpArrow))
        {
            holoID = 0;
        }
        if(Input.GetKey(KeyCode.DownArrow))
        {
            holoID = 1;
        }
        if(Input.GetKey(KeyCode.RightArrow))
        {
            holoID = 2;
        }
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            holoID = 3;
        }


       SetNeededHoloActive(holoID);
       if(Input.GetKey(KeyCode.Return))
       {
        Rotate(holoID);
       }
    
    }

    void Rotate(int holoID)
    {
        RaycastHit hit;
        if(Physics.Raycast(holos[holoID].transform.position,-holos[holoID].transform.up, out hit, Mathf.Infinity))
        room.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(hit.point.x, hit.point.y, hit.point.z), rotationSpeed * Time.deltaTime);

        
    }
    
    

    

    void SetNeededHoloActive(int holoId)
    {
        foreach(var holo in holos)
        {
            if(holo.Key == holoId && holoId != -1)
            {
                holos[holo.Key].SetActive(true);
            }
            else
            {
                holos[holo.Key].SetActive(false);
            }
        }
        
    }

    
    
   
}
