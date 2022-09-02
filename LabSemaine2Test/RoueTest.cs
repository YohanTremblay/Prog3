using ConsoleApp2;

namespace LabSemaine2Test
{
    [TestClass]
    public class RoueTest
    {
        int largeur;
        int pourcentageHauteur;
        int diametreJante;
        int indiceCharge;
        char indiceVitesse;
        int pression;
        string type;
        Roue r;

        [TestInitialize]
        public void Init()
        {
            largeur = 16;
            pourcentageHauteur = 87;
            diametreJante = 13;
            indiceCharge = 123;
            indiceVitesse = 'V';
            pression = 11;
            type = "Hiver";

            r = new Roue(largeur, pourcentageHauteur, diametreJante, indiceCharge, indiceVitesse, pression, type);
        }
        [TestCleanup]
        public void Cleanup()
        {
            largeur = 0;
            pourcentageHauteur = 0;
            diametreJante = 0;
            indiceCharge = 0;
            indiceVitesse = ' ';
            pression = 0;
            type = " ";

            r = new Roue(largeur, pourcentageHauteur, diametreJante, indiceCharge, indiceVitesse, pression, type);
        }
        [TestMethod]
        public void Roue_ValeurCorrect_RoueMemeValeur()
        {
            Assert.AreEqual<int>(largeur, r.Largeur);
            Assert.AreEqual<int>(pourcentageHauteur, r.PourcentageHauteur);
            Assert.AreEqual<int>(diametreJante, r.DiametreJante);
            Assert.AreEqual<int>(indiceCharge, r.IndiceCharge);
            Assert.AreEqual<char>(indiceVitesse, r.IndiceVitesse);
            Assert.AreEqual<int>(pression, r.Pression);
            Assert.AreEqual<string>(type, r.Type);  
        }
        [TestMethod]
        public void RoueCopie_ValeurCorrect_RoueCopieMemeValeur()
        {
            Roue rC = new Roue(r);
            Assert.AreEqual<int>(r.Largeur, rC.Largeur);
            Assert.AreEqual<int>(r.PourcentageHauteur, rC.PourcentageHauteur);
            Assert.AreEqual<int>(r.DiametreJante, rC.DiametreJante);
            Assert.AreEqual<int>(r.IndiceCharge, rC.IndiceCharge);
            Assert.AreEqual<char>(r.IndiceVitesse, rC.IndiceVitesse);
            Assert.AreEqual<int>(r.Pression, rC.Pression);
            Assert.AreEqual<string>(r.Type, rC.Type);
        }
        [TestMethod]
        public void GonflerPneu_AugmenterPression_AugmentationPression()
        {
            int ajout = 11;
            Assert.AreEqual<int>(pression, r.Pression);
            r.GonflerPneu(ajout);
            Assert.AreEqual<int>(pression + ajout, r.Pression);

        }

    }
}
