using NUnit.Framework;
using Playnite.Tests;

namespace ExoDosLibrary.Tests
{
    [TestFixture]
    class ExoDosLibraryTests
    {
        public static ExoDosLibrary CreateLibrary()
        {
            return new ExoDosLibrary(PlayniteTests.GetTestingApi().Object);
        }

        [Test]
        public void GetInstalledGamesTest()
        {
            var Library = CreateLibrary();
            var Games = Library.GetGames();
            CollectionAssert.IsNotEmpty(Games);
        }
    }
}
