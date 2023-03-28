using System;

namespace EnglishCentreManagement.Model
{
    public class Notice
    {
        private Person sender;
        private Person receiver;
        private string content;

        public Notice(Person Sender, Person Receiver, string Content)
        {
            this.Sender = Sender;
            this.Receiver = Receiver;
            this.Content = Content;
        }

        public Person Sender
        {
            get => sender; 
            set
            {
                if (value == null)
                    throw new ArgumentOutOfRangeException($"{nameof(value)} must be not null");
                this.Sender = value;
            }
        }

        public Person Receiver
        {
            get => receiver;   
            set
            {
                if (value == null)
                    throw new ArgumentOutOfRangeException($"{nameof(value)} must be not null");
                this.receiver = value;
            }
        }

        public string Content { get => content; set => content = value; }
        
    }
}
