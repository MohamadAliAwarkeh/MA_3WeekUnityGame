using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SFX_DB : MonoBehaviour
{

    public static SFX_DB instance;

	public SFX_other[] sfx_oth;

	//singleton
	void Awake ()
	{
		if (instance != null) {
			Destroy (instance.gameObject);
		}
		instance = this;
	}

	[System.Serializable]
	public class SFX_other
	{
		public string Descripion;
		public AudioClip SoundClip;
	}
}
