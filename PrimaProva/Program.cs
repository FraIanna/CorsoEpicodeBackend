namespace PrimaProva
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Atleta a = new Atleta();
            a.Nome = "Lionel";
            a.Cognome = "Messi";
            a.Sport = "calcio";
            a.Descriviti();
        
            Veicolo fiat = new Veicolo();
            fiat.Marca = "fiat";
            fiat.Cilindrata = 1200;
            fiat.AnnoImmatricolazione = 2019;
            fiat.Colore = "nero";

            fiat.DescriizoneAuto();

            Dipendente b = new Dipendente();
            b.Nome = "Pippo";
            b.Cognome = "Baudo";
            b.Azienda = "Facebook";
            b.Ore = 8;
            b.Stipendio = 1800;
            b.Descrivi();


            Animale c = new Animale();
            c.Nome = "Silvestro";
            c.Eta = 3;
            c.Razza = "persiano"; 
            c.DescriviAnimale();
        }

    }

}

