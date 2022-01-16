using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;
using System.Globalization;
namespace SMTPService
{
    class Program
    {
        static void Main(string[] args)
        {
            TimeZone localZone = TimeZone.CurrentTimeZone;
            Console.WriteLine(localZone.StandardName);
            var exitCode = HostFactory.Run(x =>
            {
                x.Service<EmailService>(s =>
                {
                    s.ConstructUsing(smtpService => new EmailService());
                    s.WhenStarted(smtpService => smtpService.Start());
                    s.WhenStopped(smtpService => smtpService.Stop());
                });

                x.RunAsLocalSystem();
                x.SetServiceName("SMTPService");
                x.SetDisplayName("Reminder Service");
                x.SetDescription("This service checks the reminders set, and sends an email reminder to the user");
            });

            int exitCodeVal = (int)Convert.ChangeType(exitCode, exitCode.GetTypeCode());
            Environment.ExitCode = exitCodeVal;
        }
    }
}
