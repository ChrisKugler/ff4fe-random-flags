using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FF4FEFlagRandomizer
{    
    class Program
    {
        private static Random _rand = new Random();
        [STAThread]
        static void Main(string[] args)
        {               
            var flagDefs = GetFlagDefinitions();

            //for (int i = 0; i < 20; i++)
            //{
            //    var flagset = GetFlagset(flagDefs);
            //    Console.WriteLine(flagset);
            //}

            var flagset = GetFlagset(flagDefs);
            Clipboard.SetText(flagset);          
        }

        private static List<FlagDefinition> GetFlagDefinitions()
        {
            return new List<FlagDefinition>
            {
                new FlagDefinition('V', 2),
                new FlagDefinition('J', 2),
                new FlagDefinition('K', 4),
                new FlagDefinition('P', 2),
                new FlagDefinition('C', 3),
                new FlagDefinition('T', 5),
                new FlagDefinition('S', 5),
                new FlagDefinition('B', 2),
                new FlagDefinition('F', 2),
                new FlagDefinition('N', 2),
                new FlagDefinition('E', 4, 3),
                new FlagDefinition('$', 3),
                new FlagDefinition('X', 2, 2),
                new FlagDefinition('Y', 2, 2),
                new FlagDefinition('G', 1),
                new FlagDefinition('W', 2),
                new FlagDefinition('Z', 1, 1),
            };
        }

        private static string GetFlagset(List<FlagDefinition> defs)
        {                        
            string fs = "";
            foreach(var def in defs)
            {
                fs += def.GetRandom(_rand);
            }
            return fs;
        }

    }

    public struct FlagDefinition
    {
        public char Key;
        public int Modifiers;
        public int? PinnedMod; 

        public FlagDefinition(char key, int mods, int? pinnedMod = null)
        {
            Key = key;
            Modifiers = mods;
            PinnedMod = pinnedMod;
        }

        public string GetRandom(Random rand)
        {
            if(PinnedMod.HasValue)
            {
                return GetFlagString(PinnedMod.Value);
            }

            var mod = rand.Next(0, Modifiers + 1);
            return GetFlagString(mod);           
        }

        private string GetFlagString(int mod)
        {
            if (mod > 0)
            {
                if(mod == 1)
                {
                    return Key.ToString();
                }
                return $"{Key}{mod}";
            }
            return "";
        }
    }
}
