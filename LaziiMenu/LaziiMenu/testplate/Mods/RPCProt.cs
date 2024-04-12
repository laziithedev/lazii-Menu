using Photon.Pun;
using System;
using System.Collections.Generic;
using System.Text;

namespace laziiMenu.Mods
{
    internal class RPCProt
    {
        public static void RPCProtection()
        {

            {
                GorillaNot.instance.rpcErrorMax = int.MaxValue;
                GorillaNot.instance.rpcCallLimit = int.MaxValue;
                GorillaNot.instance.logErrorMax = int.MaxValue;
                PhotonNetwork.RemoveRPCs(PhotonNetwork.LocalPlayer);
                PhotonNetwork.OpCleanRpcBuffer(GorillaTagger.Instance.myVRRig);
                PhotonNetwork.RemoveBufferedRPCs(GorillaTagger.Instance.myVRRig.ViewID, (string)null, (int[])null);
                PhotonNetwork.RemoveRPCsInGroup(int.MaxValue);
                PhotonNetwork.SendAllOutgoingCommands();
                ((MonoBehaviourPunCallbacks)GorillaNot.instance).OnPlayerLeftRoom(PhotonNetwork.LocalPlayer);
            }
        }

    }
}
