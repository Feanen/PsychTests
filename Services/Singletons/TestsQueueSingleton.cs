using PsychTestsMilitary.Models;
using System.Collections.Generic;

namespace PsychTestsMilitary.Services
{
    public class TestsQueueSingleton
    {
        private static TestsQueueSingleton instance;

        public static TestsQueueSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TestsQueueSingleton();
                }

                return instance;
            }
        }
        public Queue<Technique> Techniques { get; set; }
    }
}
