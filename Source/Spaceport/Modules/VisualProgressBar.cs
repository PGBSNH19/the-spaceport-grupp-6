using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Spaceport
{
    class VisualProgressBar
    {
        private Timer t;

        public async Task AwaitAndShow(Task[] task)
        {
            t = new Timer(DataWorkVisual, null, 0, 200);
            await Task.WhenAll(task);
            t.Dispose();
        }
        
        internal void DataWorkVisual(object state)
        {
            Console.Write(".");
        }
    }
}
