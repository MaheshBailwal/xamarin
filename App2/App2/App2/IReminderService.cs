using App2.Models;
using System;

namespace App2
{
    public interface IReminderService
    {
        void Remind(Item item);
    }
}
