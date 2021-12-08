using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using Verse;

namespace XDIF
{
	public class StaticFactionIdeoExtension : DefModExtension
	{
		public string name;
		public string adjective;
		public string description;
		public bool? classic;
		public ColorDef colorDef;
		public CultureDef culture;
		public bool? Fluid;
		public IdeoFoundation foundation; //Is it ok that this isn't IdeoFoundationDef?
		public IdeoIconDef iconDef;
		public string leaderTitleFemale;
		public string leaderTitleMale;
		public string memberName;
		public List<MemeDef> memes;
		public List<PreceptDef> preceptsDefs;
		public IdeoStyleTracker style;
		public List<ThingStyleCategoryWithPriority> thingStyleCategories; //Is it ok that this isn't Defs?
		public List<string> usedSymbolPacks;
		public List<string> usedSymbols;
		public string WorshipRoomLabel;
	}
}
