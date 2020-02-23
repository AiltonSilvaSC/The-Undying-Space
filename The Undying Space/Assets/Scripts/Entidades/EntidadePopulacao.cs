namespace Assets.Scripts.Entidades
{
    public class EntidadePopulacao
    {
        public string Nome { get; private set; }
        public float Quantidade { get; private set; }

        public EntidadePopulacao(string nome, float populacao)
        {
            this.Nome = nome;
            this.Quantidade = populacao;
        }

        public void AumentarPop(float quantidade)
        {
            this.Quantidade += quantidade;
        }

        /// <summary>
        /// Retorna verdadeiro caso a população tenha zerado.
        /// </summary>
        /// <param name="quantidade"></param>
        /// <returns>true</returns>
        public bool RemoverPop(float quantidade)
        {
            this.Quantidade -= quantidade;
            if (this.Quantidade <= 0)
                return true;
            return false;
        }
    }
}
