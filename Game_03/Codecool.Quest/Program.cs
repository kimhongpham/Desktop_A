using Codecool.Quest.Models.Actors;
using quizGame;
using System;
using System.Windows.Forms;

namespace Codecool.Quest
{
    public static class QuestGame
    {
        public static nguoichoi x { get; set; }
    }
    static class Program
    {
        // Add this line to declare the variable
        private static string _username;

        /// <summary>
        /// Główny punkt wejścia dla aplikacji.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Use this line to get the user input
            _username = GetUsernameFromUser();

            Application.Run(new MainForm(_username));
        }

        // Add this method to get the user input
        private static string GetUsernameFromUser()
        {
            Console.Write("Please enter your username: ");
            return Console.ReadLine();
        }
    }
}