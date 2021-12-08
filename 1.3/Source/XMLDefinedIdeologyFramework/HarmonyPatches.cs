using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using Verse;
using RimWorld;
using System.Reflection;

namespace XDIF
{
	[HarmonyPatch(typeof(RockNoises), "Init")]
	class HarmonyPatches
	{

		[HarmonyPatch(typeof(FactionIdeosTracker), "ChooseOrGenerateIdeo")]
		public static class ChooseOrGenerateIdeo_Patch_StaticIdeo
		{
			public static void Postfix(FactionIdeosTracker __instance, IdeoGenerationParms parms)
			{
				StaticFactionIdeoExtension extension = parms.forFaction.GetModExtension<StaticFactionIdeoExtension>();
				if (extension != null && ModsConfig.IdeologyActive && !parms.forceNoExpansionIdeo)
				{
					FieldInfo primIdeo = __instance.GetType().GetField("primaryIdeo", BindingFlags.Instance | BindingFlags.NonPublic);
					Ideo staticIdeo = (Ideo)primIdeo.GetValue(__instance);

					staticIdeo.adjective = extension.adjective ?? staticIdeo.adjective;
					staticIdeo.classic = extension.classic ?? staticIdeo.classic;
					staticIdeo.colorDef = extension.colorDef ?? staticIdeo.colorDef;
					staticIdeo.culture = extension.culture ?? staticIdeo.culture;
					staticIdeo.description = extension.description ?? staticIdeo.description;
					staticIdeo.Fluid = extension.Fluid ?? staticIdeo.Fluid;
					staticIdeo.foundation = extension.foundation ?? staticIdeo.foundation;
					staticIdeo.iconDef = extension.iconDef ?? staticIdeo.iconDef;
					staticIdeo.id = Find.UniqueIDsManager.GetNextIdeoID();
					staticIdeo.leaderTitleFemale = extension.leaderTitleFemale ?? staticIdeo.leaderTitleFemale;
					staticIdeo.leaderTitleMale = extension.leaderTitleMale ?? staticIdeo.leaderTitleMale;
					staticIdeo.memberName = extension.memberName ?? staticIdeo.memberName;
					staticIdeo.memes = extension.memes ?? staticIdeo.memes;
					staticIdeo.name = extension.name ?? staticIdeo.name;
					//staticIdeo.primaryFactionColor = extension.primaryFactionColor ?? staticIdeo.primaryFactionColor; //I don't think this will work cuz Unity class.
					//staticIdeo.style = extension.style ?? staticIdeo.style; //This one might be annoying to implement... is it relevant given the below one?
					staticIdeo.thingStyleCategories = extension.thingStyleCategories ?? staticIdeo.thingStyleCategories;
					staticIdeo.usedSymbolPacks = extension.usedSymbolPacks ?? staticIdeo.usedSymbolPacks;
					staticIdeo.usedSymbols = extension.usedSymbols ?? staticIdeo.usedSymbols;
					staticIdeo.WorshipRoomLabel = extension.WorshipRoomLabel ?? staticIdeo.WorshipRoomLabel;
					
					if (extension.preceptsDefs != null)
					{
						List<Precept> precepts = (from precept in extension.preceptsDefs select PreceptMaker.MakePrecept(precept)).ToList();
						staticIdeo.GetType().GetField("precepts", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(staticIdeo, precepts);
					}

					__instance.RemoveAll();
					primIdeo.SetValue(__instance, staticIdeo);
				}
			}
		}
	}
}
