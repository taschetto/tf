using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examiner.Negocio
{
    class Question
    {
        private String _enunciado;
        private List<String> _alternativas;
        private String _resp;
        private String _feedback;

        public String Enunciado { set; get; }
        public List<String> Alternativa { set; get; }
        public String Resposta { get; set; }
        public String Feedback { get; set; }

        public Question(String enunciado, List<String> alt , String resp, String feed)
        {
            _enunciado = enunciado;
            _alternativas = alt;
            _resp = resp;
            _feedback = feed;
        }


    }
}
