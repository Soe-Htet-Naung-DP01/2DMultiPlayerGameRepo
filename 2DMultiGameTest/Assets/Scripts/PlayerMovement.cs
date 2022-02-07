using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 3f;
    public Text playerName;
    Animator anim;
    PhotonView view;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        view = GetComponent<PhotonView>();

        //Name
        if (!view.IsMine)
        {
            playerName.text = view.Owner.NickName;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(view.IsMine)
        {
            Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
            transform.position += input.normalized * playerSpeed * Time.deltaTime;

            if(input == Vector3.zero)
            {
                anim.SetBool("isRunning", false);
            }
            else
            {
                anim.SetBool("isRunning", true);
            }


        }
        

    }
}
