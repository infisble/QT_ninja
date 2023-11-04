using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rand : MonoBehaviour
{
    private int rand_chose;
    public Sprite[] Choose_sprite;
    // Start is called before the first frame update
    void Start()
    {
        rand_chose = Random.Range(0,Choose_sprite.Length);
        GetComponent<SpriteRenderer>().sprite = Choose_sprite[rand_chose];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
