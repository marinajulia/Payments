using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublisherJob.Job
{
    public class Job : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine("Tarefa sendo executada em: " + DateTime.Now);
            return Task.CompletedTask;
        }
    }
}
