using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemPlus.Extensions;

namespace ProjectEarthLauncher
{
    public static class HelpUtil
    {
        private static Action[] helps = new Action[]// buildplate size
        {
            ARSetup,
            ServerConnectError,
            ApiBuild,
            CloudburstRun,
            BuildPlateRLSize,
        };

        private static int sListIndex = 1;

        public static void ShowHelp(int index)
        {
            if (index >= 0 && index < helps.Length)
                helps[index].Invoke();
            else {
                Console.WriteLine($"No help with index {index}");
            }

            HandleBack();
        }

        private static void ResetShowList() => sListIndex = 1;

        private static void ShowList(string message)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Write(sListIndex + ")", true);
            Console.ResetColor();
            sListIndex++;
            Console.WriteLine(message);
        }

        private static void BuildPlateRLSize()
        {
            Console.WriteLine("Play buildplate in real life size▼");
            Console.WriteLine(" -Navigate to \"Api\\data\\buildplates\" and open the buildplate you want to edit with a text editor");
            Console.WriteLine(" -Change \"blocksPerMeter\" to 1.0");
        }

        private static void CloudburstRun()
        {
            Console.WriteLine("Failed to generate cloudburst files▼");
            Console.WriteLine(" -Make sure you have java 8 installed");
        }

        private static void ApiBuild()
        {
            Console.WriteLine("Failed to build Api▼");
            Console.WriteLine(" -Make sure that you have installed .net sdk 5.0, version is important");
            Console.WriteLine(" -If you have edited the code, it's possible there is an error");
        }

        private static void ServerConnectError()
        {
            Console.WriteLine("Can't connect to server▼");
            Console.WriteLine(" -Make sure you have patched with correct ip (http://192.168.x.x)");
            Console.WriteLine(" -Try to turn off firewall");
            Console.WriteLine(" -Set Wifi as private");
            Console.WriteLine(" -If you have antivirus set your wifi as private, my Wifi or similar");
        }

        private static void ARSetup()
        {
            ResetShowList();

            Console.WriteLine("How to setup the app▼");
            Console.WriteLine("!!!Android Only!!!");
            ShowList("If you don't have it, download Minecraft Earth (can be found here: https://m.apkpure.com/minecraft-earth/com.mojang.minecraftearth/download?from=amp_detail&_gl=11katg20_ga*YW1wLTZaaDJvR1RzOHZEMXhSNDRERDlCcTJqdmx4b3c3UVJOajlteHRncjZocTdyTEc5QWtMUmV1U3hMNzNZV3JHMm8.)");
            ShowList("Download ProjectEarth Patcher app from here: https://ci.rtm516.co.uk/job/ProjectEarth/job/PatcherApp/job/master/lastSuccessfulBuild/artifact/SignApksBuilder-out/AndroidKeys/key0/dev.projectearth.patcher-1.0-unsigned.apk/dev.projectearth.patcher-1.0.apk");
            ShowList("Open the patcher and click the 3 dots in the top rigth corner");
            ShowList("Click settings and tap on \"Locator Server\"");
            ShowList("Delete the default value and enter the ip you have the server setup on (http://192.168.x.x)");
            ShowList("Click OK, go back and click \"Patch and Install\"");
            ShowList("Wait for it to finish and click install");
            ShowList("Click Settings and \"Alow apps from this source\", the click Install, after it's done you can uninstall the patcher and Minecraft Earth");
            ShowList("Start the server and open the Project Earth app whitch has been installed");
            ShowList("You will see a prompt to \"Download Contect\", click Yes (this will download the resource pack)");
            ShowList("Click \"Let's Play\" and sing in with your Microsoft Acount (you might need the Xbox app for this)");
            ShowList("Allow access to location and turn on Location");
            ShowList("Done!");
        }

        private static void HandleBack() => Util.HandleBack();
    }
}
