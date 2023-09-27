﻿using System.Reflection;
using Quartz;

namespace MementoMori.Jobs;

public class TimeZoneAwareJobRegister
{
    private readonly ISchedulerFactory _schedulerFactory;
    private readonly TimeManager _timeManager;

    public TimeZoneAwareJobRegister(ISchedulerFactory schedulerFactory, TimeManager timeManager)
    {
        _schedulerFactory = schedulerFactory;
        _timeManager = timeManager;
    }

    public async Task RegisterJobs()
    {
        var scheduler = await _schedulerFactory.GetScheduler();
        AddJob<DailyJob>(scheduler);
        AddJob<HourlyJob>(scheduler);
        AddJob<PvpJob>(scheduler);
    }

    private void AddJob<T>(IScheduler scheduler) where T : IJob
    {
        var type = typeof(T);
        var cronAttribute = type.GetCustomAttribute(typeof(CronAttribute)) as CronAttribute;
        if (cronAttribute == null) return;
        var jobKey = new JobKey(type.FullName!);
        var jobDetail = JobBuilder.Create<T>().WithIdentity(jobKey).Build();

        var customTimeZone = TimeZoneInfo.CreateCustomTimeZone(_timeManager.DiffFromUtc.ToString(), _timeManager.DiffFromUtc, null, null);
        var trigger = TriggerBuilder.Create()
            .ForJob(jobKey)
            .WithIdentity($"{type.FullName}-trigger")
            .WithCronSchedule(cronAttribute.Cron, builer => builer.InTimeZone(customTimeZone))
            .Build();
        scheduler.UnscheduleJob(trigger.Key);
        scheduler.AddJob(jobDetail, true);
        scheduler.ScheduleJob(jobDetail, trigger);
    }
}


[AttributeUsage(AttributeTargets.Class)]
public class CronAttribute : Attribute
{
    public CronAttribute(string cron)
    {
        Cron = cron;
    }

    public string Cron { get; set; }
}
