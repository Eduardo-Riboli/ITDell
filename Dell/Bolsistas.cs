using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dell
{
    public class Bolsistas
    {
        // Atribui os headers existentes no arquivo csv à um objeto Bolsistas
        private string nomeBolsista;
        private string cpfBolsista;
        private string entidadeEnsino;
        private int referencia;
        private int anoReferencia;
        private string diretoria;
        private string sistemaOrigem;
        private int modalidade;
        private string modalidadePagamento;
        private string moeda;
        private int pagamento;

        // Criação do construtor que vai receber todos os atributos como parâmetros
        public Bolsistas(string nomeBolsista, string cpfBolsista, string entidadeEnsino, int referencia,
                        int anoReferencia, string diretoria, string sistemaOrigem, int modalidade, string modalidadePagamento,
                        string moeda, int pagamento) 
        {
            this.nomeBolsista = nomeBolsista;
            this.cpfBolsista = cpfBolsista;
            this.entidadeEnsino = entidadeEnsino;
            this.referencia = referencia;
            this.anoReferencia = anoReferencia;
            this.diretoria = diretoria;
            this.sistemaOrigem = sistemaOrigem;
            this.modalidade = modalidade;
            this.modalidadePagamento = modalidadePagamento;
            this.moeda = moeda;
            this.pagamento = pagamento;
        }

        public int getAno()
        {
            return anoReferencia;
        }

        public string getNome()
        {
            return nomeBolsista;
        }

        public string getCpf()
        {
            return cpfBolsista;
        }

        public string getEntidade()
        {
            return entidadeEnsino;
        }

        public int getPagamento()
        {
            return pagamento;
        }

    }
}
