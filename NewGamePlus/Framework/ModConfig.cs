using System;
using System.Collections.Generic;

namespace NewGamePlus.Framework
{
    internal class ModConfig
    {
        /*********
        ** Accessors
        *********/
        public readonly Dictionary<string, bool> Config = new Dictionary<string, bool>
        {
            ["professions"] = true,
            ["experience"] = false,
            ["stardrops"] = true,
            ["crafting_recipes"] = true,
            ["cooking_recipes"] = true,
            ["newgame_tools"] = true,
            ["newgame_money"] = true,
            ["newgame_assets"] = true,
        };

        // DO NOT EDIT FOLLOWING LINES MANUALLY
        public Dictionary<string, object> flags = new Dictionary<string, object>();
        public SortedSet<int> Professions { get; set; } = new SortedSet<int>();
        public int[] Experience = new int[6];
        public List<string> Stardrops { get; set; } = new List<string>();
        public List<string> CraftingRecipes { get; set; } = new List<string>();
        public List<string> CookingRecipes { get; set; } = new List<string>();


        /*********
        ** Public methods
        *********/
        public bool GetConfig(string key, bool defValue = true)
        {
            if (Config.ContainsKey(key))
                return Config[key];
            return defValue;
        }

        public void SetFlag(string key, object value)
        {
            flags.Remove(key);
            flags.Add(key, value);
        }

        public void SetFlagIfGreater(string key, decimal value)
        {
            if (flags.ContainsKey(key))
                SetFlag(key, Math.Max(value, int.Parse(GetFlag(key, 0).ToString())));
            else
                SetFlag(key, value);
        }

        public object GetFlag(string key, object def = null)
        {
            if (flags.ContainsKey(key))
                return flags[key];
            return def;
        }

        public decimal GetFlagDecimal(string key, decimal dflt = 0)
        {
            decimal ret = dflt;
            if (flags.ContainsKey(key))
                decimal.TryParse(flags[key].ToString(), out ret);
            return ret;
        }

        public bool GetFlagBoolean(string key, bool dflt = false)
        {
            bool ret = dflt;
            if (flags.ContainsKey(key))
                return bool.TryParse(flags[key].ToString(), out ret);
            return ret;
        }
    }
}
