using System;
using Android.Content;
using Android.App;
using Android.Support.V4.App;
using Android.Graphics;
using Android;
using Xamarin.Forms;
using Android.Media;
using Android.Preferences;
using Android.OS;
using Android.Widget;
//using System.IO;

namespace App2.Droid
{
    [BroadcastReceiver]
    public class AlarmReceiver : BroadcastReceiver
    {
        Context _context;
        Intent _intent;
        public override void OnReceive(Context context, Intent intent)
        {
            _context = context;
            _intent = intent;
            var message = intent.GetStringExtra("message");
            //   ShowAlert(message, context);
            var title = intent.GetStringExtra("title");
            var interval = intent.GetIntExtra("interval", 10);

            var notIntent = new Intent(context, typeof(MainActivity));
            var contentIntent = PendingIntent.GetActivity(context, 0, notIntent, PendingIntentFlags.CancelCurrent);
            var manager = NotificationManagerCompat.From(context);

            var style = new NotificationCompat.BigTextStyle();
            style.BigText(message);

            //  Generate a notification with just short text and small icon
            var builder = new NotificationCompat.Builder(context)
                                  .SetContentIntent(contentIntent)
                                  .SetSmallIcon(Resource.Drawable.ic_mr_button_connected_07_dark)
                                  .SetContentTitle(title)
                                  .SetContentText(message)
                                  .SetStyle(style)
                                  .SetWhen(Java.Lang.JavaSystem.CurrentTimeMillis())
                                  .SetAutoCancel(true)
            .Extend(new NotificationCompat.WearableExtender());

            var notification = builder.Build();
            manager.Notify(0, notification);

            Vibrator vibrator = (Vibrator)context.GetSystemService(Context.VibratorService);
            vibrator.Vibrate(5 * 1000);

            PlayMusic();
            //PlayRingtone(context);
            Toast.MakeText(context, message, ToastLength.Long).Show();

        }

        private void PlayRingtone()
        {
            Android.Net.Uri notification = RingtoneManager.GetDefaultUri(RingtoneType.Alarm);
            Ringtone r = RingtoneManager.GetRingtone(_context, notification);
            r.Play();
        }
        private void PlayMusic()
        {

          
            MediaPlayer mediaPlayer = new MediaPlayer();

            var audioFile = GetAudioFile();

            if(string.IsNullOrEmpty( audioFile))
            {
                var resourceFile = _context.Assets.OpenFd("awater_on_lake_loop.mp3");
                mediaPlayer.SetDataSource(resourceFile.FileDescriptor, resourceFile.StartOffset, resourceFile.Length);
            }
            else
            {
                mediaPlayer.SetDataSource(audioFile);
            }

            mediaPlayer.Prepare();
            mediaPlayer.SetAudioStreamType(Stream.Music);
            mediaPlayer.Start();
        }


        private string GetAudioFile()
        {
            var directory = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDownloads);

            var audioFileName = _intent.GetStringExtra("audioFileName");

            if (!string.IsNullOrEmpty(audioFileName))
            {
                var file = System.IO.Path.Combine(directory.AbsolutePath, audioFileName);

                if (System.IO.File.Exists(file))
                {
                    return file;
                }

                return string.Empty;
            }

            return string.Empty;
        }


        public void ShowAlert(string msg)
        {
            Android.App.AlertDialog.Builder dialog = new AlertDialog.Builder(Forms.Context);
            AlertDialog alert = dialog.Create();
            alert.SetTitle("Title");
            alert.SetMessage(msg);
            alert.SetButton("OK", (c, ev) =>
            {
                // Ok button click task  
            });
            alert.Show();

        }

    }

}
