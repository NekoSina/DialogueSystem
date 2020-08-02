using System.Collections.Generic;
namespace DialogueSystem
{
    public class DialogueNode
    {
        public string text;
        public int npc_id;
        //public byte control;
        public Dictionary<byte, DialogueNode> Responses = new Dictionary<byte, DialogueNode>(); 
     

        public DialogueNode(string dialogue_text)
        {
            text = dialogue_text;
            //_isAvailable = available;
        }
        public void AddResponse(byte nextstage, DialogueNode Response)
        {
            Responses.Add(nextstage, Response); 
        }   
    }
}

