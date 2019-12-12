using System;


namespace _EventArgs
{
    class Program
    {
        static void Main(string[] args)
        {
            Video video = new Video("Star Wars: A new Hope");
            VideoEncoder videoEncoder = new VideoEncoder();
            
            PrinterService printerService = new PrinterService();
            SMSService smsService = new SMSService();

            videoEncoder.VideoEncoded += MailService.OnVideoEncoded;
            videoEncoder.VideoEncoded += printerService.OnVideoEncoded;
            videoEncoder.VideoEncoded += smsService.OnVideoEncoded;

            videoEncoder.Encode(video);

            Console.ReadKey();

        }


    }

    public class Video
    {
        public string Name { get; set; }
        public Video(string name)
        {
            Name = name;
        }
    }

    public class VideoEventArgs : EventArgs
    {
        public Video Video { get; private set; }
        public DateTime Zeit { get; private set; }


        public VideoEventArgs(Video video)
        {
            Video = video;
            Zeit = DateTime.Now;

        }

        public override string ToString()
        {
            return Video.Name;
        }
    }

    public class VideoEncoder
    {
        //Das Event, das nach dem Encoden aufgerufen wird
        //In der spitzen Klammer können wir den Typen der EventArgs angeben
        public event EventHandler<VideoEventArgs> VideoEncoded;

        public void Encode(Video video)
        {
            Console.WriteLine("Starte Vorgang..." + video.Name);
            //....
            Console.WriteLine("Vorgang beendet...");
            //Prüfen, ob das Event Abonniert wurde und wenn Ja, wird das Event ausgelöst
            if (VideoEncoded != null)
                VideoEncoded(this, new VideoEventArgs(video));
        }

        public override string ToString()
        {
            return "Video Encoder";
        }
    }

    public class MailService
    {
        //Methoden, die auf das Event reagieren werden meistens mit
        //On + Name des Events benannt
        public static void OnVideoEncoded(object sender, VideoEventArgs eventArgs)
        {
            Console.WriteLine("Auslöser: " + sender.ToString());
            Console.WriteLine("Verschicke Mail...");
            Console.WriteLine(eventArgs.Video.Name + " " + eventArgs.Zeit.ToShortTimeString());
        }
    }

    public class PrinterService
    {
        public void OnVideoEncoded(object sender, VideoEventArgs eventArgs)
        {
            Console.WriteLine("Drucke Nachricht...");
            Console.WriteLine(eventArgs.Video.Name + " " + eventArgs.Zeit.ToShortTimeString());
        }
    }

    public class SMSService
    {
        public void OnVideoEncoded(object sender, VideoEventArgs eventArgs)
        {
            Console.WriteLine("Verschicke SMS...");
            Console.WriteLine(eventArgs.Video.Name);
        }
    }

}
