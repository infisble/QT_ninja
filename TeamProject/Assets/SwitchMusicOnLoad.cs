using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMusicOnLoad : MonoBehaviour
{

    public AudioClip newTrack;

    private BGmusic theAM;
    // Start is called before the first frame update
    void Start()
    {
        theAM = FindObjectOfType<BGmusic>();

        if(newTrack != null)
            theAM.ChangeBGM(newTrack);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
