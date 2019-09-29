using NUnit.Framework;
using ExoDosLibrary;
using System;

namespace ExoDosLibraryTests
{
    public class ExoDosIniUnitTests
    {
        private ExoDosIni Ini11thHour = new ExoDosIni();
        private ExoDosIni IniAvenger = new ExoDosIni();

        [SetUp]
        public void Setup()
        {
            //Ini11thHour.ReadIniFile(@"J:\Emuladores\eXoDOS\Games\!dos\11thHour\Meagre\IniFile\11th Hour, The (1995).ini");
            Ini11thHour.ReadIniFile(TestContext.CurrentContext.TestDirectory + @"\..\..\TestFiles\11th Hour, The (1995).ini");
            IniAvenger.ReadIniFile(TestContext.CurrentContext.TestDirectory + @"\..\..\TestFiles\Avenger (1997).ini");
        }

        [Test]
        public void TestReadIniFile11thHour()
        {
            Assert.IsNull(Ini11thHour.Number);
            Assert.AreEqual("11th Hour, The", Ini11thHour.Name);
            Assert.IsNull(Ini11thHour.Folder);
            Assert.IsNull(Ini11thHour.Subfolder);
            Assert.AreEqual("Adventure", Ini11thHour.Genre);
            Assert.AreEqual("Mystery", Ini11thHour.SubGenre);
            Assert.AreEqual("Horror", Ini11thHour.SubGenre2);
            Assert.AreEqual("Virgin Interactive Entertainment, Inc.", Ini11thHour.Publisher);
            Assert.AreEqual("Trilobyte, Inc.", Ini11thHour.Developer);
            Assert.AreEqual("1995", Ini11thHour.Year);
            Assert.AreEqual("11th Hour, The (1995).bat", Ini11thHour.Executable);
            Assert.AreEqual("Default.conf", Ini11thHour.DBConfScummID);
            Assert.IsNull(Ini11thHour.Emulator);
            Assert.AreEqual("Install.bat", Ini11thHour.Setup);
            Assert.AreEqual("front.jpg", Ini11thHour.Front01);
            Assert.AreEqual("back.jpg", Ini11thHour.Back01);
            Assert.AreEqual("media.jpg", Ini11thHour.Media01);
            Assert.AreEqual("title.png", Ini11thHour.Title01);
            Assert.AreEqual("screen.png", Ini11thHour.Screen01);
            Assert.AreEqual("The_11th_Hour_-_Manual_-_PC.pdf", Ini11thHour.Manual);
            Assert.AreEqual("DOS", Ini11thHour.Platform);
            Assert.AreEqual("Graeme J. Devine", Ini11thHour.Designer);
            Assert.AreEqual("Matthew J. Costello", Ini11thHour.Designer2);
            Assert.AreEqual("7th Guest Series", Ini11thHour.Series);
            Assert.AreEqual("MobyGames", Ini11thHour.Extra1);
            Assert.AreEqual(@"http://www.mobygames.com/game/11th-hour", Ini11thHour.ExtraLink1);
            Assert.AreEqual("Errata Card", Ini11thHour.Extra2);
            Assert.AreEqual("The_11th_Hour_-_Errata_Card_-_PC.pdf", Ini11thHour.ExtraLink2);
            Assert.IsNull(Ini11thHour.Extra3);
            Assert.IsNull(Ini11thHour.ExtraLink3);
            Assert.IsNull(Ini11thHour.Extra4);
            Assert.IsNull(Ini11thHour.ExtraLink4);
            Assert.IsNull(Ini11thHour.Extra5);
            Assert.IsNull(Ini11thHour.ExtraLink5);
            Assert.IsNull(Ini11thHour.Extra6);
            Assert.IsNull(Ini11thHour.ExtraLink6);
            Assert.IsNull(Ini11thHour.Extra7);
            Assert.IsNull(Ini11thHour.ExtraLink7);
            Assert.IsNull(Ini11thHour.Extra8);
            Assert.IsNull(Ini11thHour.ExtraLink8);
            Assert.IsNull(Ini11thHour.Extra9);
            Assert.IsNull(Ini11thHour.ExtraLink9);
            Assert.AreEqual("about.txt", Ini11thHour.About);
            Assert.IsNull(Ini11thHour.Rating);
            Assert.IsNull(Ini11thHour.CustomEmuPath);
        }

        [Test]
        public void TestGetNormalizedName()
        {
            Assert.AreEqual("The 11th Hour", Ini11thHour.GetNormalizedName());
        }

        [Test]
        public void TestGetGenres11thHour()
        {
            var Genres = Ini11thHour.GetGenres();
            Assert.IsNotNull(Genres);
            Assert.AreEqual(3, Genres.Count);
            Assert.AreEqual("Adventure", Genres[0]);
            Assert.AreEqual("Mystery", Genres[1]);
            Assert.AreEqual("Horror", Genres[2]);
        }

        [Test]
        public void TestGetReleaseDate11thHour()
        {
            Assert.IsNotNull(Ini11thHour.GetReleaseDate());
            Assert.That(Ini11thHour.GetReleaseDate().HasValue);
            DateTime ReleaseDate = Ini11thHour.GetReleaseDate().Value;
            Assert.IsNotNull(ReleaseDate);
            Assert.AreEqual(1995, ReleaseDate.Year);
            Assert.AreEqual(1, ReleaseDate.Month);
            Assert.AreEqual(1, ReleaseDate.Day);
        }

        [Test]
        public void TestGetIntYear11thHour()
        {
            Assert.AreEqual(1995, Ini11thHour.GetYear());
        }

