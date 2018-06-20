using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace bgSync
{
    public class DoSyncJob
    {
        public async void Start()
        {
            await Task.Run(() =>
            {
                // do work
            });
        }
    }
}
