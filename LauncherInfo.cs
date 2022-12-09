﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEarthLauncher
{
    public class LauncherInfo
    {
        public static LauncherInfo Default
        {
            get => new LauncherInfo(true, Program.GetLocalIPAddress(), false);
        }

        public bool IsStaticIP;
        public string LastIP;
        public bool IsTileServerInstalled;

        public LauncherInfo(bool _staticIP, string _lastIP, bool _tileServerInstalled)
        {
            IsStaticIP = _staticIP;
            LastIP = _lastIP;
            IsTileServerInstalled = _tileServerInstalled;
        }

        public static LauncherInfo Load(string apiDir)
        {
            LauncherInfo info = null;
            try { // legacy support
                info = load(apiDir + "ipInfo.txt");
                if (info != null) {
                    File.Delete(apiDir + "ipInfo.txt");
                    info.Save(apiDir + "PELauncher_config.txt");
                    return info;
                }
            } catch { }
            try {
                info = load(apiDir + "PELauncher_config.txt");
                if (info != null)
                    return info;
            }
            catch { }

            if (info == null) {
                info = Default;
                info.Save(apiDir + "PELauncher_config.txt");
            }

            return info;
        }

        private static LauncherInfo load(string path)
        {
            if (File.Exists(path)) {
                string[] ipInfo = File.ReadAllLines(path);

                bool isIpStatic = true;
                string lastIp = "";
                bool tileServerInstalled = false;
                try {
                    isIpStatic = bool.Parse(ipInfo[0]);
                    lastIp = ipInfo[1];
                    if (ipInfo.Length > 2)
                        tileServerInstalled = bool.Parse(ipInfo[2]);

                    return new LauncherInfo(isIpStatic, lastIp, tileServerInstalled);
                }
                catch {
                    throw new Exception();
                }
            }
            else
                return null;
        }

        public void Save(string path) => File.WriteAllText(path, $"{IsStaticIP}\n{LastIP}\n{IsTileServerInstalled}");
    }
}
