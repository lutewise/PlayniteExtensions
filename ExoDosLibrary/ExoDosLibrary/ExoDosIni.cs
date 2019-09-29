using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Playnite.SDK.Models;

namespace ExoDosLibrary
{
    public class ExoDosIni
    {
        public string Number { get; set; }
        public string Name { get; set; }
        public string Folder { get; set; }
        public string Subfolder { get; set; }
        public string Genre { get; set; }
        public string SubGenre { get; set; }
        public string SubGenre2 { get; set; }
        public string Publisher { get; set; }
        public string Developer { get; set; }
        public string Year { get; set; }
        public string Executable { get; set; }
        public string DBConfScummID { get; set; }
        public string Emulator { get; set; }
        public string Setup { get; set; }
        public string Front01 { get; set; }
        public string Back01 { get; set; }
        public string Media01 { get; set; }
        public string Title01 { get; set; }
        public string Screen01 { get; set; }
        public string Adv01 { get; set; }
        public string Manual { get; set; }
        public string Platform { get; set; }
        public string Designer { get; set; }
        public string Designer2 { get; set; }
        public string Series { get; set; }
        public string Series2 { get; set; }
        public string Extra1 { get; set; }
        public string ExtraLink1 { get; set; }
        public string Extra2 { get; set; }
        public string ExtraLink2 { get; set; }
        public string Extra3 { get; set; }
        public string ExtraLink3 { get; set; }
        public string Extra4 { get; set; }
        public string ExtraLink4 { get; set; }
        public string Extra5 { get; set; }
        public string ExtraLink5 { get; set; }
        public string Extra6 { get; set; }
        public string ExtraLink6 { get; set; }
        public string Extra7 { get; set; }
        public string ExtraLink7 { get; set; }
        public string Extra8 { get; set; }
        public string ExtraLink8 { get; set; }
        public string Extra9 { get; set; }
        public string ExtraLink9 { get; set; }
        public string About { get; set; }
        public string Rating { get; set; }

        public string CustomEmuPath { get; set; }

        private IniParser.Model.IniData IniData;
        private IniParser.Model.KeyDataCollection IniMain;

        private string Trim(string str)
        {
            if (String.IsNullOrWhiteSpace(str)) { return null; }
            return str.Trim();
        }

        public void ReadIniFile(string IniFilePath)
        {
            var IniParser = new IniParser.FileIniDataParser();
            IniParser.Parser.Configuration.AllowDuplicateKeys = true;
            IniParser.Parser.Configuration.OverrideDuplicateKeys = false;
            IniParser.Parser.Configuration.SkipInvalidLines = true;
            IniParser.Parser.Configuration.AllowDuplicateSections = true;
            IniParser.Parser.Configuration.AllowKeysWithoutSection = true;
            IniData = IniParser.ReadFile(IniFilePath);
            IniMain = IniData["Main"];
            if (IniMain == null) return;
            Number = Trim(IniMain["Number"]);
            Name = Trim(IniMain["Name"]);
            Folder = Trim(IniMain["Folder"]);
            Subfolder = Trim(IniMain["Subfolder"]);
            Genre = Trim(IniMain["Genre"]);
            SubGenre = Trim(IniMain["SubGenre"]);
            SubGenre2 = Trim(IniMain["SubGenre2"]);
            Publisher = Trim(IniMain["Publisher"]);
            Developer = Trim(IniMain["Developer"]);
            Year = Trim(IniMain["Year"]);
            Executable = Trim(IniMain["Executable"]);
            DBConfScummID = Trim(IniMain["DBConf/ScummID"]);
            Emulator = Trim(IniMain["Emulator"]);
            Setup = Trim(IniMain["Setup"]);
            Setup = Trim(IniMain["Setup"]);
            Front01 = Trim(IniMain["Front01"]);
            Back01 = Trim(IniMain["Back01"]);
            Media01 = Trim(IniMain["Media01"]);
            Title01 = Trim(IniMain["Title01"]);
            Screen01 = Trim(IniMain["Screen01"]);
            Adv01 = Trim(IniMain["Adv01"]);
            Manual = Trim(IniMain["Manual"]);
            Platform = Trim(IniMain["Platform"]);
            Designer = Trim(IniMain["Designer"]);
            Designer2 = Trim(IniMain["Designer2"]);
            Series = Trim(IniMain["Series"]);
            Series2 = Trim(IniMain["Series2"]);
            Extra1 = Trim(IniMain["Extra1"]);
            ExtraLink1 = Trim(IniMain["ExtraLink1"]);
            Extra2 = Trim(IniMain["Extra2"]);
            ExtraLink2 = Trim(IniMain["ExtraLink2"]);
            Extra3 = Trim(IniMain["Extra3"]);
            ExtraLink3 = Trim(IniMain["ExtraLink3"]);
            Extra4 = Trim(IniMain["Extra4"]);
            ExtraLink4 = Trim(IniMain["ExtraLink4"]);
            Extra5 = Trim(IniMain["Extra5"]);
            ExtraLink5 = Trim(IniMain["ExtraLink5"]);
            Extra6 = Trim(IniMain["Extra6"]);
            ExtraLink6 = Trim(IniMain["ExtraLink6"]);
            Extra7 = Trim(IniMain["Extra7"]);
            ExtraLink7 = Trim(IniMain["ExtraLink7"]);
            Extra8 = Trim(IniMain["Extra8"]);
            ExtraLink8 = Trim(IniMain["ExtraLink8"]);
            Extra9 = Trim(IniMain["Extra9"]);
            ExtraLink9 = Trim(IniMain["ExtraLink9"]);
            About = Trim(IniMain["About"]);
            Rating = Trim(IniMain["Rating"]);
            CustomEmuPath = Trim(IniMain["CustomEmuPath"]);
        }

