using System;

namespace App2
{
    public interface IReminderService
    {
        void Remind(string title, string message, int intervalInMinutes, string audioFileName);

        void ShowAlert(string message);
    }
}
