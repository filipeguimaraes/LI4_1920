using System;

namespace Classes {

    public class Aula {

        private int codAula;
        private int numBilhetes;
        private float precoBilhete;
        private DateTime dataINI;
        private DateTime dataFIM;
        private string modalidade;
        private int codEspaco;
        private string email;

        public Aula()
        {
        }

        public Aula(int codAula, int numBilhetes, float precoBilhete, DateTime dataINI, DateTime dataFIM, string modalidade, int codEspaco, string email)
        {
            this.CodAula = codAula;
            this.NumBilhetes = numBilhetes;
            this.PrecoBilhete = precoBilhete;
            this.DataINI = dataINI;
            this.DataFIM = dataFIM;
            this.Modalidade = modalidade;
            this.CodEspaco = codEspaco;
            this.Email = email;
        }

        public int CodAula { get => codAula; set => codAula = value; }
        public int NumBilhetes { get => numBilhetes; set => numBilhetes = value; }
        public float PrecoBilhete { get => precoBilhete; set => precoBilhete = value; }
        public DateTime DataINI { get => dataINI; set => dataINI = value; }
        public DateTime DataFIM { get => dataFIM; set => dataFIM = value; }
        public string Modalidade { get => modalidade; set => modalidade = value; }
        public int CodEspaco { get => codEspaco; set => codEspaco = value; }
        public string Email { get => email; set => email = value; }

        public override bool Equals(object obj)
        {
            return obj is Aula aula &&
                   codAula == aula.codAula &&
                   numBilhetes == aula.numBilhetes &&
                   precoBilhete == aula.precoBilhete &&
                   dataINI == aula.dataINI &&
                   dataFIM == aula.dataFIM &&
                   modalidade == aula.modalidade &&
                   codEspaco == aula.codEspaco &&
                   email == aula.email &&
                   CodAula == aula.CodAula &&
                   NumBilhetes == aula.NumBilhetes &&
                   PrecoBilhete == aula.PrecoBilhete &&
                   DataINI == aula.DataINI &&
                   DataFIM == aula.DataFIM &&
                   Modalidade == aula.Modalidade &&
                   CodEspaco == aula.CodEspaco &&
                   Email == aula.Email;
        }
    }

}