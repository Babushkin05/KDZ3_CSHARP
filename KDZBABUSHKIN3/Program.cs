using SentenceLib;
namespace KDZBABUSHKIN3
{
    class Program
    {
        public static void Main(string[] args)
        {
            do
            {
                // Clear console in begining of working.
                Console.Clear();

                // Read A array from file.
                CharArr2D[] A = FileWork.GetArr();

                // Create B array and save it to file.
                FileWork.SaveArr(A);

                // Repeating of program.
                Console.Write("type 'y' to repeat program or some another key to quit :: ");
            } while (Console.ReadKey().KeyChar == 'y');

        }
    }
}