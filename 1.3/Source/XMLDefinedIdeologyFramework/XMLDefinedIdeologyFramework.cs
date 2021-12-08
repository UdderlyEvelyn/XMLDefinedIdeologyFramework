using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using Verse;
using HarmonyLib;
using System.Reflection;

namespace XDIF
{
    [StaticConstructorOnStartup]
    public static class XMLDefinedIdeologyFramework
    {
        static XMLDefinedIdeologyFramework()
        {
            var harmony = new Harmony("UdderlyEvelyn.XMLDefinedIdeologyFramework");
            harmony.PatchAll();
        }
	}
}