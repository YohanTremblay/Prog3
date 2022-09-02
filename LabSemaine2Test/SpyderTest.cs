using ConsoleApp2;

namespace LabSemaine2Test
{
    [TestClass]
    public class SpyderTest
    {
        string style;
        int tailleReservoir;
        int dureeVieKm;
        string couleur;
        string marque;
        string modele;
        Spyder s;
        Roue roue;
        Moteur moteur;
        double distanceParcourue;
        private const string Expected = "Pour faire le tournant serré, vous avez simplement tourné la direction de la Spyder.";


        [TestInitialize]
        public void Init()
        {
            distanceParcourue = 0.0;
            roue = new Roue(50, 25, 42, 11, 'S', 19, "ko");
            moteur = new Moteur(14, 7, 11, 21);
            dureeVieKm = 17;
            couleur = "Blue";
            marque = "Toyota";
            modele = "OK";
            tailleReservoir = 20;
            style = "Spyder";
            s = new Spyder(dureeVieKm, tailleReservoir, moteur, roue, couleur, marque, modele);

        }
        [TestCleanup]
        public void CleanUp()
        {
            distanceParcourue = 0.0;
            roue = null;
            moteur = null;
            dureeVieKm = 0;
            couleur = "";
            marque = "";
            modele = "";
            tailleReservoir = 0;
            style = "";
            s = null;
        }
        [TestMethod]
        public void Spyder_Style_StyleSpyder()
        {
            Assert.AreEqual<string>(style, s.Style);
        }
        [TestMethod]
        public void TournerSerrer_AffichageMessage_AfficheBonMessage()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                s.TournerSerrer();

                var result = sw.ToString().Trim();
                Assert.AreEqual(Expected, result);
            }
        }
    }
}
