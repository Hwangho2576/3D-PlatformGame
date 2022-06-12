using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int TotalItemCount = 0;
    public int CurrentItemCount = 0;
    public int stage = 0;
    public Text totalItemCountText;
    public Text currentItemCountText;

    private void Awake()
    {
        totalItemCountText.text = "/ " + TotalItemCount.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(stage);
        }
    }

    public void CurrentItemCountTextChange(int cnt)
    {
        currentItemCountText.text = cnt.ToString();
    }
}