        [Test]
        public void TestGetDesigners11thHour()
        {
            var Designers = Ini11thHour.GetDesigners();
            Assert.IsNotNull(Designers);
            Assert.AreEqual(2, Designers.Count);
            Assert.AreEqual("Graeme J. Devine", Designers[0]);
            Assert.AreEqual("Matthew J. Costello", Designers[1]);
        }

        [Test]
        public void TestDesignedBy11thHour()
        {
            Assert.AreEqual("Designed by Graeme J. Devine, Matthew J. Costello", Ini11thHour.GetDesignedBy());
        }

        [Test]
        public void TestCoverImageRelativePath11thHour()
        {
            Assert.AreEqual(@"\Meagre\Front\front.jpg", Ini11thHour.GetCoverImageRelativePath());
        }

        [Test]
        public void TestGameImageRelativePath11thHour()
        {
            Assert.AreEqual(@"\Meagre\Screen\screen.png", Ini11thHour.GetGameImageRelativePath());
        }

        [Test]
        public void TestGetExtras11thHour()
        {
            Assert.AreEqual("MobyGames", Ini11thHour.GetExtra(1));
            Assert.AreEqual(@"http://www.mobygames.com/game/11th-hour", Ini11thHour.GetExtraLink(1));
            Assert.AreEqual("Errata Card", Ini11thHour.GetExtra(2));
            Assert.AreEqual("The_11th_Hour_-_Errata_Card_-_PC.pdf", Ini11thHour.GetExtraLink(2));
            Assert.IsNull(Ini11thHour.GetExtra(3));
            Assert.IsNull(Ini11thHour.GetExtraLink(3));
            Assert.IsNull(Ini11thHour.GetExtra(4));
            Assert.IsNull(Ini11thHour.GetExtraLink(4));
            Assert.IsNull(Ini11thHour.GetExtra(5));
            Assert.IsNull(Ini11thHour.GetExtraLink(5));
            Assert.IsNull(Ini11thHour.GetExtra(6));
            Assert.IsNull(Ini11thHour.GetExtraLink(6));
            Assert.IsNull(Ini11thHour.GetExtra(7));
            Assert.IsNull(Ini11thHour.GetExtraLink(7));
            Assert.IsNull(Ini11thHour.GetExtra(8));
            Assert.IsNull(Ini11thHour.GetExtraLink(8));
            Assert.IsNull(Ini11thHour.GetExtra(9));
            Assert.IsNull(Ini11thHour.GetExtraLink(9));
        }

        [Test]
        public void TestReadIniAvenger()
        {
            Assert.IsNull(IniAvenger.Number);
            Assert.AreEqual("Avenger", IniAvenger.Name);
            Assert.IsNull(IniAvenger.Folder);
            Assert.IsNull(IniAvenger.Subfolder);
            Assert.AreEqual("Action", IniAvenger.Genre);
            Assert.AreEqual("Arcade", IniAvenger.SubGenre);
            Assert.AreEqual("Shooter", IniAvenger.SubGenre2);
            Assert.AreEqual("Deadline", IniAvenger.Publisher);
            Assert.IsNull(IniAvenger.Developer);
            Assert.AreEqual("1997", IniAvenger.Year);
            Assert.AreEqual("Avenger (1997).bat", IniAvenger.Executable);
            Assert.AreEqual("Default.conf", IniAvenger.DBConfScummID);
            Assert.IsNull(IniAvenger.Emulator);
            Assert.AreEqual("Install.bat", IniAvenger.Setup);
            Assert.IsNull(IniAvenger.Front01);
            Assert.IsNull(IniAvenger.Back01);
            Assert.IsNull(IniAvenger.Media01);
            Assert.AreEqual("title.png", IniAvenger.Title01);
            Assert.AreEqual("screen.png", IniAvenger.Screen01);
            Assert.IsNull(IniAvenger.Adv01);
            Assert.IsNull(IniAvenger.Manual);
            Assert.AreEqual("DOS", IniAvenger.Platform);
            Assert.IsNull(IniAvenger.Designer);
            Assert.IsNull(IniAvenger.Designer2);
            Assert.IsNull(IniAvenger.Series);
            Assert.AreEqual("Mobygames", IniAvenger.Extra1);
            Assert.AreEqual(@"http://www.mobygames.com/game/dos/avenger___", IniAvenger.ExtraLink1);
            Assert.IsNull(IniAvenger.Extra2);
            Assert.IsNull(IniAvenger.ExtraLink2);
            Assert.IsNull(IniAvenger.Extra3);
            Assert.IsNull(IniAvenger.ExtraLink3);
            Assert.IsNull(IniAvenger.Extra4);
            Assert.IsNull(IniAvenger.ExtraLink4);
            Assert.IsNull(IniAvenger.Extra5);
            Assert.IsNull(IniAvenger.ExtraLink5);
            Assert.IsNull(IniAvenger.Extra6);
            Assert.IsNull(IniAvenger.ExtraLink6);
            Assert.IsNull(IniAvenger.Extra7);
            Assert.IsNull(IniAvenger.ExtraLink7);
            Assert.IsNull(IniAvenger.Extra8);
            Assert.IsNull(IniAvenger.ExtraLink8);
            Assert.IsNull(IniAvenger.Extra9);
            Assert.IsNull(IniAvenger.ExtraLink9);
            Assert.AreEqual("about.txt", IniAvenger.About);
            Assert.IsNull(IniAvenger.Rating);
            Assert.IsNull(IniAvenger.CustomEmuPath);
        }
    }

}