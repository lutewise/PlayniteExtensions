using Playnite.SDK;
using Playnite.SDK.Models;
using Playnite.SDK.Plugins;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExoDosLibrary
{
    public class ExoDosLibrary : LibraryPlugin
    {
        public override string Name => "eXoDOS";

        public override Guid Id => Guid.Parse("5DA89AE6-4779-4BC1-AF30-66B6A5A1FDB9");

        public ExoDosLibrary(IPlayniteAPI api) : base(api)
        {
        }

        public virtual string Source => "eXoDOS";

        public virtual string BaseDir => @"J:\Emuladores\eXoDOS\";
        public virtual string GamesDir { get { return BaseDir + @"Games\!dos\"; } set { GamesDir = value; } }

        public virtual string GetInstallDir(string GameId) { return GamesDir + GameId + @"\"; }

        public virtual string GetBatFile(string GameId)
        {
            var Bats = Directory.GetFiles(GetInstallDir(GameId), "*.bat");
            return Bats.HasItems() ? Bats[0] : null;
        }

        public virtual string GetIniDir(string GameId) { return GetInstallDir(GameId) + @"Meagre\IniFile\"; }
        public virtual string GetIniFile(string GameId)
        {
            var Inis = Directory.GetFiles(GetIniDir(GameId), "*.ini");
            return Inis.HasItems() ? Inis[0] : null;
        }

        public virtual string GetInstallDirUri(string GameId) { return (new System.Uri(GetInstallDir(GameId))).AbsoluteUri; }
        public virtual string GetExtrasDirUri(string GameId) { return GetInstallDirUri(GameId) + @"Meagre/Extras/"; }

        public override IEnumerable<GameInfo> GetGames()
        {
            
            var GameIds = GetGameIds();
            var GameInfos = new List<GameInfo>();
            foreach (var GameId in GameIds)
            {
                var GameInfo = ReadGameInfo(GameId);
                if (GameInfo != null) { GameInfos.Add(GameInfo); }
            }
            
            return GameInfos;
        }

        private GameInfo ReadGameInfo(string GameId)
        {
            var IniFilePath = GetIniFile(GameId);
            var Ini = new ExoDosIni();
            Ini.ReadIniFile(IniFilePath);

            string DescriptionFilePath = GetInstallDir(GameId) + Ini.GetDescriptionRelativePath();
            var Description = File.ReadAllText(DescriptionFilePath);

            //MessageBox.Show("Antes de pegar GameInfo", "eXoDos Library", MessageBoxButtons.OK);
            var gameInfo = new GameInfo()
            {
                // General
                Name = Ini.GetNormalizedName(),
                SortingName = Ini.Name,
                Platform = Ini.Platform, // FIXO
                Genres = Ini.GetGenres(),
                Categories = null,
                Tags = null,
                ReleaseDate = Ini.GetReleaseDate(),
                Series = null,
                AgeRating = null,
                Region = null,
                Source = "eXoDOS", // FIXO
                Version = null,
                UserScore = null,
                CriticScore = null,
                CommunityScore = null,
                Description = Description + "\n\n" + Ini.GetDesignedBy(),

                // Advanced
                LastActivity = null,
                Playtime = 0,
                PlayCount = 0,
                CompletionStatus = CompletionStatus.NotPlayed,
                Hidden = false,
                GameId = GameId,

                // Media
                Icon = null, // @"https://playnite.link/applogo.png",
                CoverImage = GetInstallDir(GameId) + Ini.GetCoverImageRelativePath(),
                BackgroundImage = GetInstallDir(GameId) + Ini.GetGameImageRelativePath(),
                //GameImagePath = null,

                // Links
                Links = GetLinks(GameId, Ini),

                // Installation
                IsInstalled = true,
                InstallDirectory = GetInstallDir(GameId),

                // Actions
                PlayAction = new GameAction()
                {
                    Type = GameActionType.File,
                    Path = GetInstallDir(GameId) + Ini.Executable,
                    Arguments = "",
                    WorkingDir = "{InstallDir}",
                },

            };

            if (String.IsNullOrWhiteSpace(gameInfo.CoverImage)) { gameInfo.CoverImage = gameInfo.BackgroundImage; }
            if (String.IsNullOrWhiteSpace(gameInfo.BackgroundImage)) { gameInfo.BackgroundImage = gameInfo.CoverImage; }

            if (!String.IsNullOrWhiteSpace(Ini.Developer))
            {
                var DeveloperCompany = PlayniteApi.Database.Companies.AsQueryable().Select(c => c.Name == Ini.Developer);
                if (DeveloperCompany == null) { PlayniteApi.Database.Companies.Add(new Company(Ini.Developer)); }
                gameInfo.Developers = new List<string>();
                gameInfo.Developers.Add((string)Ini.Developer);
            }
            if (!String.IsNullOrWhiteSpace(Ini.Publisher))
            {
                var PublisherCompany = PlayniteApi.Database.Companies.AsQueryable().Select(c => c.Name == Ini.Publisher);
                if (PublisherCompany == null) { PlayniteApi.Database.Companies.Add(new Company(Ini.Publisher)); }
                gameInfo.Publishers = new List<string>();
                gameInfo.Publishers.Add((string)Ini.Publisher);
            }

            return gameInfo;
        }

        private IEnumerable<string> GetGameIds()
        {
            var GameIds = Directory.EnumerateDirectories(GamesDir).Select(d => d = Path.GetFileName(d)).OrderBy(d => d);
            return GameIds;
        }

        private bool CheckUrlValid(string UrlStr)
        {
            return Uri.TryCreate(UrlStr, UriKind.Absolute, out Uri UriResult)
                && (UriResult.Scheme == Uri.UriSchemeHttp || UriResult.Scheme == Uri.UriSchemeHttps);
        }

        private string GetUrlHost(string UrlStr)
        {
            if (!Uri.TryCreate(UrlStr, UriKind.Absolute, out Uri UriResult)) { return "unknown"; }
            return UriResult.Host;
        }

        private List<Link> GetLinks(string GameId, ExoDosIni Ini)
        {
            var Links = new List<Link>();
            for (int i = 1; i < 10; i++)
            {
                var ExtraLink = Ini.GetExtraLink(i);
                if (String.IsNullOrWhiteSpace(ExtraLink)) { continue; }
                if (!CheckUrlValid(ExtraLink)) { ExtraLink = GetExtrasDirUri(GameId) + ExtraLink; }

                var Extra = Ini.GetExtra(i);
                if (String.IsNullOrWhiteSpace(Extra)) { Extra = GetUrlHost(ExtraLink);  }

                var Link = new Link(Extra, ExtraLink);
                Links.Add(Link);
            }
            return Links;
        }

    }
}
