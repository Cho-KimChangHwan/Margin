using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class StatSerialize : MonoBehaviourPunCallbacks
{
    string fuckfuckfuck = "";
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        
        if (stream.IsWriting)
        {
            // We own this player: send the others our data
            stream.SendNext(fuckfuckfuck);
            //stream.SendNext(Health);
        }
        else
        {
            // Network player, receive data
            this.fuckfuckfuck = (string)stream.ReceiveNext();
            Debug.Log(fuckfuckfuck);
            //this.Health = (float)stream.ReceiveNext();
        }
    }
}
