namespace Assets.Scripts.Entidades
{
    public class EntidadeTropa
    {
        public string Nome { get; private set; }
        public float Quantidade { get; private set; }

        public EntidadeTropa(string nome, float quantidade)
        {
            this.Nome = nome;
            this.Quantidade = quantidade;
        }
    }
}
