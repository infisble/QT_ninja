using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{
    private inventory inventor;
    public GameObject slotButtn;
private void Start()
{

inventor =GameObject.FindGameObjectWithTag("Player").GetComponent<inventory>();
 }
 private void OnTriggerEnter2D(Collider2D other)
 {
 if(other.CompareTag("Player"))
 {
   for(int i =0; i<inventor.slots.Length; i++)
   {
     if(inventor.isFull[i]== false)
        {
         inventor.isFull[i] =true;
        Instantiate(slotButtn, inventor.slots[i].transform);
         Destroy(gameObject);
         break;
        }
    }
 }
 }
}
