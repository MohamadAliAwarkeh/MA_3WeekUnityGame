using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerRedController : MonoBehaviour 
{

	[Header("Player Variables")] 
	public float moveSpeedX;
	public float moveSpeedY;
	public Shrink spriteMaskPrefab;
	public bool onKeyboard;
	public int numOfMasksSpawnable;
    [Range(100, 200)]public float degreesPerSec;
    public Animator anim;
    public AudioSource audio;
    	
	[Header("Jycon Default Variables")]
    public float[] stick;
    public Vector3 gyro;
    public Vector3 accel;
    public int jc_ind = 0;
    public Quaternion orientation;
	
	//Private Variables
	private List<Joycon> joycons;
	private bool canSpawnSpriteMask;
    private bool isCuttingAnim;

    void Start ()
    {
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();

        gyro = new Vector3(0, 0, 0);
        accel = new Vector3(0, 0, 0);
        // get the public Joycon array attached to the JoyconManager in scene
        joycons = JoyconManager.Instance.j;
		if (joycons.Count < jc_ind+1){
			//Destroy(gameObject);
		}
	}

    void Update () 
    {
	    if (onKeyboard)
	    {
		    UsingKeyboard();
	    }
	    else
	    {
		    JoyconMethod();
	    }

	    if (numOfMasksSpawnable > 0)
	    {
		    canSpawnSpriteMask = true;
            //isCuttingAnim = true;
	    } 
	    else if (numOfMasksSpawnable <= 0)
	    {
		    canSpawnSpriteMask = false;
            //isCuttingAnim = false;
	    }

        if (isCuttingAnim)
        {
            anim.SetBool("isCutting", true);
        }
        else if (!isCuttingAnim)
        {
            anim.SetBool("isCutting", false);
        }
    }

	void JoyconMethod()
	{
		// make sure the Joycon only gets checked if attached
		if (joycons.Count > 0)
        {
			Joycon j = joycons [jc_ind];
	        
	        
			// GetButtonDown checks if a button has been pressed (not held)
	        if (canSpawnSpriteMask)
	        {
                if (j.GetButtonDown(Joycon.Button.SHOULDER_2) && !isCuttingAnim)
		        {
			        //Debug.Log ("Shoulder button 2 pressed");
			        j.SetRumble (160, 320, 0.6f, 200);
			        Shrink spriteMask = Instantiate(spriteMaskPrefab, transform.position, transform.rotation);
                    spriteMask.playerRedController = this;
                    numOfMasksSpawnable--;
                    isCuttingAnim = true;
                    audio.Play();
                } 
	        }
	        
	        
			// GetButtonDown checks if a button has been released
			if (j.GetButtonUp (Joycon.Button.SHOULDER_2))
			{
				//Debug.Log ("Shoulder button 2 released");
                isCuttingAnim = false;
			}
			// GetButtonDown checks if a button is currently down (pressed or held)
			if (j.GetButton (Joycon.Button.SHOULDER_2))
			{
				//Debug.Log ("Shoulder button 2 held");
			}

			if (j.GetButtonDown (Joycon.Button.DPAD_DOWN)) {
				//Debug.Log ("Rumble");
				
				// Rumble for 200 milliseconds, with low frequency rumble at 160 Hz and high frequency rumble at 320 Hz. For more information check:
				// https://github.com/dekuNukem/Nintendo_Switch_Reverse_Engineering/blob/master/rumble_data_table.md

				//j.SetRumble (160, 320, 0.6f, 200);

				// The last argument (time) in SetRumble is optional. Call it with three arguments to turn it on without telling it when to turn off.
                // (Useful for dynamically changing rumble values.)
				// Then call SetRumble(0,0,0) when you want to turn it off.
			}

            stick = j.GetStick();
	        
            // Gyro values: x, y, z axis values (in radians per second)
            gyro = j.GetGyro();

            // Accel values:  x, y, z axis values (in Gs)
            accel = j.GetAccel();

            orientation = j.GetVector();
	        
			if (j.GetButton(Joycon.Button.DPAD_UP))
			{
				transform.Translate(0f, moveSpeedY, 0f, Space.World);
			} else{
				
			}
	        
	        if (j.GetButton(Joycon.Button.DPAD_DOWN))
	        {
		        transform.Translate(0f, -moveSpeedY, 0f, Space.World);
	        } else{
				
	        }
	        
	        if (j.GetButton(Joycon.Button.DPAD_LEFT))
	        {
		        transform.Translate(-moveSpeedX, 0f, 0f, Space.World);
	        } else{
				
	        }
	        
	        if (j.GetButton(Joycon.Button.DPAD_RIGHT))
	        {
		        transform.Translate(moveSpeedX, 0f, 0f, Space.World);
	        } else{
				
	        }
	        
	        float zOnly = orientation.eulerAngles.z;
	        Vector3 newRot = new Vector3(gameObject.transform.localRotation.x, gameObject.transform.localRotation.y, zOnly);
            //gameObject.transform.eulerAngles = newRot; 


            Quaternion targetRotation = Quaternion.Euler(newRot);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, degreesPerSec * Time.deltaTime);
	        
            //gameObject.transform.rotation = orientation;
        }
	}
	
	void UsingKeyboard()
	{
		if (canSpawnSpriteMask)
		{
            if (Input.GetKeyDown(KeyCode.RightShift) && !isCuttingAnim)
			{
                Instantiate(spriteMaskPrefab, transform.position, transform.rotation);
				numOfMasksSpawnable--;
                isCuttingAnim = true;
                audio.Play();
            } else {
                isCuttingAnim = false;
            }
		}
		
		if (Input.GetKey(KeyCode.UpArrow))
		{
			transform.Translate(0f, moveSpeedY, 0f, Space.World);
		} else{
				
		}
	        
		if (Input.GetKey(KeyCode.DownArrow))
		{
			transform.Translate(0f, -moveSpeedY, 0f, Space.World);
		} else{
				
		}
	        
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			transform.Translate(-moveSpeedX, 0f, 0f, Space.World);
		} else{
				
		}
	        
		if (Input.GetKey(KeyCode.RightArrow))
		{
			transform.Translate(moveSpeedX, 0f, 0f, Space.World);
		} else{
				
		}
	}
}