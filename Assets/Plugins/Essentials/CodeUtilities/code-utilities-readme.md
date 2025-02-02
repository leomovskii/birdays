# IntFlagUtility
This is a utility for packing and unpacking boolean flags into a single int value. The class allows you to compactly store up to 32 boolean values ​​(flags) in a single number, which saves memory and simplifies working with multiple flags. In addition to packing and unpacking, the utility allows you to modify individual flags and check for other flags.

## Methods
* **Pack(bool[] flags)** — packs an array of boolean values ​​into a single integer (int).
* **Unpack(int packedFlags)** — unpacks flags from an integer back into an array of boolean values.
* **ModifyFlag(int packedFlags, int flagIndex, bool newFlagState)** — changes the state of a specific flag in a packed value.
* **HasAtLeastOtherFlag(int packedFlags, int excludeFlagIndex)** — checks if there are any enabled flags other than the specified one.

## Usage
``` csharp
public class FlagTest : MonoBehaviour {
    private void Start() {
        // Four flags, only 1st, 3rd, and 4th are true.
        bool[] flags = { true, false, true, true };
        int packedFlags = IntFlagUtility.Pack(flags);

        // Outputs the packed flag value.
        Debug.Log($"Packed flags: {packedFlags}");

        bool[] unpackedFlags = IntFlagUtility.Unpack(packedFlags);
        // Outputs the flag states after unpacking.
        Debug.Log($"Unpacked flags: {string.Join(", ", unpackedFlags)}");

        // Modify the 2nd flag to true.
        packedFlags = IntFlagUtility.ModifyFlag(packedFlags, 1, true);
        Debug.Log($"Modified packed flags: {packedFlags}");

        // Check if there are other flags except for the 2nd one.
        bool hasOtherFlags = IntFlagUtility.HasAtLeastOtherFlag(packedFlags, 1);
        Debug.Log($"Has at least other flags: {hasOtherFlags}");
    }
}
```

# NumberShortenerUtility
The NumberShortenerUtility class shortens large numbers by adding appropriate suffixes (e.g., "K", "M", "B", etc.) based on the magnitude of the number. It works for numbers in thousands, millions, billions, etc., and allows formatting of the shortened number using a specified format string. The suffix can also be set to uppercase or lowercase.

## Methods
* **Short(double number, string format = "0", bool uppercase = true)** - takes a number and returns it in a shortened form with an appropriate suffix.

You can provide a format for the number (e.g., "0.0" for one decimal place). The suffix can be uppercase or lowercase based on the uppercase flag.

## Usage
``` csharp
public class NumberShortenerTest : MonoBehaviour {
	private void Start() {
		double number1 = 1500;
		double number2 = 1530000;
		double number3 = 125000;

		// Basic shortening without custom formatting
		string result1 = NumberShortenerUtility.Short(number1); // "1K"
		Debug.Log($"Shortened number (1K): {result1}");

		// Shortening with custom decimal formatting
		string result2 = NumberShortenerUtility.Short(number2, "0.00"); // "1.53M"
		Debug.Log($"Shortened number with 2 decimals (1.53M): {result2}");

		// Shortening with lowercase suffix
		string result3 = NumberShortenerUtility.Short(number3, "0.0", false); // "125.0k"
		Debug.Log($"Shortened number with lowercase (125.0k): {result3}");
	}
}
```

# Prefs
This class is a wrapper around Unity's PlayerPrefs, providing convenient methods for saving and retrieving data types that are not directly supported by the standard PlayerPrefs methods (e.g., bool, long, double, uint). For numeric types, values are stored as strings using CultureInfo.InvariantCulture to ensure correct formatting and parsing regardless of the user's locale.

## Methods
* **GetBool(string key, bool defaultValue = false)** - retrieves a boolean value from PlayerPrefs. If the key doesn't exist, the provided defaultValue is returned. Internally, the boolean is stored as 1 for true and 0 for false.
* **SetBool(string key, bool value)** - saves a boolean value into PlayerPrefs, converting true to 1 and false to 0.
* **GetLong(string key, long defaultValue = 0L)** - retrieves a long value from PlayerPrefs, stored as a string. If the key doesn't exist or the value can't be parsed, it returns the provided defaultValue.
* **SetLong(string key, long value)** - saves a long value into PlayerPrefs, converting it to a string.
* **GetDouble(string key, double defaultValue = 0.0)** - retrieves a double value from PlayerPrefs, stored as a string. If parsing fails, it returns the provided defaultValue.
* **SetDouble(string key, double value)** - saves a double value into PlayerPrefs as a string.
* **GetUint(string key, uint defaultValue = 0u)** - retrieves an uint value from PlayerPrefs. Like the other numeric types, it's stored as a string and returned after parsing, or the defaultValue is returned on failure.
* **SetUint(string key, uint value)** - saves an uint value into PlayerPrefs as a string.

## Usage
``` csharp
public class PrefsExample : MonoBehaviour {

    private void Start() {
        // Set and get a bool value
        Prefs.SetBool("isMusicOn", true);
        bool isMusicOn = Prefs.GetBool("isMusicOn", false);
        Debug.Log($"Music is on: {isMusicOn}");

        // Set and get a long value
        Prefs.SetLong("highScore", 9999999999L);
        long highScore = Prefs.GetLong("highScore", 0L);
        Debug.Log($"High Score: {highScore}");

        // Set and get a double value
        Prefs.SetDouble("volumeLevel", 0.75);
        double volumeLevel = Prefs.GetDouble("volumeLevel", 1.0);
        Debug.Log($"Volume Level: {volumeLevel}");

        // Set and get a uint value
        Prefs.SetUint("coins", 500u);
        uint coins = Prefs.GetUint("coins", 0u);
        Debug.Log($"Coins: {coins}");
    }
}
```

# RomanNumeralConverter
Utility for converting between Roman numerals and Arabic numbers (uint). The conversion supports numbers from 1 to 3,999,999, where large numbers (over 1,000) are represented with parentheses around 'M'. For example, 1,000,000 is represented as "(M)".

## Methods
* **ToRoman(uint number)** - converts an Arabic number (uint) to its Roman numeral string equivalent.
* **FromRoman(string roman)** - converts a Roman numeral string back into its Arabic number (uint) equivalent.

## Usage
``` csharp
public class RomanNumeralSample : MonoBehaviour {
    void Start() {
        // Example Arabic number to convert
        uint arabicNumber = 1987;

        // Convert the Arabic number to Roman numeral string
        string romanNumeral = RomanNumeralConverter.ToRoman(arabicNumber);
        Debug.Log($"Arabic {arabicNumber} -> Roman {romanNumeral}");

        // Convert the Roman numeral string back to Arabic number
        uint convertedBack = RomanNumeralConverter.FromRoman(romanNumeral);
        Debug.Log($"Roman {romanNumeral} -> Arabic {convertedBack}");

        // Verify if the conversion back and forth is correct
        if (arabicNumber == convertedBack) {
            Debug.Log("Conversion back and forth is successful!");
        } else {
            Debug.LogError("Conversion mismatch!");
        }
    }
}
```
