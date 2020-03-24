using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Spaceport
{
    class VisualProgress
    {
        private Timer t; 

        public void Show(Task[] task)
        {
            t = new Timer(DataGetWorkVisual, null, 0, 200);
            Task.WaitAll(task);
            t.Dispose();
        }
        
        internal void DataGetWorkVisual(object state)
        {
            Console.Write(".");
        }
    }
}
