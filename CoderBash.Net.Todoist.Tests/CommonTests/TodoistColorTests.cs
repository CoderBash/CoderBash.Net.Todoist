using System;
using CoderBash.Net.Todoist.Common.Enums;
using CoderBash.Net.Todoist.Common.Exceptions;

namespace CoderBash.Net.Todoist.Tests.CommonTests
{
	[TestFixture(
		Author = "Demarbit BV",
		Category = "Todoist.Enums",
		Description = "Todoist Colors tests",
		TestOf = typeof(TodoistColors))]
	public class TodoistColorTests
	{
		[Test(
			Author = "Demarbit BV",
			Description = "Test Get Color Keys")]
		public void Test_Common_TodoistColors_GetKeys()
		{
			Assert.Multiple(() =>
			{
                Assert.That(TodoistColorsUtils.GetColorKey(TodoistColors.BerryRed), Is.EqualTo("berry_red"));
                Assert.That(TodoistColorsUtils.GetColorKey(TodoistColors.Red), Is.EqualTo("red"));
                Assert.That(TodoistColorsUtils.GetColorKey(TodoistColors.Orange), Is.EqualTo("orange"));
                Assert.That(TodoistColorsUtils.GetColorKey(TodoistColors.Yellow), Is.EqualTo("yellow"));
                Assert.That(TodoistColorsUtils.GetColorKey(TodoistColors.OliveGreen), Is.EqualTo("olive_green"));
                Assert.That(TodoistColorsUtils.GetColorKey(TodoistColors.LimeGreen), Is.EqualTo("lime_green"));
                Assert.That(TodoistColorsUtils.GetColorKey(TodoistColors.Green), Is.EqualTo("green"));
                Assert.That(TodoistColorsUtils.GetColorKey(TodoistColors.MintGreen), Is.EqualTo("mint_green"));
                Assert.That(TodoistColorsUtils.GetColorKey(TodoistColors.Teal), Is.EqualTo("teal"));
                Assert.That(TodoistColorsUtils.GetColorKey(TodoistColors.SkyBlue), Is.EqualTo("sky_blue"));
                Assert.That(TodoistColorsUtils.GetColorKey(TodoistColors.LightBlue), Is.EqualTo("light_blue"));
                Assert.That(TodoistColorsUtils.GetColorKey(TodoistColors.Blue), Is.EqualTo("blue"));
                Assert.That(TodoistColorsUtils.GetColorKey(TodoistColors.Grape), Is.EqualTo("grape"));
                Assert.That(TodoistColorsUtils.GetColorKey(TodoistColors.Violet), Is.EqualTo("violet"));
                Assert.That(TodoistColorsUtils.GetColorKey(TodoistColors.Lavender), Is.EqualTo("lavender"));
                Assert.That(TodoistColorsUtils.GetColorKey(TodoistColors.Magenta), Is.EqualTo("magenta"));
                Assert.That(TodoistColorsUtils.GetColorKey(TodoistColors.Salmon), Is.EqualTo("salmon"));
                Assert.That(TodoistColorsUtils.GetColorKey(TodoistColors.Charcoal), Is.EqualTo("charcoal"));
                Assert.That(TodoistColorsUtils.GetColorKey(TodoistColors.Grey), Is.EqualTo("grey"));
                Assert.That(TodoistColorsUtils.GetColorKey(TodoistColors.Taupe), Is.EqualTo("taupe"));
                Assert.That(TodoistColorsUtils.GetColorKey(null), Is.Null);
            });
		}

        [Test(
            Author = "Demarbit BV",
            Description = "Test Get Invalid Color Key")]
        public void Test_Common_TodoistColors_GetInvalidKey()
        {
            Assert.Throws<InvalidKeyException>(() =>
            {
                TodoistColorsUtils.GetColorKey((TodoistColors)100);
            });
        }

