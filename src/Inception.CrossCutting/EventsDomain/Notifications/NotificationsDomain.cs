using System;
using System.Runtime.InteropServices;
using System.ComponentModel.DataAnnotations;
using Inception.CrossCutting.EventsDomain.Entities;

namespace Inception.CrossCutting.EventsDomain.Notificacoes.Notifications
{
    public class NotificationsDomain : Event
    {
        [Key]
        public Guid IdNotificacaoDominio { get; private set; }
        public string Chave { get; private set; }
        public string Valor { get; private set; }
        public Type Type { get; private set; }
        public string TipoObjeto { get; private set; }

        public string Ex { get; private set; }

        public bool Erro { get; private set; }

        public NotificationsDomain(string key, string value, Type type, [Optional] bool erro, [Optional] Exception ex)
        {
            IdNotificacaoDominio = Guid.NewGuid();
            Chave = key;
            Valor = value;
            Type = type;
            Erro = erro;
            if (ex != null)
            {
                Ex = ex.ToString();
            }

            TipoObjeto = Equals(Type, null) ? "" : Type.Name;
        }
    }
}
