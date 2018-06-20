using Android.App;
using Android.App.Job;
using Android.Content.PM;
using Android.OS;
using bgSync.Droid.Helpers;
using Xamarin.Forms.Platform.Android;

namespace bgSync.Droid
{
    [Activity(Label = "bgSync", Icon = "@mipmap/icon", Theme = "@style/MainTheme",
        MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsAppCompatActivity
    {

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            Xamarin.Forms.Forms.Init(this, bundle);

            LoadApplication(new App());

            var jobBuilder = this.CreateJobBuilderUsingJobId<Services.ScheduledService>(1);
            var jobInfo = jobBuilder
                .SetMinimumLatency(1000)   // Wait at least 1 second
                .SetOverrideDeadline(5000) // But no longer than 5 seconds
                .SetPersisted(true) // Allow it to keep running after a device restart
                .SetRequiredNetworkType(NetworkType.NotRoaming) //basic necessary network connection to run the job
                .Build();

            var jobScheduler = (JobScheduler)GetSystemService(JobSchedulerService);
            jobScheduler.Schedule(jobInfo);
        }

        protected override void OnPause()
        {
            base.OnPause();
        }

        protected override void OnResume()
        {
            base.OnResume();
        }

        protected override void OnStart()
        {
            base.OnStart();
        }

        protected override void OnStop()
        {
            base.OnStop();
        }
        
    }
}

