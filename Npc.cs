using System.Collections.Generic;
namespace DialogueSystem
{
    public class Npc
    {
        private  Dictionary<int,DialogueNode> _dialoguestages = new Dictionary<int, DialogueNode>();
        private int _id;
        public int _money = 200;
        public Npc(int id)
        {
            _id = id;
        }
        public int GetId()
        {
            return _id;
        }
        public DialogueNode GetDialogueStage(int stage)
        {
            return _dialoguestages[stage];
        }
        public void AddDialogueStage(DialogueNode node, int stage)
        {
            _dialoguestages.Add(stage, node);
        }
        public void ExecuteDialogueState(byte state)
        {
            switch (state)
            {             
                default:
                break;
                case 2://buy
                Program.Npcs[_id]._money += 20;
                break;
            }
        }
    
    }
}

