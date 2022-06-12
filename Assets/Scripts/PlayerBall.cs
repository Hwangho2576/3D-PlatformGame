using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBall : MonoBehaviour
{
    Rigidbody rigid;
    public float jumpPower;
    bool isJump;
    public GameManager manager;

    private void Start()
    {
        isJump = false;
        rigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(Input.GetButtonDown("Jump") && !isJump)
        {
            isJump = true;
            rigid.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }
    }

    private void FixedUpdate()
    {
        float h, v;
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        rigid.AddForce(new Vector3(h, 0, v), ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            isJump = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Item")
        {
            manager.CurrentItemCount++;
            manager.CurrentItemCountTextChange(manager.CurrentItemCount);
            GetComponent<AudioSource>().Play();
            other.gameObject.SetActive(false);
        }
        else if (other.gameObject.tag == "Goal")
        {
            if(manager.TotalItemCount == manager.CurrentItemCount)
            {
                manager.stage++;
                if (manager.stage == 3) 
                    manager.stage = 0;
                
                SceneManager.LoadScene(manager.stage);
            }
            else
            {
                SceneManager.LoadScene(manager.stage);
            }
        }
    }
}
