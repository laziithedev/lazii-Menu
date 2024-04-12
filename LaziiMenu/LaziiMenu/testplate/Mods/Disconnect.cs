using Photon.Pun;
using System;
using System.Collections.Generic;
using System.Text;

namespace EclipseMenu.Mods
{
    internal class Disconnect
    {
        public static void Disc()
        {
            PhotonNetwork.Disconnect();
        }
    }
}
