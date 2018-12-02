using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveAnimation : MonoBehaviour
{

	[Header("Animation Variables")] 
	public float dissolveTime;
	
	[Header("Stuff I think")]
	public SpriteMask spriteMask;
	public SpriteRenderer spriteRend;
	public Material dissolveMat;
	
	//Private Variables
	private float time;
	
	void Start ()
	{
		spriteMask = GetComponent<SpriteMask>();
		spriteRend = GetComponent<SpriteRenderer>();
		dissolveMat = GetComponent<Material>();
	}
	
	void Update ()
	{
		time -= Time.deltaTime;
		if (time > dissolveTime)
		{
			//Here I want to change the value of the dissolve effect from 
			//negative to possitive, as if it were dissolving out, then 
			//once complete, stopping the effect, turning off the sprite renderer
		}
	}
}
