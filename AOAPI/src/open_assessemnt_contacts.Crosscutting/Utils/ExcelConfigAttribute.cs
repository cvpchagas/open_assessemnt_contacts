using System;

namespace Open.Assessement.Contacts.Crosscutting.Utils
{
    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = false)]
    public class ExcelConfigAttribute : Attribute
    {
        private string _nomeColunaPlanilha;
        private int _tamanhoMaximo;
        private Type _tipo;
        private int _indexCampo;
        private bool _colunaObrigatoria;
        private string[] _valoresPermitidos;
        private bool _permiteNulos;  
        private bool _export;

        public ExcelConfigAttribute(string nomeColunaPlanilha = null, int tamanhoMaximo = 0, Type tipo = null, int indexCampo = 0, bool colunaObrigatoria = false, string[] valoresPermitidos = null, bool permiteNulos = false, bool export = false)
        {
            _nomeColunaPlanilha = nomeColunaPlanilha;
            _tamanhoMaximo = tamanhoMaximo;
            _tipo = tipo;
            _indexCampo = indexCampo;
            _colunaObrigatoria = colunaObrigatoria;
            _valoresPermitidos = valoresPermitidos;
            _permiteNulos = permiteNulos;
            _export = export;
        }

        public string NomeColunaPlanilha { get => _nomeColunaPlanilha; set => _nomeColunaPlanilha = value; }
        public int TamanhoMaximo { get => _tamanhoMaximo; set => _tamanhoMaximo = value; }
        public Type Tipo { get => _tipo; set => _tipo = value; }
        public int IndexCampo { get => _indexCampo; set => _indexCampo = value; }
        public bool ColunaObrigatoria { get => _colunaObrigatoria; set => _colunaObrigatoria = value; }
        public bool PermiteNulos { get => _permiteNulos; set => _permiteNulos = value; }
        public string[] ValoresPermitidos { get => _valoresPermitidos; set => _valoresPermitidos = value; }
        bool Export {get; set;}
    }
}
