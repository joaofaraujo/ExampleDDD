using System;

namespace Inception.CrossCutting.EventsDomain.Entities
{
    public class Event : EventDomain
    {
        public DateTime DateOccurred { get; protected set; }

        protected Event()
        {
            DateOccurred = DateTime.Now;
        }
    }
}
