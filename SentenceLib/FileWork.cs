using System;
namespace SentenceLib
{
	/// <summary>
	/// Class to work with files in program.
	/// </summary>
	public class FileWork
	{
		/// <summary>
		/// Gets Array from file.
		/// </summary>
		/// <returns>Array of CharArr2D.</returns>
		public static CharArr2D[] GetArr()
		{
			CharArr2D[] A;
			string? path = "";
			do
			{
				Console.Write("Type name of file to read A array (without '.txt') :: ");
				path = Console.ReadLine();

			} while (!TryParse(path,out A));

			return A;
		}

		/// <summary>
		/// Make B array and save it.
		/// </summary>
		/// <param name="A"> Array to create B.</param>
        public static void SaveArr(CharArr2D[] A)
        {
            string? path;
            do
            {
                Console.Write("Type name of file to save B array (without '.txt') :: ");
                path = Console.ReadLine();
            } while (!IsCorrectPath(path));

			// Create B.
            CharArr2D[] B = GetB(A);
			 
			// String to save in file.
            string toSave = "";
            for (int i = 0; i < B.Length; i++)
                toSave += B[i].ToString();

			// Saving.
            char sep = Path.DirectorySeparatorChar;
            path = $"..{sep}..{sep}..{sep}..{sep}{path}.txt";

            File.WriteAllText(path, toSave);

        }

		/// <summary>
		/// Try's parse file to array of CharArr2D.
		/// </summary>
		/// <param name="path">Path to file.</param>
		/// <param name="A">Out array of CharArr2D.</param>
		/// <returns>Is operation good.</returns>
        static bool TryParse(string path, out CharArr2D[] A)
		{
			bool isCorrect = true;

            char sep = Path.DirectorySeparatorChar;
            path = $"..{sep}..{sep}..{sep}..{sep}{path}.txt";

            try
			{
				// Try parse file.
				string[] parsedFile = File.ReadAllText(path).Split(". ");
				A = new CharArr2D[parsedFile.Length];
				for(int i = 0; i < A.Length; i++)
					A[i] = new CharArr2D(parsedFile[i] + '.');
            }
			catch
			{
				A = new CharArr2D[0];
				isCorrect = false;
			}

			return isCorrect;
		}

		/// <summary>
		/// Check path on correcting.
		/// </summary>
		/// <param name="path">Path to check.</param>
		/// <returns>Result of checking.</returns>
		static bool IsCorrectPath(string path)
		{
            char[] invalidChars = Path.GetInvalidFileNameChars();
			if (path is null) return false;
            foreach (char chr in path)
            {
                if (invalidChars.Contains(chr))
					return false;
            }
			return true;
        }

		/// <summary>
		/// Create B array from A.
		/// </summary>
		/// <param name="A">Array to create B array.</param>
		/// <returns>B array.</returns>
		static CharArr2D[] GetB(CharArr2D[] A)
		{
			// Count size of B array.
			int BSize = 0;
			for(int i = 0; i < A.Length; i++)
			{
				if (A[i].NotConsonants().Length == A[i].Lenght())
					BSize++;
			}

			// Create B array.
			CharArr2D[] B = new CharArr2D[BSize];
			int curIndex = 0;
            for (int i = 0; i < A.Length; i++)
			{
                if (A[i].NotConsonants().Length == A[i].Lenght())
				{
					B[curIndex] = A[i];
					curIndex++;
				}     
            }

			return B;
		}
	}
}

