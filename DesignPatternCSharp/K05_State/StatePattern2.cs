using System;
using System.Collections.Generic;
using System.Text;

namespace K05_State.StatePattern2
{
    //查表法

    public enum State
    {
        SMALL = 0,
        SUPER = 1,
        FIRE = 2,
        CAPE = 3
    }

    public enum Event
    {
        GOT_MUSHROOM,
        GOT_CAPE,
        GOT_FIRE,
        MET_MONSTER
    }

    public class MarioStateMachine
    {
        private int score;
        private State currentState;

        private static State[,] transitionTable = {
          {State.SUPER,State. CAPE,State. FIRE,State. SMALL},
          { State.SUPER, State.CAPE, State.FIRE, State.SMALL},
          { State.CAPE, State.CAPE, State.CAPE,State. SMALL},
          { State.FIRE, State.FIRE, State.FIRE, State.SMALL}
        };

        private static int[,] actionTable = {
          {+100, +200, +300, +0},
          {+0, +200, +300, -100},
          {+0, +0, +0, -200},
          {+0, +0, +0, -300}
        };

        public MarioStateMachine()
        {
            this.score = 0;
            this.currentState = State.SMALL;
        }

        public void obtainMushRoom()
        {
            executeEvent(Event.GOT_MUSHROOM);
        }

        public void obtainCape()
        {
            executeEvent(Event.GOT_CAPE);
        }

        public void obtainFireFlower()
        {
            executeEvent(Event.GOT_FIRE);
        }

        public void meetMonster()
        {
            executeEvent(Event.MET_MONSTER);
        }

        private void executeEvent(Event evn)
        {
            int stateValue = (int)currentState;
            int eventValue = (int)evn;
            this.currentState = transitionTable[stateValue, eventValue];
            this.score += actionTable[stateValue, eventValue];
        }

        public int getScore()
        {
            return this.score;
        }

        public State getCurrentState()
        {
            return this.currentState;
        }

    }

}
