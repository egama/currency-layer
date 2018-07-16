using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neon.Elivelton.Domain.ViewModel
{
    public class DefaultResponseNeon
    {
        public DefaultResponseNeon()
        {
            errors = new List<string>();
        }

        public bool success { get { return errors.Count == 0; } }
        public List<string> errors { get; set; }
        public string messageOk { get; set; }
        public object data { get; set; }

        public void AddError(string _erro)
        {
            this.errors.Add(_erro);
        }

        public void AddSuccess(object _data, string _message = "Sucesso!")
        {
            this.data = _data;
            this.messageOk = _message;
        }
    }
}
