using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PandoraTest1.States;

namespace PandoraTest1.Managers
{

    public class StateManager
    {

        public static Dictionary<StateID, GameState> StateList = new Dictionary<StateID, GameState>();
        public static Stack<GameState> stateStack = new Stack<GameState>();
        static StateManager()
        {
            StateList.Add(StateID.MainMenu, new States.MainMenu());
            StateList.Add(StateID.BattleScreen, new States.BattleScreen());
        }
        public static GameState GetState(StateID s) {
            GameState val;
            StateList.TryGetValue(s, out val);
            return val;
        }
        public static GameState currentState
        {
            get { return stateStack.Peek(); }
            set
            {
                if (!stateStack.Contains(value)) { stateStack.Push(value); }
                else
                {
                    while (stateStack.Peek() != value) { stateStack.Pop(); }
                }
                
            }
        }
        public static GameState PreviousState(GameState st)
        {
            int stIndex = stateStack.ToArray().ToList().IndexOf(st);
            if (stIndex != stateStack.Count - 1) { stIndex++; }
            return stateStack.ElementAt(stIndex);
        }
        public static void GoToState(GameState st)
        {

        }
    }
}
