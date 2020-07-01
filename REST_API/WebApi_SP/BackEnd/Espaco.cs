using System;

namespace Spaces {

    public class Espaco {

        private int codEspaco;
        private string tipo;
        private int lotacao;
        private string local;
        private float precoHora;
        private int area;
        private DateTime disponivelIni;
        private DateTime disponivelFim;
        private float lat;
        private float lng;

        public Espaco()
        {
        }

        public Espaco(string tipo, int lotacao, string local, float precoHora, int area, DateTime disponivelIni, DateTime disponivelFim, float lat, float lng)
        {
            
            this.Tipo = tipo;
            this.Lotacao = lotacao;
            this.Local = local;
            this.PrecoHora = precoHora;
            this.Area = area;
            this.DisponivelIni = disponivelIni;
            this.DisponivelFim = disponivelFim;
            this.Lat = lat;
            this.Lng = lng;
        }

        public Espaco(int cod, string tipo, int lotacao, string local, float precoHora, int area, DateTime disponivelIni, DateTime disponivelFim, float lat, float lng)
        {
            this.CodEspaco = cod;
            this.Tipo = tipo;
            this.Lotacao = lotacao;
            this.Local = local;
            this.PrecoHora = precoHora;
            this.Area = area;
            this.DisponivelIni = disponivelIni;
            this.DisponivelFim = disponivelFim;
            this.Lat = lat;
            this.Lng = lng;
        }

        public int CodEspaco { get => codEspaco; set => codEspaco = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public int Lotacao { get => lotacao; set => lotacao = value; }
        public string Local { get => local; set => local = value; }
        public float PrecoHora { get => precoHora; set => precoHora = value; }
        public int Area { get => area; set => area = value; }
        public DateTime DisponivelIni { get => disponivelIni; set => disponivelIni = value; }
        public DateTime DisponivelFim { get => disponivelFim; set => disponivelFim = value; }
        public float Lat { get => lat; set => lat = value; }
        public float Lng { get => lng; set => lng = value; }

        public override bool Equals(object obj)
        {
            return obj is Espaco espaco &&
                   codEspaco == espaco.codEspaco &&
                   tipo == espaco.tipo &&
                   lotacao == espaco.lotacao &&
                   local == espaco.local &&
                   precoHora == espaco.precoHora &&
                   area == espaco.area &&
                   disponivelIni == espaco.disponivelIni &&
                   disponivelFim == espaco.disponivelFim &&
                   CodEspaco == espaco.CodEspaco &&
                   Tipo == espaco.Tipo &&
                   Lotacao == espaco.Lotacao &&
                   Local == espaco.Local &&
                   PrecoHora == espaco.PrecoHora &&
                   Area == espaco.Area &&
                   DisponivelIni == espaco.DisponivelIni &&
                   DisponivelFim == espaco.DisponivelFim;
        }
    }

}