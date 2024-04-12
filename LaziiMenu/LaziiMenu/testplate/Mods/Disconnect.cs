using Photon.Pun;
using System;
using System.Collections.Generic;
using System.Text;

namespace laziiMenu.Mods
{
    internal class Disconnect
    {
        public static void Disc()
        {
            PhotonNetwork.Disconnect();
        }
    }
}
