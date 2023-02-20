using System;
using CoderBash.Net.Todoist.Common.Exceptions;

namespace CoderBash.Net.Todoist.Common.Enums
{
    /// <summary>
    /// Todoist Colors. See <see href="https://developer.todoist.com/guides/#colors">Todoist Color Guide</see> for more information.
    /// </summary>
    public enum TodoistColors
    {
        BerryRed = 30,
        Red = 31,
        Orange = 32,
        Yellow = 33,
        OliveGreen = 34,
        LimeGreen = 35,
        Green = 36,
        MintGreen = 37,
        Teal = 38,
        SkyBlue = 39,
        LightBlue = 40,
        Blue = 41,
        Grape = 42,
        Violet = 43,
        Lavender = 44,
        Magenta = 45,
        Salmon = 46,
        Charcoal = 47,
        Grey = 48,
        Taupe = 49
    }

    /// <summary>
    /// Helper class for managing <see href="https://developer.todoist.com/guides/#colors">Todoist Colors</see>.
    /// </summary>
    public static class TodoistColorsUtils
    {
        /// <summary>
        /// Get the unique name of the <see cref="TodoistColors"/> value. To be used when talking to the API.
        /// </summary>
        /// <param name="color"><see cref="TodoistColors"/> enum value.</param>
        /// <returns>Unique color name as specified on the <see href="https://developer.todoist.com/guides/#colors">Todoist Colors</see> documentation page</returns>
        /// <exception cref="InvalidKeyException"></exception>
        public static string? GetColorKey(TodoistColors? color)
        {
            if (color == null)
            {
                return null;
            }

            return color switch
            {
                TodoistColors.BerryRed => "berry_red",
                TodoistColors.Red => "red",
                TodoistColors.Orange => "orange",
                TodoistColors.Yellow => "yellow",
                TodoistColors.OliveGreen => "olive_green",
                TodoistColors.LimeGreen => "lime_green",
                TodoistColors.Green => "green",
                TodoistColors.MintGreen => "mint_green",
                TodoistColors.Teal => "teal",
                TodoistColors.SkyBlue => "sky_blue",
                TodoistColors.LightBlue => "light_blue",
                TodoistColors.Blue => "blue",
                TodoistColors.Grape => "grape",
                TodoistColors.Violet => "violet",
                TodoistColors.Lavender => "lavender",
                TodoistColors.Magenta => "magenta",
                TodoistColors.Salmon => "salmon",
                TodoistColors.Charcoal => "charcoal",
                TodoistColors.Grey => "grey",
                TodoistColors.Taupe => "taupe",
                _ => throw new InvalidKeyException("Unsupported color element provided.")
            };
        }

        /// <summary>
        /// Get the HEX value of the color corresponding to the <see cref="TodoistColors"/> value. 
        /// </summary>
        /// <param name="color"><see cref="TodoistColors"/> enum value.</param>
        /// <returns>HEX value of the specified color.</returns>
        /// <exception cref="InvalidKeyException"></exception>
        public static string GetColorHex(TodoistColors color)
        {
            return color switch
            {
                TodoistColors.BerryRed => "#b8256f",
                TodoistColors.Red => "#db4035",
                TodoistColors.Orange => "#ff9933",
                TodoistColors.Yellow => "#fad000",
                TodoistColors.OliveGreen => "#afb83b",
                TodoistColors.LimeGreen => "#7ecc49",
                TodoistColors.Green => "#299438",
                TodoistColors.MintGreen => "#6accbc",
                TodoistColors.Teal => "#158fad",
                TodoistColors.SkyBlue => "#14aaf5",
                TodoistColors.LightBlue => "#96c3eb",
                TodoistColors.Blue => "#4073ff",
                TodoistColors.Grape => "#884dff",
                TodoistColors.Violet => "#af38eb",
                TodoistColors.Lavender => "#eb96eb",
                TodoistColors.Magenta => "#e05194",
                TodoistColors.Salmon => "#ff8d85",
                TodoistColors.Charcoal => "#808080",
                TodoistColors.Grey => "#b8b8b8",
                TodoistColors.Taupe => "#ccac93",
                _ => throw new InvalidKeyException("Unsupported color element provided.")
            };
        }

        /// <summary>
        /// Get a <see cref="TodoistColors"/> enum value for the specified color name.
        /// </summary>
        /// <param name="colorName">The name of the color as returned by the Todoist API</param>
        /// <returns><see cref="TodoistColors"/> enum value.</returns>
        /// <exception cref="InvalidKeyException"></exception>
        public static TodoistColors GetFromName(string colorName)
        {
            return colorName.ToLower() switch
            {
                "berry_red" => TodoistColors.BerryRed,
                "red" => TodoistColors.Red,
                "orange" => TodoistColors.Orange,
                "yellow" => TodoistColors.Yellow,
                "olive_green" => TodoistColors.OliveGreen,
                "lime_green" => TodoistColors.LimeGreen,
                "green" => TodoistColors.Green,
                "mint_green" => TodoistColors.MintGreen,
                "teal" => TodoistColors.Teal,
                "sky_blue" => TodoistColors.SkyBlue,
                "light_blue" => TodoistColors.LightBlue,
                "blue" => TodoistColors.Blue,
                "grape" => TodoistColors.Grape,
                "violet" => TodoistColors.Violet,
                "lavender" => TodoistColors.Lavender,
                "magenta" => TodoistColors.Magenta,
                "salmon" => TodoistColors.Salmon,
                "charcoal" => TodoistColors.Charcoal,
                "grey" => TodoistColors.Grey,
                "taupe" => TodoistColors.Taupe,
                _ => throw new InvalidKeyException($"Unknown color key '{colorName}' provided.")
            };
        }
    }
}