        [Test(
            Author = "Demarbit BV",
            Description = "Test Get Color Hex")]
        public void Test_Common_TodoistColors_GetHexValues()
        {
            Assert.Multiple(() =>
            {
                Assert.That(TodoistColorsUtils.GetColorHex(TodoistColors.BerryRed), Is.EqualTo("#b8256f"));
                Assert.That(TodoistColorsUtils.GetColorHex(TodoistColors.Red), Is.EqualTo("#db4035"));
                Assert.That(TodoistColorsUtils.GetColorHex(TodoistColors.Orange), Is.EqualTo("#ff9933"));
                Assert.That(TodoistColorsUtils.GetColorHex(TodoistColors.Yellow), Is.EqualTo("#fad000"));
                Assert.That(TodoistColorsUtils.GetColorHex(TodoistColors.OliveGreen), Is.EqualTo("#afb83b"));
                Assert.That(TodoistColorsUtils.GetColorHex(TodoistColors.LimeGreen), Is.EqualTo("#7ecc49"));
                Assert.That(TodoistColorsUtils.GetColorHex(TodoistColors.Green), Is.EqualTo("#299438"));
                Assert.That(TodoistColorsUtils.GetColorHex(TodoistColors.MintGreen), Is.EqualTo("#6accbc"));
                Assert.That(TodoistColorsUtils.GetColorHex(TodoistColors.Teal), Is.EqualTo("#158fad"));
                Assert.That(TodoistColorsUtils.GetColorHex(TodoistColors.SkyBlue), Is.EqualTo("#14aaf5"));
                Assert.That(TodoistColorsUtils.GetColorHex(TodoistColors.LightBlue), Is.EqualTo("#96c3eb"));
                Assert.That(TodoistColorsUtils.GetColorHex(TodoistColors.Blue), Is.EqualTo("#4073ff"));
                Assert.That(TodoistColorsUtils.GetColorHex(TodoistColors.Grape), Is.EqualTo("#884dff"));
                Assert.That(TodoistColorsUtils.GetColorHex(TodoistColors.Violet), Is.EqualTo("#af38eb"));
                Assert.That(TodoistColorsUtils.GetColorHex(TodoistColors.Lavender), Is.EqualTo("#eb96eb"));
                Assert.That(TodoistColorsUtils.GetColorHex(TodoistColors.Magenta), Is.EqualTo("#e05194"));
                Assert.That(TodoistColorsUtils.GetColorHex(TodoistColors.Salmon), Is.EqualTo("#ff8d85"));
                Assert.That(TodoistColorsUtils.GetColorHex(TodoistColors.Charcoal), Is.EqualTo("#808080"));
                Assert.That(TodoistColorsUtils.GetColorHex(TodoistColors.Grey), Is.EqualTo("#b8b8b8"));
                Assert.That(TodoistColorsUtils.GetColorHex(TodoistColors.Taupe), Is.EqualTo("#ccac93"));
            });
        }

        [Test(
            Author = "Demarbit BV",
            Description = "Test Get Invalid Color Hex")]
        public void Test_Common_TodoistColors_GetInvalidHexValue()
        {
            Assert.Throws<InvalidKeyException>(() =>
            {
                TodoistColorsUtils.GetColorKey((TodoistColors)100);
            });
        }

        [Test(
            Author = "Demarbit BV",
            Description = "Test Get Todoist Colors from name")]
        public void Test_Common_TodoistColors_GetColorFromName()
        {
            Assert.Multiple(() =>
            {
                Assert.That(TodoistColorsUtils.GetFromName("berry_red"), Is.EqualTo(TodoistColors.BerryRed));
                Assert.That(TodoistColorsUtils.GetFromName("red"), Is.EqualTo(TodoistColors.Red));
                Assert.That(TodoistColorsUtils.GetFromName("orange"), Is.EqualTo(TodoistColors.Orange));
                Assert.That(TodoistColorsUtils.GetFromName("yellow"), Is.EqualTo(TodoistColors.Yellow));
                Assert.That(TodoistColorsUtils.GetFromName("olive_green"), Is.EqualTo(TodoistColors.OliveGreen));
                Assert.That(TodoistColorsUtils.GetFromName("lime_green"), Is.EqualTo(TodoistColors.LimeGreen));
                Assert.That(TodoistColorsUtils.GetFromName("green"), Is.EqualTo(TodoistColors.Green));
                Assert.That(TodoistColorsUtils.GetFromName("mint_green"), Is.EqualTo(TodoistColors.MintGreen));
                Assert.That(TodoistColorsUtils.GetFromName("teal"), Is.EqualTo(TodoistColors.Teal));
                Assert.That(TodoistColorsUtils.GetFromName("sky_blue"), Is.EqualTo(TodoistColors.SkyBlue));
                Assert.That(TodoistColorsUtils.GetFromName("light_blue"), Is.EqualTo(TodoistColors.LightBlue));
                Assert.That(TodoistColorsUtils.GetFromName("blue"), Is.EqualTo(TodoistColors.Blue));
                Assert.That(TodoistColorsUtils.GetFromName("grape"), Is.EqualTo(TodoistColors.Grape));
                Assert.That(TodoistColorsUtils.GetFromName("violet"), Is.EqualTo(TodoistColors.Violet));
                Assert.That(TodoistColorsUtils.GetFromName("lavender"), Is.EqualTo(TodoistColors.Lavender));
                Assert.That(TodoistColorsUtils.GetFromName("magenta"), Is.EqualTo(TodoistColors.Magenta));
                Assert.That(TodoistColorsUtils.GetFromName("salmon"), Is.EqualTo(TodoistColors.Salmon));
                Assert.That(TodoistColorsUtils.GetFromName("charcoal"), Is.EqualTo(TodoistColors.Charcoal));
                Assert.That(TodoistColorsUtils.GetFromName("grey"), Is.EqualTo(TodoistColors.Grey));
                Assert.That(TodoistColorsUtils.GetFromName("taupe"), Is.EqualTo(TodoistColors.Taupe));
            });
        }

        [Test(
            Author = "Demarbit BV",
            Description = "Test Get Invalid Todoist Color from name")]
        public void Test_Common_TodoistColors_GetInvalidColorFromName()
        {
            Assert.Throws<InvalidKeyException>(() =>
            {
                TodoistColorsUtils.GetFromName("invalidcolor");
            });
        }
	}
}

