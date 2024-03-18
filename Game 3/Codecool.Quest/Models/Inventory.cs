using quizGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codecool.Quest.Models
{

    public class Inventory
    {
        public Dictionary<string, int> playerInventory;

        public Inventory()
        {
            playerInventory = new Dictionary<string, int>();
        }
        public void addToInventory(string itemName)
        {
            Question ques = new Question();
            ques.Show();
        
            if (!playerInventory.ContainsKey(itemName))
            {
                playerInventory.Add(itemName, 1);
            }
            else
            {
                playerInventory[itemName]++;
            }
        }
    }
}
