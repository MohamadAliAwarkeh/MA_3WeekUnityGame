using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX_Object : MonoBehaviour
{
    public bool Enable = false;

    public enum SFX_Type
    {
        Other
    }
    ;

    public SFX_Type type;
    [Range(0, 1)]
    public float Volume = 0.5f;
    public int SoundClip_Code;

    // Use this for initialization
    void OnEnable()
    {
        StartCoroutine(EndOfFramePlayer());
    }

    //wait till all variables are changed before playing
    IEnumerator EndOfFramePlayer()
    {
        yield return new WaitForEndOfFrame();
        if (Enable == true)
        {
            Play_1_shot();
        }
    }

    public void Play_1_shot()
    {
        //Debug.Log ("Play one shot " + SoundClip_Code + "          Gameobject name :  " + this.gameObject.name);
        switch (type)
        {
            case SFX_Type.Other:
                if (SoundClip_Code < SFX_DB.instance.sfx_oth.Length)
                    AudioSource.PlayClipAtPoint(SFX_DB.instance.sfx_oth[SoundClip_Code].SoundClip, Camera.main.transform.position, Volume);
                break;
        }
    }
}
