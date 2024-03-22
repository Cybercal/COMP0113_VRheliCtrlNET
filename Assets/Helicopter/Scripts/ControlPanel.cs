using System;
using System.Collections.Generic;
using UnityEngine;

public class ControlPanel : MonoBehaviour {
    public AudioSource MusicSound;
    public bool hovered_speedUp = false;
    public bool hovered_speedDown = false;
    public bool hovered_forward = false;
    public bool hovered_backward = false;
    public bool hovered_left = false;
    public bool hovered_right = false;

    [SerializeField]
    KeyCode SpeedUp = KeyCode.Space;
    [SerializeField]
    KeyCode SpeedDown = KeyCode.C;
    [SerializeField]
    KeyCode Forward = KeyCode.W;
    [SerializeField]
    KeyCode Back = KeyCode.S;
    [SerializeField]
    KeyCode Left = KeyCode.A;
    [SerializeField]
    KeyCode Right = KeyCode.D;
    [SerializeField]
    KeyCode TurnLeft = KeyCode.Q;
    [SerializeField]
    KeyCode TurnRight = KeyCode.E;
    [SerializeField]
    KeyCode MusicOffOn = KeyCode.M;
    
    private KeyCode[] keyCodes;

    public Action<PressedKeyCode[]> KeyPressed;
    private void Awake()
    {
        keyCodes = new[] {
                            SpeedUp,
                            SpeedDown,
                            Forward,
                            Back,
                            Left,
                            Right,
                            TurnLeft,
                            TurnRight
                        };

    }

    void Start () {
 
 }

    public void changeHovered_speedUp()
    {
        hovered_speedUp = true;
    }
    public void changeHovered_speedDown()
    {
        hovered_speedDown = true;
    }
    public void changeHovered_forward()
    {
        hovered_forward = true;
    }
    public void changeHovered_backward()
    {
        hovered_backward = true;
    }
    public void changeHovered_left()
    {
        hovered_left = true;
    }
    public void changeHovered_right()
    {
        hovered_right = true;
    }


 void FixedUpdate ()
 {
     var pressedKeyCode = new List<PressedKeyCode>();
     for (int index = 0; index < keyCodes.Length; index++)
     {
        var keyCode = keyCodes[index];
 
        if (hovered_speedUp)
        {
            pressedKeyCode.Add((PressedKeyCode)0);
            hovered_forward = false;
            hovered_backward = false;
        }
        if (hovered_speedDown)
        {   
            pressedKeyCode.Add((PressedKeyCode)1);
            hovered_forward = false;
            hovered_backward = false;
        }
        if (hovered_forward)
        {
            pressedKeyCode.Add((PressedKeyCode)2);
     
        }   
        if (hovered_backward)
        {
            pressedKeyCode.Add((PressedKeyCode)3);
       
        }
        if (hovered_left)
        {
            pressedKeyCode.Add((PressedKeyCode)6);
            hovered_forward = false;
            hovered_backward = false;
     
        }

        if (hovered_right)
        {
            pressedKeyCode.Add((PressedKeyCode)7);
            hovered_forward = false;
            hovered_backward = false;
       
        }

     }

     hovered_speedUp = false;
     hovered_speedDown = false;
     //hovered_forward = false;
     //hovered_backward = false;
     hovered_left = false;
     hovered_right = false;
 


     //if (KeyPressed != null)
     KeyPressed(pressedKeyCode.ToArray());

        // for test
        if (Input.GetKey(MusicOffOn))
        {
           if (  MusicSound.volume == 1) return;
/*            if (MusicSound.isPlaying)
                MusicSound.Stop();
            else*/
                MusicSound.volume = 1;
                MusicSound.Play();
        }
      
 }
}