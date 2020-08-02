using System;
using System.IO;

namespace DialogueSystem
{
    public static class Program
    {
        public static void LoadNpc()
        {
            for (int i = 0; i < 10; i++)
            {
                Npcs[i] = new Npc(i);
            } 
        }
        //----------------------------------------------------------------------
       private static void LoadDialogs()
       {
           //dialogue stages
        //depth 1
        Npcs[0].AddDialogueStage(new DialogueNode("Hello there welcome to our shop! How are you?"), 0);
        Npcs[0].AddDialogueStage(new DialogueNode("thats great! glad to hear! so who are you anyway?"), 1);
        Npcs[0].AddDialogueStage(new DialogueNode("sorry to hear that. so who are you anyway?"), 2);
        Npcs[0].AddDialogueStage(new DialogueNode("ok chill. so who are you anyway?"), 3);
        //depth 2
        Npcs[0].AddDialogueStage(new DialogueNode("oh you are from the college? i have some weird staffs if you are intersted. anyway how can i help you?"), 4);
        Npcs[0].AddDialogueStage(new DialogueNode("its not wise to say that out loud in public now is it. anyway how can i help you?"), 5);
        Npcs[0].AddDialogueStage(new DialogueNode("how can i help you"), 6);
        //depth 3
        Npcs[0].AddDialogueStage(new DialogueNode("finest weapon and armor."), 30);
        Npcs[0].AddDialogueStage(new DialogueNode("yes go kill the bandit."), 20);
        Npcs[0].AddDialogueStage(new DialogueNode("bye! come back anytime if you need a weapon or armor"), 255);
        var stage0 = Npcs[0].GetDialogueStage(0);
        stage0.AddResponse(1, new DialogueNode("I'm well thank you"));
        stage0.AddResponse(2, new DialogueNode("Meh been better."));
        stage0.AddResponse(3, new DialogueNode("I'm grumpy."));
        for (int i = 1; i < 4 ; i++)
        {
            var stage = Npcs[0].GetDialogueStage(i);
            stage.AddResponse(4, new DialogueNode("I'm a wizard.."));
            stage.AddResponse(5, new DialogueNode("I'm a bandit."));                  
        }
        for (int i = 4; i < 7; i++)
        {
            var stage = Npcs[0].GetDialogueStage(i);
            stage.AddResponse(30, new DialogueNode("buy"));
            stage.AddResponse(20, new DialogueNode("quest"));
            stage.AddResponse(255, new DialogueNode("quit"));
        }
        var buystage = Npcs[0].GetDialogueStage(30);
        buystage.AddResponse(6, new DialogueNode("oh btw"));
        var queststage = Npcs[0].GetDialogueStage(20);
        queststage.AddResponse(6, new DialogueNode("i have another favor"));
       }
       //----------------------------------------------------------------------
       private static void DisplayDialogue(DialogueNode dialogue)
       {   
           Console.WriteLine($"Npc[{dialogue.npc_id}]: {dialogue.text}");
           int counter = 0;
           foreach (var kvp in dialogue.Responses)
           {
               Console.WriteLine($"{counter}: {kvp.Value.text}");
               counter++;
           }
       }
       //----------------------------------------------------------------------
       private static DialogueNode StartConversation(Npc npc, byte stage)
       {
           return npc.GetDialogueStage(stage);
       }

       //----------------------------------------------------------------------
       private static byte FindResponse(DialogueNode dialogue, byte input)
       {
           byte response = 0;
           int counter = 0;
            foreach (var kvp in dialogue.Responses)
            {

                if(input == counter)
                {
                    response = kvp.Key;
                }
                counter++;
            }
           return response;
       }
        //----------------------------------------------------------------------
       public static Npc []Npcs = new Npc[10];
       public static Player Player1 = new Player(0);
       private static DialogueNode _currentNode;
       //----------------------------------------------------------------------
        public static void Main(string[] args)
        {

            //---------------
            LoadNpc();
            LoadDialogs();
            var npcid = 0;
            _currentNode = Npcs[npcid].GetDialogueStage(0);
            //_currentNode = StartConversation(Npcs[npcid], 0);//useless

            while (Player1.state != 255)
            {
                Player1.ExecuteDialogueState();
                Npcs[npcid].ExecuteDialogueState(Player1.state);
                DisplayDialogue(_currentNode);
                
                var stringinput = Console.ReadLine();
                byte input = byte.Parse(stringinput);
                input = FindResponse(_currentNode, input);
                var responsenode = _currentNode.Responses[input];
                var nextstage = input;
                Player1.state = nextstage;
                if (Player1.state == 255)
                {
                    Console.WriteLine("i got to go");
                    var quitdial = Npcs[npcid].GetDialogueStage(255);
                    Console.WriteLine(quitdial.text);
                }
                _currentNode = Npcs[npcid].GetDialogueStage(Player1.state);        
            }
            Console.ReadLine();
 
        }
    }
}

