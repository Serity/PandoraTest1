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
            StateList.Add(StateID.EscMenuScreen, new States.EscMenuScreen());
            StateList.Add(StateID.DebugSpritesheetScreen, new States.DebugSpritesheetScreen());
        }
        public static GameState GetState(StateID s) {
            GameState val;
            StateList.TryGetValue(s, out val);
            return val;
        }
        public static GameState currentState
        {
            get { if (stateStack.Count > 0) { return stateStack.Peek(); } else { return null; } }
            set
            {
                InputManager.Reset(); // clear mouse + keyboard states to prevent input carryover between gamestates

                // move this into a SwitchState() func
                if (!stateStack.Contains(value)) {
                    currentState?.ExitState();
                    stateStack.Push(value);
                    currentState.EnterState();
                }
                else
                {
                    while (stateStack.Peek() != value) {
                        currentState?.ExitState();
                        stateStack.Pop();
                        currentState.EnterState();
                    }
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
