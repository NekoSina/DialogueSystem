using System;

namespace DialogueSystem
{
    //--------------------------------------------------------------------------------
    public class Player
    {
        private int _id;
        public int _money = 200;
        private int _npc_id;
        public byte state;
     
        public Player(int id)
        {
            _id = id;
        }
        public void AddQuest(string questname)
        {
            //add quest
        }
        public void ExecuteDialogueState()
        {
            switch (state)
            {
                case 0:                
                break;
                case 30://buy
                _money -= 20;
                break;
                case 17:
                AddQuest("robbery");
                break;           
            }
        }
    }
}

