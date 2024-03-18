using Codecool.Quest.Models.Actors;
using quizGame;
using System;
using System.Windows.Forms;

namespace Codecool.Quest {
    public static class QuestGame
    {
        public static nguoichoi x { get; set; }
    }
    static class Program {
        /// <summary>
        /// Główny punkt wejścia dla aplikacji.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new MainForm());
        }
    }
}
