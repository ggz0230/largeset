using System;
using System.Collections.Generic;
using System.Text;

namespace K05_State.StatePattern1
{
    //分支逻辑法

    public enum State
    {
        SMALL = 0,
        SUPER = 1,
        FIRE = 2,
        CAPE = 3
    }

    public class MarioStateMachine
    {
        private int score;
        private State currentState;

        public MarioStateMachine()
        {
            this.score = 0;
            this.currentState = State.SMALL;
        }

        public void obtainMushRoom()
        {
            if (currentState.Equals(State.SMALL))
            {
                this.currentState = State.SUPER; this.score += 100;
            }
        }
        public void obtainCape()
        {
            if (currentState.Equals(State.SMALL) || currentState.Equals(State.SUPER))
            { this.currentState = State.CAPE; this.score += 200; }
        }

        public void obtainFireFlower()
        {
            if (currentState.Equals(State.SMALL) || currentState.Equals(State.SUPER))
            { this.currentState = State.FIRE; this.score += 300; }
        }

        public void meetMonster()
        {
            if (currentState.Equals(State.SUPER)) { this.currentState = State.SMALL; this.score -= 100; return; }
            if (currentState.Equals(State.CAPE)) { this.currentState = State.SMALL; this.score -= 200; return; }
            if (currentState.Equals(State.FIRE)) { this.currentState = State.SMALL; this.score -= 300; return; }
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

    public class ApplicationDemo
    {
        public static void main(String[] args)
        {
            MarioStateMachine mario = new MarioStateMachine();
            mario.obtainMushRoom();
            int score = mario.getScore();
            State state = mario.getCurrentState();
            Console.WriteLine("mario score: " + score + "; state: " + state);
        }
    }

}
