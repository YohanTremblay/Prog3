using ConsoleApp2;

namespace LabSemaine2Test
{
    [TestClass]
    public class MoteurTest
    {
        int taille;
        int nbCylindres;
        int puissanceChevauxVapeur;
        double consommationParKm;
        Moteur moteur;
        private const string Expected = "Vrooooom !";

        [TestInitialize]
        public void Init()
        {
            taille = 3;
            nbCylindres = 8;
            puissanceChevauxVapeur = 21;
            consommationParKm = 14;

            moteur = new Moteur(taille, nbCylindres, puissanceChevauxVapeur, consommationParKm);
        }
        [TestCleanup]
        public void CleanUp()
        {
            taille = 0;
            nbCylindres = 0;
            puissanceChevauxVapeur = 0;
            consommationParKm = 0;

            moteur = null;
        }
        [TestMethod]
        public void Moteur_ValeurCorrect_MoteurMemeValeur()
        {
            Assert.AreEqual<int>(taille, moteur.Taille);
            Assert.AreEqual<int>(nbCylindres, moteur.NbCylindres);
            Assert.AreEqual<int>(puissanceChevauxVapeur, moteur.PuissanceChevauxVapeur);
            Assert.AreEqual<double>(consommationParKm, moteur.ConsommationParKm);
        }
        [TestMethod]
        public void DemarrerMoteur_AffichageMessage_AfficheVrooooom()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                moteur.DemarrerMoteur();

                var result = sw.ToString().Trim();
                Assert.AreEqual(Expected, result);
            }
        }
    }
}
