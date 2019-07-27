using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Quartz.Spi;
using System;

//Next, we need to tell Quartz how it should create instances of IJob.
//By default, Quartz will try and "new-up" instances of the job using Activator.CreateInstance,
///effectively calling new HelloWorldJob(). Unfortunately, as we're using constructor injection,
//that won't work.Instead, we can provide a custom IJobFactory that hooks into the ASP.NET Core dependency injection container (IServiceProvider):
//This factory takes an IServiceProvider in the constructor, and implements the IJobFactory interface. 
//The important method is the NewJob() method, in which the factory has to return the IJob requested by the Quartz scheduler.
//In this implementation we delegate directly to the IServiceProvider,
//and let the DI container find the required instance.The cast to IJob at the end is required because the non-generic version of GetRequiredService returns an object.
//The ReturnJob method is where the scheduler tries to return (i.e.destroy) a job that was created by the factory.Unfortunately, 
//there's no mechanism for doing so with the built-in IServiceProvider. 
//We can't create a new IScopeService that fits into the required Quartz API, 
//so we're stuck only being able to create singleton jobs

public class SingletonJobFactory : IJobFactory
{
    private readonly IServiceProvider _serviceProvider;
    public SingletonJobFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
    {
        return _serviceProvider.GetRequiredService(bundle.JobDetail.JobType) as IJob;
    }

    public void ReturnJob(IJob job) { }
}
