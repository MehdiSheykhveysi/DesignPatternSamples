using System;

namespace WebFactoryPattern.Infrastructure.Utilities
{

    //I'm only showing a single IJob implementation here, but we want the Quartz hosted service to be a generic implementation that
    //works for any number of jobs. To help with that, we create a simple DTO called JobSchedule that we'll use to define the timer
    //schedule for a given job type:

    public class JobSchedule
    {
        public JobSchedule(Type jobType, string cronExpression)
        {
            JobType = jobType;
            CronExpression = cronExpression;
        }

        public Type JobType { get; }
        public string CronExpression { get; }
    }
}
