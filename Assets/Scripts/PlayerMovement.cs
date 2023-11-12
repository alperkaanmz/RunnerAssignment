using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    float speed = 0.075f;
    public GameObject Girl;
    bool tapToStart = false;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (tapToStart == true)
            transform.Translate(Vector3.forward * speed);//movement code
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Girl.GetComponent<Animator>().SetBool("Idle", false);
            Girl.GetComponent<Animator>().SetBool("RunStart", true);//reference to the Girl with a game object variable
            tapToStart = true;
        }
        if (Input.GetKeyDown(KeyCode.A))//if I press A it will slide to left
        {
            if (Girl.transform.localPosition.x > -2)
            {
                Girl.transform.DOLocalMoveX(Girl.transform.localPosition.x - 2, 0.5f);//.SetDelay(0.2f);
                
            }
        }
        if (Input.GetKeyDown(KeyCode.D))//if I press D it will slide to right
        {
            if (Girl.transform.localPosition.x < 2)
            {
                Girl.transform.DOLocalMoveX(Girl.transform.localPosition.x + 2, 0.5f);
                
            }
        }
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "LevelFinish")
        {
            Girl.GetComponent<Animator>().SetBool("RunStart", false);
            Girl.GetComponent<Animator>().SetBool("Idle", true);
            tapToStart = false;
            Invoke(nameof(Level2), 2);
        }
    }

    void Level2()
    {
        SceneManager.LoadScene(1);
    }
}
