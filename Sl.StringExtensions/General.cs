using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Sl.StringExtensions
{
    public static class General
    {
        public static string TrimEveryThing(this string source)
            => Regex.Replace(source, @" {2,}", " ").Trim();


        public static string ToTitleCase(this string source) => ToTitleCase(source, Defaults.DefaultCulture);


        public static string ToTitleCase(this string source, CultureInfo cultureInfo)
        {
            return cultureInfo.TextInfo.ToTitleCase(source.ToLower(cultureInfo));
        }


        private static Dictionary<string, string> replaceDictionary = new Dictionary<string, string>()
        {
            {"ı","i"}, //türkçeler
            {"ü","u"},
            {"ö","o"},
            {"ş","s"},
            {"ğ","g"},
            {"ç","c"},
            {"ä","a"},//a şapkalılar 
            {"ã","a"},
            {"à","a"},
            {"á","a"},
            {"â","a"},
            {"å","a"},
            {"ë","e"}, //e şapkalılar
            {"è","e"},
            {"é","e"},
            {"ê","e"},
            {"ï","i"}, //ı şapkalılar
            {"ì","i"},
            {"í","i"},
            {"î","i"},
            {"õ","o"}, //o şapkalılar
            {"ò","o"},
            {"ó","o"},
            {"ô","o"},
            {"ù","u"}, //u şapkalılar
            {"ú","u"},
            {"û","u"},
            {"ß","ss"},
            {"ñ", "n" }, //ispanya
            {"ý", "y" },
            {"ø", "o" }, //kuzey harfleri
            {"æ", "ae" },
            {"œ", "oe" },
            {"ð", "d" },
            {"þ", "th" },
            {"ƒ", "f" },
            {"_"," "}, //tireler
            {"-",""},
            {"*","" }, //dört işlem
            {"+"," "},
            {"="," "},
            {"\\",""},
            {"/",""},
            {"'",""},  //tırnaklar
            {"‘",""},
            {"’",""},
            {"\""," "},
            {"”"," "},
            {"“"," "},
            {"("," "},  //parantezler
            {")"," "},
            {"["," "},
            {"]"," "},
            {"{"," "},
            {"}"," "},
            {"."," "}, //nokta virgül, soru işareti
            {","," "},
            {"&"," "},
            {"?","" },
            {"!","" },
            {"¿", ""},
            {"¡","" },
            {"@"," " }, //heşteg vs
            {"©"," " },
            {"#"," " },
            {"~"," " }, //tilda milda
            {"¨"," " },
            {"´"," " },
            {"`"," " },
            {"^"," " },
        };

        public static string ToSearchableString(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return str;

            str = str.ToLower();

            foreach (var rep in replaceDictionary.Keys)
            {
                str = str.Replace(rep, replaceDictionary[rep]);
            }

            str = str.TrimEveryThing();


            return str;
        }

    }
}
