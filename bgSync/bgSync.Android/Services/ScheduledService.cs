using Android.App;
using Android.App.Job;
using System;
using System.Threading.Tasks;

namespace bgSync.Droid.Services
{
    [Service(Name = "com.biosev.autoatendimento.controleAcesso.ControleAcessoSyncScheduledJob",
         Permission = "android.permission.BIND_JOB_SERVICE")]
    public class ScheduledService : JobService
    {

        public override bool OnStartJob(JobParameters jobParams)
        {
            Task.Run(() =>
            {
                Xamarin.Forms.Device.StartTimer(
                    new TimeSpan(0, 0, 5), //post a message every 5 secs
                    () =>
                    {
                        Xamarin.Forms.MessagingCenter.Send<MainPage>((MainPage)App.Current.MainPage, "Hi");
                        return true;
                    });

                //Uncomment the following line if you want to terminate the job
                //JobFinished(jobParams, false);
            });

            // Return true because of the asynchronous work
            return true;
        }


        public override bool OnStopJob(JobParameters jobParams)
        {
            return false;
        }
    }
}