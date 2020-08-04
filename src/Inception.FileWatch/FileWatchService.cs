using EventBus.Domain;
using Inception.Application.Events.Entities;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Inception.FileWatch
{
    public class FileWatchService
    {
        private const string PathFileProblemas = "C:\\Diretorio\\ListaProblemas.csv";
        private readonly IIntegrationEventHandler<ProblemaIntegrationEvent> integrationEvent;

        public FileWatchService(IIntegrationEventHandler<ProblemaIntegrationEvent> integrationEvent)
        {
            this.integrationEvent = integrationEvent;
            LoopRoutine();
        }

        private void LoopRoutine()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    Task.Delay(10000);

                    if (File.Exists(PathFileProblemas))
                    {
                        List<ProblemaDTO> problemas = File.ReadAllLines(PathFileProblemas)
                                               .Select(v => ProblemaDTO.FromCsv(v))
                                               .ToList();

                        var problemasIntegrationEvents = problemas.Select(x => new ProblemaIntegrationEvent() { IdInceptions = x.IdInceptions, Abreviacao = x.Abreviacao, Descricao = x.Descricao }).ToList();

                        //Publish a messages
                        problemasIntegrationEvents.ForEach(integrationEvent.Handle);

                        File.Delete(PathFileProblemas);
                    }
                }
            });
        }
    }

    public class ProblemaDTO
    {
        public string Descricao { get; set; }
        public string Abreviacao { get; set; }
        public long IdInceptions { get; set; }

        public static ProblemaDTO FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(';');
            ProblemaDTO problemas = new ProblemaDTO();
            problemas.IdInceptions = long.Parse(values[0]);
            problemas.Abreviacao = values[1];
            problemas.Descricao = values[2];
            return problemas;
        }
    }
}