        public string GetNormalizedName()
        {
            var NormalizedName = Name;
            if (Name.EndsWith(", The"))
            {
                NormalizedName = "The " + Name.Remove(Name.Length - 5, 5);
            }
            return NormalizedName;
        }

        public List<string> GetGenres()
        {
            var Genres = new List<string>();
            if (!String.IsNullOrWhiteSpace(Genre)) { Genres.Add(Genre.Trim()); }
            if (!String.IsNullOrWhiteSpace(SubGenre)) { Genres.Add(SubGenre.Trim()); }
            if (!String.IsNullOrWhiteSpace(SubGenre2)) { Genres.Add(SubGenre2.Trim()); }
            return Genres;
        }

        public DateTime? GetReleaseDate()
        {
            if (GetYear() == 0) { return null; }
            return new DateTime(GetYear(), 1, 1);
        }

        public int GetYear()
        {
            int IntYear = 0;
            if (!int.TryParse(Year.Trim(), out IntYear)) { return 0; }
            return IntYear;
        }

        public List<string> GetDesigners()
        {
            var Designers = new List<string>();
            if (!String.IsNullOrWhiteSpace(Designer)) { Designers.Add(Designer.Trim()); }
            if (!String.IsNullOrWhiteSpace(Designer2)) { Designers.Add(Designer2.Trim()); }
            return Designers;
        }

        public string GetDesignedBy()
        {
            if (String.IsNullOrWhiteSpace(Designer) && String.IsNullOrWhiteSpace(Designer2)) { return ""; }
            var DesignedBy = "Designed by ";
            if (!String.IsNullOrWhiteSpace(Designer)) { DesignedBy += Designer.Trim(); }
            if (!String.IsNullOrWhiteSpace(Designer) && !String.IsNullOrWhiteSpace(Designer2)) { DesignedBy += ", "; }
            if (!String.IsNullOrWhiteSpace(Designer2)) { DesignedBy += Designer2.Trim(); }
            return DesignedBy;
        }

        public string GetCoverImageRelativePath()
        {
            if (String.IsNullOrWhiteSpace(Front01)) { return ""; }
            return @"\Meagre\Front\" + Front01.Trim();
        }

        public string GetGameImageRelativePath()
        {
            if (String.IsNullOrWhiteSpace(Screen01)) { return ""; }
            return @"\Meagre\Screen\" + Screen01.Trim();
        }

        internal string GetDescriptionRelativePath()
        {
            if (String.IsNullOrWhiteSpace(About)) { return ""; }
            return @"\Meagre\About\" + About.Trim();
        }

        public string GetExtra(int i)
        {
            string ExtraStr = "Extra" + i;
            return Trim(IniMain[ExtraStr]);
        }

        public string GetExtraLink(int i)
        {
            string ExtraLinkStr = "ExtraLink" + i;
            return Trim(IniMain[ExtraLinkStr]);
        }

    }
}
