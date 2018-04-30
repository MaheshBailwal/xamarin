using System;
using Android.Content;
using Android.App;
using Xamarin.Forms;
using Android.OS;
using App2;
using Android.Media;
using Android.Content.Res;
using App2.Models;

[assembly: Xamarin.Forms.Dependency(typeof(App2.Droid.AndroidReminderService))]

namespace App2.Droid
{
    public class AndroidReminderService : IReminderService
    {
        #region IReminderService implementation

        public void Remind(Item item)
        {
            var context = Forms.Context;

            Intent alarmIntent = new Intent(context, typeof(AlarmReceiver));
            alarmIntent.PutExtra("message", item.Notes);
            alarmIntent.PutExtra("title", item.Name);
            alarmIntent.PutExtra("interval", item.IntervalInMinutes);
            alarmIntent.PutExtra("audioFileName", item.AudioFileName);

            alarmIntent.PutExtra("CanPlayAudio", item.CanPlayAudio);
            alarmIntent.PutExtra("CanShowMessage", item.CanShowMessage);
            alarmIntent.PutExtra("CanViberation", item.CanViberation);


            PendingIntent pendingIntent = PendingIntent.GetBroadcast(context, 0, alarmIntent, PendingIntentFlags.UpdateCurrent);
            AlarmManager alarmManager = (AlarmManager)context.GetSystemService(Context.AlarmService);
            alarmManager.Cancel(pendingIntent);

          var intervalInMinutes = item.IntervalInMinutes * 1000 * 60;

            alarmManager.SetRepeating(AlarmType.ElapsedRealtimeWakeup, SystemClock.ElapsedRealtime() + 2 * 1000, intervalInMinutes,  pendingIntent);
        }

        #endregion

        public void ShowAlert(string msg)
        {
            PlayMusic();

            Android.App.AlertDialog.Builder dialog = new AlertDialog.Builder(Forms.Context);
            AlertDialog alert = dialog.Create();
            alert.SetTitle("Reminder");
            alert.SetMessage(msg);
            alert.SetButton("OK", (c, ev) =>
            {
                // Ok button click task  
            });
            alert.Show();

            var remiderService = DependencyService.Get<IReminderService>();
        }

        private void PlayMusic()
        {
            MediaPlayer mediaPlayer = new MediaPlayer();
            mediaPlayer.SetDataSource("http://www.kozco.com/tech/32.mp3");
            mediaPlayer.Prepare();
            mediaPlayer.SetAudioStreamType(Stream.Music);
            mediaPlayer.Completion += delegate
            {
                mediaPlayer.Release();
                mediaPlayer.Dispose();
            };

            mediaPlayer.Start();

        }

    }
}

