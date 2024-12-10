using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class P_Movement : MonoBehaviour, IDataPersistence
{ 
    //public CharacterController control;//float horizontalMove = 0f;
    public Animator animator;
    public Joystick joycon;
    public Rigidbody rigidB;
    bool Walk = false;
    bool Idle = false;
    
    public float moveSpeed;

    // Start is called before the first frame update

    void Start()
    {
        Vector3 playerpos = this.transform.position;
        Debug.Log(playerpos.x+" ,"+playerpos.y+" ,"+playerpos.z);


    }
    // Update is called once per frame
    
    void FixedUpdate()
    {

        rigidB.velocity = new Vector3(joycon.Horizontal * 8f, rigidB.velocity.y, joycon.Vertical * 8f);
        
        

        if (joycon.Horizontal != 0 || joycon.Vertical != 0)
        {
            Idle = false;
            animator.SetBool("Idle", false);
            Walk = true;
            animator.SetBool("Walk", true);
            transform.rotation = Quaternion.LookRotation(rigidB.velocity);
        }
        else
        {
            Idle = true;
            animator.SetBool("Idle", true);
            Walk = false;
            animator.SetBool("Walk", false);
        }
    }

   /* public object CaptureState()
    {
        float[] position = new float[] { transform.position.x, transform.position.y, transform.position.z };      
        return position;
    }

    public void RestoreState(object state)
    {
       var position = (float[])state;
       transform.position = new Vector3(position[0], position[1], position[2]);   
    }*/

    public void LoadData(GameData data)
    {
        this.transform.position = data.playerPosition;
    }

    public void SaveData(GameData data)
    {
     data.playerPosition = this.transform.position;
    }
}
