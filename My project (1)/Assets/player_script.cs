using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_script : MonoBehaviour
{
[SerializeField] private float _jumpFors;
[SerializeField] private ContactFilter2D _platform;
    // Start is called before the first frame update
 private Rigidbody2D _rigidbody;
 private bool _Stay_platform =>_rigidbody.IsTouching(_platform);
  private  void Awake()
    {
         _rigidbody = GetComponent <Rigidbody2D>();
    }

    // Update is called once per frame
   public  void Jump()
    {
        if(_Stay_platform== true )
        _rigidbody.AddForce(Vector2.up *_jumpFors,ForceMode2D.Impulse);
    }
}
