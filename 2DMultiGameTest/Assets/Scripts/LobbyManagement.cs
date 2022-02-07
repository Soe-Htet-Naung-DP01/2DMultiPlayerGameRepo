using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
public class LobbyManagement : MonoBehaviourPunCallbacks
{
    public InputField createInput;
    public InputField joinInput;
    public InputField nameInput;

    private void Start()
    {
        if(!PlayerPrefs.HasKey("PlayerName"))
        {
            return;
        }
        else
        {
            string PlayerName = PlayerPrefs.GetString("PlayerName");
            nameInput.text = PlayerName;
        }
    }

    public void SetPlayerName()
    {
        string PlayerNickName = nameInput.text;     
        PhotonNetwork.NickName = PlayerNickName;
        PlayerPrefs.SetString("PlayerName", PlayerNickName);
    }
    public void CreateLobbyRoom()
    {
        PhotonNetwork.CreateRoom(createInput.text);
        SetPlayerName();
    }

    public void JoinLobbyRoom()
    {
        PhotonNetwork.JoinRoom(joinInput.text);
        SetPlayerName();
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game");
    }


}
