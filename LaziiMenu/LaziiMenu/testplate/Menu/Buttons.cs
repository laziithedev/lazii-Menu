using EclipseMenu.Classes;
using EclipseMenu.Mods;
using static EclipseMenu.Menu.Settings;

namespace EclipseMenu.Menu
{
    internal class Buttons
    {
        public static ButtonInfo[][] buttons = new ButtonInfo[][]
        {
            new ButtonInfo[] { // Main Mods
                new ButtonInfo { buttonText = "Disconnect", method =() => Disconnect.Disc(), isTogglable = false, toolTip = "Disconnect from the current room."},
                new ButtonInfo { buttonText = "Join Discord", method =() => JoinDiscord.joinDiscord(), isTogglable = false, toolTip = "Joins lazii's Discord."},
                new ButtonInfo { buttonText = "Settings", method =() => SettingsMods.EnterSettings(), isTogglable = false, toolTip = "Opens the main settings page for the menu."},
                new ButtonInfo { buttonText = "Trolling Mods", method =() => ghostDisguise.EnterGhosts(), isTogglable = false, toolTip = "Enters the Ghost Disguise mods."},
                new ButtonInfo { buttonText = "Ghost Monke", method =() => Trolling.Ghostmonke(), disableMethod =() => enableMonke.EnableMonke(), toolTip = "Makes You A Ghost"},
                new ButtonInfo { buttonText = "Head Spaz", method =() => headSpaz.headspaz(), disableMethod =() => headSpaz.FixHead(), toolTip = "Gives you a Seziure"},
                new ButtonInfo { buttonText = "Invis Monke", method =() => Trolling.InvisMonke(), disableMethod =() => Trolling.DisableInvis(), toolTip = "Makes You Invisible"},
                new ButtonInfo { buttonText = "NoClip", method =() => noClip.NoClip(), disableMethod =() => Trolling.InvisMonke(), toolTip = "Lets you NoClip"},
                new ButtonInfo { buttonText = "Long Arms", method =() => longArms.LongArms(), disableMethod =() => longArms.LongArmsOff(), toolTip = "Gives you long arms"},
                new ButtonInfo { buttonText = "Platforms", method =() => Platforms.PlatformMod(), toolTip = "Lets you use platforms with Grip"},
                new ButtonInfo { buttonText = "Join Random", method =() => joinRandom.JoinRandom(), isTogglable = false, toolTip = "Joins a Random Lobby."},
                new ButtonInfo { buttonText = "Disable Network Triggers", method =() => networkTriggers.DisableNetworkTriggers(), disableMethod =() => networkTriggers.EnableNetworkTriggers(), toolTip = "Lets you enter diffrent maps without Disconecting"},
                new ButtonInfo { buttonText = "RPC Flush", method =() => RPCProt.RPCProtection(), isTogglable = false, toolTip = "Flushes all incoming Report Requests"},
                new ButtonInfo { buttonText = "Anti Report", method =() => antiReport.AntiReportDisconnect(), toolTip = "Disconnects you when you are about to be reported."},
                new ButtonInfo { buttonText = "Stare", method =() => stareAtNear.StareAtClosest(), toolTip = "Makes your head stare at the nearest player"},
                new ButtonInfo { buttonText = "Lag Gun", method =() => lagGun.laggun(), toolTip = "Makes the targeted person lag"},
                new ButtonInfo { buttonText = "FPS Boost", method =() => FPSBoost.FPSBoostOn(), disableMethod =() => FPSBoost.FPSboostOff(), toolTip = "Gives you a boost in FPS"},
                new ButtonInfo { buttonText = "Tag Gun", method =() => tagGun.TagGun(), toolTip = "Tags the player you had is pointed at"},
                new ButtonInfo { buttonText = "Monke Gun", method =() => MonkeGun.monkeGun(), toolTip = "Moves your monke to the targeted spot"},
                new ButtonInfo { buttonText = "Vibrate Gun", method =() => VibrateGun.vibrateGun(), toolTip = "Vibrates the controller of the targeted player"},
                new ButtonInfo { buttonText = "Grab Gliders", method =() => GliderMods.GrabGliders(), toolTip = "Grabs the gliders"},
                new ButtonInfo { buttonText = "Glider Gun", method =() => GliderMods.GliderGun(), toolTip = "Brings all gliders wherever you want"},
                new ButtonInfo { buttonText = "Accept TOS", method =() => AcceptTOS.AcceptTOSM(), toolTip = "Accepts The TOS"},
                new ButtonInfo { buttonText = "Punch Mod", method =() => PunchMod.GaimingPunchMod(), toolTip = "Lets Others Punch you"},
                new ButtonInfo { buttonText = "Fast Swimmer", method =() => Movement.FasterSwimming(), toolTip = "Makes you an olympic swimmer"},
                new ButtonInfo { buttonText = "Zero Gravity", method =() => Movement.ZeroGravity(), disableMethod =() => Movement.ResetGravity(), toolTip = "Turns off Gravity"},
                new ButtonInfo { buttonText = "Wallwalk", method =() => Movement.WallWalk(), toolTip = "Lets you walk on Walls"},
            },

            new ButtonInfo[] { // Settings
                new ButtonInfo { buttonText = "Return to Main", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Returns to the main page of the menu."},
                new ButtonInfo { buttonText = "Menu", method =() => SettingsMods.MenuSettings(), isTogglable = false, toolTip = "Opens the settings for the menu."},
                new ButtonInfo { buttonText = "Movement", method =() => SettingsMods.MovementSettings(), isTogglable = false, toolTip = "Opens the movement settings for the menu."},
                new ButtonInfo { buttonText = "Projectile", method =() => SettingsMods.ProjectileSettings(), isTogglable = false, toolTip = "Opens the projectile settings for the menu."},
            },

            new ButtonInfo[] { // Menu Settings
                new ButtonInfo { buttonText = "Return to Settings", method =() => SettingsMods.EnterSettings(), isTogglable = false, toolTip = "Returns to the main settings page for the menu."},
                new ButtonInfo { buttonText = "Right Hand", enableMethod =() => SettingsMods.RightHand(), disableMethod =() => SettingsMods.LeftHand(), toolTip = "Puts the menu on your right hand."},
                new ButtonInfo { buttonText = "Notifications", enableMethod =() => SettingsMods.EnableNotifications(), disableMethod =() => SettingsMods.DisableNotifications(), enabled = !disableNotifications, toolTip = "Toggles the notifications."},
                new ButtonInfo { buttonText = "FPS Counter", enableMethod =() => SettingsMods.EnableFPSCounter(), disableMethod =() => SettingsMods.DisableFPSCounter(), enabled = fpsCounter, toolTip = "Toggles the FPS counter."},
                //new ButtonInfo { buttonText = "Disconnect Button", enableMethod =() => SettingsMods.EnableDisconnectButton(), disableMethod =() => SettingsMods.DisableDisconnectButton(), enabled = disconnectButton, toolTip = "Toggles the disconnect button."},
            },

            new ButtonInfo[] { // Movement Settings
                new ButtonInfo { buttonText = "Return to Settings", method =() => SettingsMods.EnterSettings(), isTogglable = false, toolTip = "Returns to the main settings page for the menu."},
            },

            new ButtonInfo[] { // Projectile Settings
                new ButtonInfo { buttonText = "Return to Settings", method =() => SettingsMods.MenuSettings(), isTogglable = false, toolTip = "Opens the settings for the menu."},
            },

            new ButtonInfo[] { // Ghost Mods
                new ButtonInfo { buttonText = "Return to Main Page", method =() => Global.ReturnHome(), isTogglable = false, toolTip = "Sends you back to home page."},
                new ButtonInfo { buttonText = "Become Dasiy09", method =() => dasiy09.BecomeDAISY09(), isTogglable = false, toolTip = "Makes you into Dasiy09"},
                new ButtonInfo { buttonText = "Become J3VU", method =() => dasiy09.BecomeJ3VU(), isTogglable = false, toolTip = "Makes you into J3VU"},
                new ButtonInfo { buttonText = "Become BEES", method =() => dasiy09.BecomeBEES(), isTogglable = false, toolTip = "Makes you into BEES"},
                new ButtonInfo { buttonText = "Become STATUE", method =() => dasiy09.BecomeSTATUE(), isTogglable = false, toolTip = "Makes you into STATUE"},
                new ButtonInfo { buttonText = "Become PBBV", method =() => dasiy09.BecomePBBV(), isTogglable = false, toolTip = "Makes you into PBBV"},
                new ButtonInfo { buttonText = "Become BANSHEE", method =() => dasiy09.BecomeBANSHEE(), isTogglable = false, toolTip = "Makes you into BANSHEE"},
                new ButtonInfo { buttonText = "Become RUNRABBIT", method =() => dasiy09.BecomeRUNRABBIT(), isTogglable = false, toolTip = "Makes you into RUNRABBIT"},
                new ButtonInfo { buttonText = "Become lazii", method =() => dasiy09.Becomelazii(), isTogglable = false, toolTip = "Makes you into lazii, the developer of the menu."},
                new ButtonInfo { buttonText = "Become ECHO", method =() => dasiy09.BecomeECHO(), isTogglable = false, toolTip = "Makes you into ECHO"},
                new ButtonInfo { buttonText = "Become Hidden On Leaderboard", method =() => dasiy09.NONAME(), isTogglable = false, toolTip = "Hides you on the leaderboard"},
            },
        };
    }
}
